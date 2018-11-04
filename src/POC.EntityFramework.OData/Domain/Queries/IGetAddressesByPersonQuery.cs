using POC.EntityFramework.OData.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POC.EntityFramework.OData.Domain.Queries
{
    /// <summary>
    /// Query de busca de endereços.
    /// </summary>
    public interface IGetAddressesByPersonQuery
    {
        
        /// <summary>
        /// Método de execução da query.
        /// </summary>
        /// <param name="personKey">Chave da pessoa.</param>
        /// <returns>Listagem de endereços</returns>
        Task<IEnumerable<GetAddressViewModel>> Execute(Guid personKey);
    }
}