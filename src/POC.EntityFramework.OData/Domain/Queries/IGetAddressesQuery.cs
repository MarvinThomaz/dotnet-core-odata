using System.Collections.Generic;
using System.Threading.Tasks;
using POC.EntityFramework.OData.Domain.Models;

namespace POC.EntityFramework.OData.Domain.Queries
{
    /// <summary>
    /// Consulta de endereços.
    /// </summary>
    public interface IGetAddressesQuery
    {
        /// <summary>
        /// Método de execução da consulta
        /// </summary>
        /// <returns>Listagem de endereços</returns>
         Task<IEnumerable<GetAddressViewModel>> Execute();
    }
}