using Livraria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.DataAccess.Configuration
{
    public class ConfiguracaoBase<T> : EntityTypeConfiguration<T> where T : EntidadeBase
    {
        public ConfiguracaoBase()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(m => m.DataInclusao);
            Property(m => m.DataAlteracao);

        }
    }
}
