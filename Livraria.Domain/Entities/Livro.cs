
namespace Livraria.Domain.Entities
{
    /// <summary>
    /// Entidade Livro
    /// </summary>
    public class Livro : EntidadeBase
    {
        /// <summary>
        /// Titulo
        /// </summary>
        public string Titulo { get; set; }

        /// <summary>
        /// Preco
        /// </summary>
        public double Preco { get; set; }

        /// <summary>
        /// Autor
        /// </summary>
        public string Autor { get; set; }

        /// <summary>
        /// Editor
        /// </summary>
        public string Editor { get; set; }

    }
}
