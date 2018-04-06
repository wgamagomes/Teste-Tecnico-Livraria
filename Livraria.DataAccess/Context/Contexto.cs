using Livraria.DataAccess.Configuration;
using Livraria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.DataAccess.Context
{
    public class Contexto : DbContext
    {
        private static Action<string> consoleLog;

        /// <summary>
        /// Construtor estatico
        /// </summary>
        static Contexto()
        {
            if (Environment.UserInteractive)
                consoleLog = log => { Debug.WriteLine(log); Console.WriteLine(log); };

            else
                consoleLog = log => { };

        }

        /// <summary>
        /// Construtor padrão
        /// </summary>
        /// <param name="db"></param>
        /// <param name="contextOwnsConnection"></param>
        public Contexto() :
            base("ConexaoPadrao")
        {
            this.Database.Log = consoleLog;

            Configuration.LazyLoadingEnabled = false;
        }


        /// <summary>
        /// Método responsável pela contrução dos modelos
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            DesabilitarConvencoes(modelBuilder);
            DefinirValoresPadroes(modelBuilder);
            RegistrarConfiguracoes(modelBuilder);

            base.OnModelCreating(modelBuilder);

        }

        /// <summary>
        /// Método responsável por desabilitar as convenções definidas na model builder  
        /// </summary>
        /// <param name="modelBuilder"></param>
        private void DesabilitarConvencoes(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }

        /// <summary>
        ///  Método responsável por definir a configuração das propriedades com valores padrões
        /// </summary>
        /// <param name="modelBuilder"></param>
        private void DefinirValoresPadroes(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<string>().Configure(e => e.HasColumnType("nvarchar"));
            modelBuilder.Properties<string>().Configure(e => e.HasMaxLength(255));
        }

        /// <summary>
        /// Método responsável por permitir que as configurações das entidades sejam registradas na model builder
        /// </summary>
        /// <param name="modelBuilder"></param>
        private void RegistrarConfiguracoes(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ConfiguracaoLivro());
        }
      
        /// <summary>
        /// Método responsável por salvar as modificações
        /// </summary>
        /// <returns></returns>
        public override int SaveChanges()
        {
            var changeSet = base.ChangeTracker.Entries<EntidadeBase>();

            if (changeSet != null)
            {
                foreach (var entry in changeSet.Where(c => c.State != EntityState.Unchanged))
                {
                    if (entry.State == EntityState.Added)
                    {
                        entry.Entity.DataInclusao = DateTime.Now;
                    }

                    if (entry.State == EntityState.Modified)
                    {   
                        entry.Property("DataInclusao").IsModified = false;                        
                        entry.Entity.DataAlteracao = DateTime.Now;
                    }
                }
            }

            return base.SaveChanges();
        }
    }
}
