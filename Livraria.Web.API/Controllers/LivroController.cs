using Livraria.Domain.Interfaces.Services;
using Livraria.Domain.Log;
using Livraria.Web.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace Livraria.Web.API.Controllers
{
    /// <summary>
    /// Classe Controller para Livro
    /// </summary>
    public class LivroController : ApiController
    {
        private IServicoLivro _servico;
        private ILog _log;

        /// <summary>
        /// Construtor Padrão
        /// </summary>
        /// <param name="servico"></param>
        public LivroController(IServicoLivro servico, ILog log)
        {
            _servico = servico;
            _log = log;
        }

        /// <summary>
        /// Método responsável por listar todos os livros
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public object[][] ListarTodos()
        {
            try
            {
                var valores = new List<object[]>();

                foreach (var livro in _servico.ListarTodos())
                {
                    var livroViewModel = new LivroModel(livro);

                    valores.Add(new object[] { livroViewModel.Id, livroViewModel.Id, livroViewModel.Autor, livroViewModel.Editor, livroViewModel.Preco, livroViewModel.Titulo });
                }

                return valores.ToArray();
            }
            catch (Exception e)
            {
                _log.Erro(e);
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.InternalServerError, "Erro ao buscar livros."));
            }
        }


        /// <summary>
        /// Método responsável por selecionar um livro por título
        /// </summary>
        /// <param name="titulo"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/livro/selecionarPorTitulo/{titulo}")]
        public LivroModel SelecionarPorTitulo(string titulo)
        {
            try
            {
                var livro = _servico.Selecionar(l => l.Titulo == titulo);

                if (livro == null)
                    throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound, $"Título {titulo} não encontrado."));

                return new LivroModel(livro);
            }
            catch (Exception e)
            {
                _log.Erro(e);
                throw e;
            }
        }

        /// <summary>
        /// Método responsável por selicionar um livro por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public LivroModel SelecionarPorId(int id)
        {
            try
            {
                var livro = _servico.Selecionar(l => l.Id == id);

                if (livro == null)
                    throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound, $"Livro com id {id} não encontrado."));

                return new LivroModel(livro);

            }
            catch (Exception e)
            {
                _log.Erro(e);
                throw e;
            }
        }

        /// <summary>
        /// Método responsável por inserir livro
        /// </summary>
        /// <param name="livro"></param>
        [HttpPost]
        public void Post([FromBody]LivroModel livro)
        {
            try
            {
                if (livro.Id == 0)
                    _servico.Inserir(livro.ParaModelo());
                else
                    _servico.Atualizar(livro.ParaModelo());
            }
            catch (Exception e)
            {
                _log.Erro(e);
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.InternalServerError,e.Message));
            }

        }


        /// <summary>
        /// Método responsável por excluir livro por id
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            try
            {
                _servico.Excluir(l => l.Id == id);
            }
            catch (Exception e)
            {
                _log.Erro(e);
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }
    }
}
