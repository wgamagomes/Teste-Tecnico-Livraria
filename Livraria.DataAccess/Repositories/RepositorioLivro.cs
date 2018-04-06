using Livraria.Domain.Entities;
using Livraria.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.DataAccess.Repositories
{
    public class RepositorioLivro : RepositorioGenerico<Livro>, IRepositorioLivro
    {
    }
}
