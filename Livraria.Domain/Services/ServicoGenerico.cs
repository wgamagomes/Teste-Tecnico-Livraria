using Livraria.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Livraria.Domain.Entities;
using Livraria.Domain.Interfaces.Repositories;

namespace Livraria.Domain.Services
{
    /// <summary>
    /// Classe generica de serviço
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ServicoGenerico<T> : IServicoGenerico<T> where T : EntidadeBase
    {
        private IRepositorioGenerico<T> _repositorio;

        /// <summary>
        /// Construtor padrão
        /// </summary>
        /// <param name="repositorio"></param>
        public ServicoGenerico(IRepositorioGenerico<T> repositorio)
        {
            _repositorio = repositorio;
        }

        /// <summary>
        /// Método responsável por atualizar registros
        /// </summary>
        /// <param name="registros"></param>
        public void Atualizar(params T[] registros)
        {
            _repositorio.Atualizar(registros);
        }

        /// <summary>
        /// Método responsável por contar registros
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public int Contar(Expression<Func<T, bool>> filtro)
        {
           return _repositorio.Contar(filtro);
        }

        /// <summary>
        /// Método responsável por excluir registros
        /// </summary>
        /// <param name="registros"></param>
        public void Excluir(params T[] registros)
        {
            _repositorio.Excluir(registros);
        }

        /// <summary>
        /// Método responsável por excluir registros
        /// </summary>
        /// <param name="filtro"></param>
        public void Excluir(Expression<Func<T, bool>> filtro)
        {
            _repositorio.Excluir(filtro);
        }

        /// <summary>
        /// Método responsável por excluir todos registros
        /// </summary>
        public void ExcluirTodos()
        {
            _repositorio.ExcluirTodos();
        }

        /// <summary>
        /// Método responsável por inserir registros
        /// </summary>
        /// <param name="registros"></param>
        public void Inserir(params T[] registros)
        {
            _repositorio.Inserir(registros);
        }

        /// <summary>
        /// Método responsável por listar registros
        /// </summary>
        /// <param name="filtro"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public IList<T> Listar(Expression<Func<T, bool>> filtro, params Expression<Func<T, object>>[] include)
        {
            return _repositorio.Listar(filtro, include);
        }

        /// <summary>
        /// Método responsável por listar todos registros
        /// </summary>
        /// <returns></returns>
        public IList<T> ListarTodos()
        {
            return _repositorio.ListarTodos();
        }

        /// <summary>
        /// Método responsável por selecionar registro, se o obter mais de um o primeiro é retornado
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public T Selecionar(Expression<Func<T, bool>> filtro)
        {
            return _repositorio.Selecionar(filtro);
        }
    }
}
