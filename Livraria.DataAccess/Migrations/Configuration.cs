namespace Livraria.DataAccess.Migrations
{
    using Livraria.Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Livraria.DataAccess.Context.Contexto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Context.Contexto context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var livros = new List<Livro>
            {
                new Livro { Preco = 34.9, Titulo = "O extraordinário", Autor = "R. J. Palacio",Editor = "Mark Livolsi" },
                new Livro { Preco = 89.9, Titulo = "C completo e total",Autor = "Herbert Schildt",Editor = "Herbert Schildt" }
            };

            context.Set<Livro>().AddOrUpdate(e => e.Titulo, livros.ToArray());


        }
    }
}
