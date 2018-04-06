using Livraria.Domain.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.CrossCutting
{
    /// <summary>
    /// Classe Log
    /// </summary>
    public class Log : ILog
    {
        /// <summary>
        /// Método responsável por logar erro recebendo uma exception como parâmetro
        /// </summary>
        /// <param name="e"></param>
        public void Erro(Exception e)
        {
            //TODO: Implementar usando a log4net
        }
    }
}
