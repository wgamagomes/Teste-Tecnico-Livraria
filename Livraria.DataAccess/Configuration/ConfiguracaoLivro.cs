using Livraria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.DataAccess.Configuration
{
    public class ConfiguracaoLivro: ConfiguracaoBase<Livro>
    {
        public ConfiguracaoLivro():
            base()
        {
            ToTable("Livro");
            Property(m => m.Titulo).HasMaxLength(1024);
            Property(m => m.Autor).HasMaxLength(1024);
            Property(m => m.Editor).HasMaxLength(1024);

        }
    }
}
