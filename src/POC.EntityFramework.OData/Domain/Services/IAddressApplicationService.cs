using POC.EntityFramework.OData.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POC.EntityFramework.OData.Domain.Services
{
    /// <summary>
    /// Serviço de gerênciamento de endereços.
    /// </summary>
    public interface IAddressApplicationService
    {
        /// <summary>
        /// Método de criação de endereço.
        /// </summary>
        /// <param name="personKey">Chave da pessoa.</param>
        /// <param name="request">Dados de endereço</param>
        /// <returns>Endereço criado.</returns>
        Task<CreateAddressViewModel> CreateAddress(Guid personKey, CreateAddressModel request);

        /// <summary>
        /// Método que busca todos os endereços.
        /// </summary>
        /// <returns>Listagem de endereços.</returns>
        Task<IEnumerable<GetAddressViewModel>> GetAddresses();

        /// <summary>
        /// Método de busca de endereços.
        /// </summary>
        /// <param name="personKey">Chave da pessoa.</param>
        /// <returns>Listagem de endereços.</returns>
        Task<IEnumerable<GetAddressViewModel>> GetAddressesByPerson(Guid personKey);
    }
}