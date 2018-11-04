namespace POC.EntityFramework.OData.Domain.Models
{
    /// <summary>
    /// Modelo de criação de endereço.
    /// </summary>
    public class CreateAddressModel
    {
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