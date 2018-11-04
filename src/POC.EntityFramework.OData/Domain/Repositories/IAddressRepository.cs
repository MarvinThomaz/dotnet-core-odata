using POC.EntityFramework.OData.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POC.EntityFramework.OData.Domain.Repositories
{
    /// <summary>
    /// Repositório de endereço
    /// </summary>
    public interface IAddressRepository
    {
        /// <summary>
        /// Método de criação de endereço.
        /// </summary>
        /// <param name="person">Endereço a ser criado.</param>
        /// <returns></returns>
        Task Create(Address person);

        /// <summary>
        /// Método de busca de endereços
        /// </summary>
        /// <param name="personKey">Chave da pessoa</param>
        /// <returns>Listagem de endereços.</returns>
        Task<IEnumerable<Address>> Get(Guid personKey);

        /// <summary>
        /// Método de listagem de todos os endereços.
        /// </summary>
        /// <returns>Listagem de endereços</returns>
        Task<IEnumerable<Address>> Get();
    }
}