using Livraria.IoC;
using Livraria.Web.API.App_Start;
using System.Web.Http;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(InjetorDependenciaConfig), "Initialize")]
namespace Livraria.Web.API.App_Start
{

    /// <summary>
    /// Injetor Dependencia Config
    /// </summary>
    public static class InjetorDependenciaConfig
    {
        /// <summary>
        /// Inicialização do injetor de dependencia
        /// </summary>
        public static void Initialize()
        {
            InjetorDependencia.Inicializar();

            InjetorDependencia.RegistrarControllers(GlobalConfiguration.Configuration);

            GlobalConfiguration.Configuration.DependencyResolver = InjetorDependencia.Resolver();
              
        }
    }
}