using System;

namespace Livraria.Domain.Entities
{
    /// <summary>
    /// Entidade Base
    /// </summary>
    public class EntidadeBase
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Data de Inclusao
        /// </summary>
        public DateTime? DataInclusao { get; set; }


        /// <summary>
        /// Data de Alteração
        /// </summary>
        public  DateTime? DataAlteracao { get; set; }
    }
}
