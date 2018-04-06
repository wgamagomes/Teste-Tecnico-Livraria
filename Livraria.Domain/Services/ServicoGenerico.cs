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
    public class ServicoGenerico<T> : IServicoGenerico<T> where T : EntidadeBase
    {
        private IRepositorioGenerico<T> _repositorio;

        public ServicoGenerico(IRepositorioGenerico<T> repositorio)
        {
            _repositorio = repositorio;
        }

        public void Atualizar(params T[] registros)
        {
            _repositorio.Atualizar(registros);
        }

        public int Contar(Expression<Func<T, bool>> filtro)
        {
           return _repositorio.Contar(filtro);
        }

        public void Excluir(params T[] registros)
        {
            _repositorio.Excluir(registros);
        }

        public void Excluir(Expression<Func<T, bool>> filtro)
        {
            _repositorio.Excluir(filtro);
        }

        public void ExcluirTodos()
        {
            _repositorio.ExcluirTodos();
        }

        public void Inserir(params T[] registros)
        {
            _repositorio.Inserir(registros);
        }

        public IList<T> Listar(Expression<Func<T, bool>> filtro, params Expression<Func<T, object>>[] include)
        {
            return _repositorio.Listar(filtro, include);
        }

        public IList<T> ListarTodos()
        {
            return _repositorio.ListarTodos();
        }

        public T Selecionar(Expression<Func<T, bool>> filtro)
        {
            return _repositorio.Selecionar(filtro);
        }
    }
}
