using Livraria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Livraria.Web.API.Models
{
    /// <summary>
    /// Model Livro
    /// </summary>
    public class LivroModel
    {
        /// <summary>
        /// Titulo
        /// </summary>
        public string Titulo { get; set; }

        /// <summary>
        /// Autor
        /// </summary>
        public string Autor { get; set; }

        /// <summary>
        /// Editor
        /// </summary>
        public string Editor { get; set; }

        /// <summary>
        /// Preco
        /// </summary>
        public double Preco { get; set; }

        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Construtor
        /// </summary>
        public LivroModel()
        {
        }

        /// <summary>
        /// Construtor Padrão
        /// </summary>
        /// <param name="livro"></param>
        public LivroModel(Livro livro)
        {
            this.Titulo = livro.Titulo;
            this.Preco = livro.Preco;
            this.Id = livro.Id;
            this.Editor = livro.Editor;
            this.Autor = livro.Autor;
        }

        /// <summary>
        /// Método responsável por mapear a entidade para modelo
        /// </summary>
        /// <returns></returns>
       public Livro ParaModelo()
        {
            return new Livro
            {
                Preco = this.Preco,
                Titulo = this.Titulo,
                Id = this.Id,
                Autor = this.Autor,
                Editor = this.Editor
            };
        }

    }
}