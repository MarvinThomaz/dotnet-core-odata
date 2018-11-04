using System;
using System.ComponentModel.DataAnnotations;

namespace POC.EntityFramework.OData.Domain.Entities
{
    /// <summary>
    /// Entidade de representação de endereço.
    /// </summary>
    public class Address
    {
        /// <summary>
        /// Chave de identificação de endereço.
        /// </summary>
        /// <value></value>
        [Key]
        public Guid Key { get; set; }

        /// <summary>
        /// Chave da identificaçõa do dono do endereço.
        /// </summary>
        /// <value></value>
        public Guid PersonKey { get; set; }

        /// <summary>
        /// Endereço.
        /// </summary>
        /// <value></value>
        public string Street { get; set; }

        /// <summary>
        /// Número do endereço.
        /// </summary>
        /// <value></value>
        public int Number { get; set; }
    }
}
