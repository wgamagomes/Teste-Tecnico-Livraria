using Livraria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Livraria.Domain.Interfaces.Repositories;
using Livraria.Domain.Interfaces.Services;
using Livraria.Domain.Interfaces;

namespace Livraria.Domain.Services
{
    /// <summary>
    /// Classe de serviço livro
    /// </summary>
    public class ServicoLivro : ServicoGenerico<Livro>, IServicoLivro
    {
        /// <summary>
        /// Construtor padrão
        /// </summary>
        /// <param name="repositorio"></param>
        public ServicoLivro(IRepositorioLivro repositorio) : base(repositorio)
        {
        }
    }
}
