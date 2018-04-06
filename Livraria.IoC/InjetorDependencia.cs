using Livraria.CrossCutting;
using Livraria.DataAccess.Repositories;
using Livraria.Domain.Interfaces;
using Livraria.Domain.Interfaces.Services;
using Livraria.Domain.Log;
using Livraria.Domain.Services;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System.Web.Http;
using System.Web.Http.Dependencies;

namespace Livraria.IoC
{
    /// <summary>
    /// Classe Injetor Dependencia
    /// </summary>
    public class InjetorDependencia
    {
        public static bool _containerInicializado { get; private set; }
        private static Container _container;
        private static object mutex = new object();

        /// <summary>
        /// Container
        /// </summary>
        public static Container Container
        {
            get
            {
                return _container;
            }
        }

        /// <summary>
        /// Resolver
        /// </summary>
        /// <returns></returns>
        public static IDependencyResolver Resolver()
        {
            return new SimpleInjectorWebApiDependencyResolver(_container);
        }

        public static void Inicializar()
        {
            lock (mutex)
            {
                if (!_containerInicializado)
                {
                    _container = new Container();
                    _container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
                    InicializarContainer(_container);
                    _containerInicializado = true;
                }
            }
        }
        /// <summary>
        /// Método responsável por inicializar o container
        /// </summary>
        /// <param name="container"></param>
        private static void InicializarContainer(Container container)
        {
            container.Register<IServicoLivro, ServicoLivro>(Lifestyle.Scoped);
            container.Register<IRepositorioLivro, RepositorioLivro>(Lifestyle.Scoped);
            container.Register<ILog, Log>(Lifestyle.Scoped);
        }

        /// <summary>
        /// Método responsável por registrar as controllers
        /// </summary>
        /// <param name="configuration"></param>
        public static void RegistrarControllers(HttpConfiguration configuration)
        {
            _container.RegisterWebApiControllers(configuration);
        }

        /// <summary>
        /// Método responsável por verificar o container
        /// </summary>
        /// <param name="container"></param>
        public static void VerificarContainer(Container container)
        {
            if (!container.IsVerifying)
                container.Verify();
        }

        /// <summary>
        /// Classe responsável por obter uma instância 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="container"></param>
        /// <returns></returns>
        public static T ObterInstancia<T>(Container container) where T : class
        {
            return container.GetInstance<T>();
        }

    }
}
