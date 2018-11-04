using System;

namespace POC.EntityFramework.OData.Domain.Models
{
    /// <summary>
    /// Modelo de busca de endereço.
    /// </summary>
    public class GetAddressViewModel
    {
        /// <summary>
        /// Chave de identificação de endereço.
        /// </summary>
        /// <value></value>
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
