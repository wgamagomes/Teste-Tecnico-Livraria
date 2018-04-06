using Livraria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;


namespace Livraria.Domain.Interfaces.Repositories
{
    /// <summary>
    /// IRepositorioGenerico
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepositorioGenerico<T> where T : EntidadeBase
    {
        /// <summary>
        /// Assinatura do método responsável por listar registros 
        /// </summary>
        /// <param name="filtro"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        IList<T> Listar(Expression<Func<T, bool>> filtro, params Expression<Func<T, object>>[] include);

        /// <summary>
        ///  Assinatura do método responsável por listar registros 
        /// </summary>
        /// <param name="include"></param>
        /// <returns></returns>
        IList<T> Listar(string include);

        /// <summary>
        /// Assinatura do método responsável por listar todos registros
        /// </summary>
        /// <returns></returns>
        IList<T> ListarTodos();

        /// <summary>
        /// Assinatura do método responsável por contar registros
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        int Contar(Expression<Func<T, bool>> filtro);


        /// <summary>
        /// Assinatura do método responsável por atualizar regitros 
        /// </summary>
        /// <param name="registros"></param>
        void Atualizar(params T[] registros);


        /// <summary>
        /// Assinatura do método responsável por excluir um regitros 
        /// </summary>
        /// <param name="registros"></param>
        void Excluir(params T[] registros);


        /// <summary>
        /// Assinatura do método responsável por excluir regitros 
        /// </summary>
        /// <param name="registros"></param>
        void Excluir(Expression<Func<T, bool>> filtro);


        /// <summary>
        /// Assinatura do método responsável por inserir regitros 
        /// </summary>
        /// <param name="registros"></param>
        void Inserir(params T[] registros);


        /// <summary>
        /// Assinatura do método responsável por excluir todos registros
        /// </summary>
        void ExcluirTodos();


        /// <summary>
        /// Assinatura do método responsável por selecionar um registro, se o retorno for maior que 1, então o primeiro é retornado 
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        T Selecionar(Expression<Func<T, bool>> filtro);
    }
}
