using Livraria.DataAccess.Context;
using Livraria.Domain.Entities;
using Livraria.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.DataAccess.Repositories
{
    public class RepositorioGenerico<T> : IRepositorioGenerico<T> where T : EntidadeBase
    {
        /// <summary>
        /// M
        /// </summary>
        /// <returns></returns>
        public Contexto ObterContexto()
        {
            return new Contexto();
        }

        /// <summary>
        /// Construtor Padrão
        /// </summary>
        /// <param name="contexto"></param>
        public RepositorioGenerico()
        {
        }

        /// <summary>
        /// Método responsável por listar
        /// </summary>
        /// <param name="where"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public virtual IList<T> Listar(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            using (var contexto = ObterContexto())
            {
                IQueryable<T> set = contexto.Set<T>();

                if (include.Any())
                {
                    set = include.Aggregate(set, (current, expression) => current.Include(expression));
                }

                set = set.Where(where);

                return set.ToList();
            }
        }

        /// <summary>
        /// Método responsável por contar registros
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public int Contar(Expression<Func<T, bool>> filtro)
        {
            using (var contexto = ObterContexto())
            {
                return contexto.Set<T>().Where(filtro).Count();
            }
        }

        /// <summary>
        /// Método responsável por atualizar regitros 
        /// </summary>
        /// <param name="registros"></param>
        public virtual void Atualizar(params T[] registros)
        {
            using (var contexto = ObterContexto())
            {
                foreach (var registro in registros)
                {
                    contexto.Set<T>().Attach(registro);
                    contexto.Entry<T>(registro).State = EntityState.Modified;
                }
                contexto.SaveChanges();
            }
        }

        /// <summary>
        /// Método responsável por listar registros
        /// </summary>
        /// <param name="include"></param>
        /// <returns></returns>
        public virtual IList<T> Listar(string include)
        {
            using (var contexto = ObterContexto())
            {
                IQueryable<T> set = contexto.Set<T>().Include(include);

                return set.ToList();
            }
        }

        /// <summary>
        /// Método responsável por excluir um regitros 
        /// </summary>
        /// <param name="registros"></param>
        public virtual void Excluir(params T[] registros)
        {
            using (var contexto = ObterContexto())
            {
                foreach (var registro in registros)
                {
                    contexto.Entry<T>(registro).State = EntityState.Deleted;
                }
                contexto.SaveChanges();
            }
        }

        /// <summary>
        /// Método responsável por excluir regitros 
        /// </summary>
        /// <param name="registros"></param>
        public virtual void Excluir(Expression<Func<T, bool>> filtro)
        {
            using (var contexto = ObterContexto())
            {
                var tContext = contexto.Set<T>();
                tContext.Where(filtro).ToList();

                foreach (var item in tContext.Where(filtro).ToList())
                {
                    contexto.Entry<T>(item).State = EntityState.Deleted;
                }
                contexto.SaveChanges();
            }

        }

        /// <summary>
        /// Método responsável por inserir regitros 
        /// </summary>
        /// <param name="registros"></param>
        public virtual void Inserir(params T[] registros)
        {
            using (var contexto = ObterContexto())
            {
                foreach (var registro in registros)
                {
                    contexto.Entry<T>(registro).State = EntityState.Added;
                }

                contexto.SaveChanges();
            }
        }

        /// <summary>
        /// Método responsável por excluir todos registros
        /// </summary>
        public void ExcluirTodos()
        {
            using (var contexto = ObterContexto())
            {
                var tContext = contexto.Set<T>();

                foreach (var item in tContext.ToList())
                {
                    contexto.Entry<T>(item).State = EntityState.Deleted;
                }
                contexto.SaveChanges();
            }
        }

        /// <summary>
        /// Método responsável por selecionar um registro, se o retorno for maior que 1, então o primeiro é retornado 
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public T Selecionar(Expression<Func<T, bool>> filtro)
        {
            using (var contexto = ObterContexto())
            {
                return contexto.Set<T>().Where(filtro).ToList().FirstOrDefault();
            }
        }

        /// <summary>
        /// Método responsável por listar todos registros
        /// </summary>
        /// <returns></returns>
        public IList<T> ListarTodos()
        {
            using (var contexto = ObterContexto())
            {
                IQueryable<T> set = contexto.Set<T>();

                return set.ToList();
            }
        }
    }
}
