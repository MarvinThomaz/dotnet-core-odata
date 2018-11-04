using POC.EntityFramework.OData.Domain.Models;
using System;
using System.Threading.Tasks;

namespace POC.EntityFramework.OData.Domain.Commands
{
    /// <summary>
    /// Comando de criação de endereço
    /// </summary>
    public interface ICreateAddressCommand
    {
        /// <summary>
        /// Modelo de criação de endereço
        /// </summary>
        /// <value></value>
        CreateAddressModel Model { get; set; }

        /// <summary>
        /// Método de execução de comando.
        /// </summary>
        /// <param name="personKey">Chave da pessoa</param>
        /// <returns>Endereço criado.</returns>
        Task<CreateAddressViewModel> Execute(Guid personKey);
    }
}