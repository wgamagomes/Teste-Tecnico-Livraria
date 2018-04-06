using System;

namespace Livraria.Domain.Log
{
    /// <summary>
    /// ILog
    /// </summary>
    public interface ILog
    {
        /// <summary>
        /// Assinatura do método para logar erro recebendo uma exception como parâmetro
        /// </summary>
        /// <param name="e"></param>
        void Erro(Exception e);
    }
}
