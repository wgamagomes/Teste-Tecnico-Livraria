using Livraria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Domain.Interfaces.Services
{
    public interface IServicoGenerico<T> where T : EntidadeBase
    {
        IList<T> Listar(Expression<Func<T, bool>> filtro, params Expression<Func<T, object>>[] include);

        IList<T> ListarTodos();

        /// <summary>
        /// Método responsável por contar registros
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        int Contar(Expression<Func<T, bool>> filtro);


        /// <summary>
        /// Método responsável por atualizar regitros 
        /// </summary>
        /// <param name="registros"></param>
        void Atualizar(params T[] registros);


        /// <summary>
        /// Método responsável por excluir um regitros 
        /// </summary>
        /// <param name="registros"></param>
        void Excluir(params T[] registros);


        /// <summary>
        /// Método responsável por excluir regitros 
        /// </summary>
        /// <param name="registros"></param>
        void Excluir(Expression<Func<T, bool>> filtro);


        /// <summary>
        /// Método responsável por inserir regitros 
        /// </summary>
        /// <param name="registros"></param>
        void Inserir(params T[] registros);


        /// <summary>
        /// Método responsável por excluir todos registros
        /// </summary>
        void ExcluirTodos();


        /// <summary>
        /// Método responsável por selecionar um registro, se o retorno for maior que 1, então o primeiro é retornado 
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        T Selecionar(Expression<Func<T, bool>> filtro);
    }
}
