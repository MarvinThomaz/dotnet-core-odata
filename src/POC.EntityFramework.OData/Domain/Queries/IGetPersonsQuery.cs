using POC.EntityFramework.OData.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POC.EntityFramework.OData.Domain.Queries
{
    /// <summary>
    /// Query de busca de pessoas.
    /// </summary>
    public interface IGetPersonsQuery
    {
        /// <summary>
        /// Método de exeução da query.
        /// </summary>
        /// <returns>Listagem de pessoas.</returns>
        Task<IEnumerable<GetPersonsViewModel>> Execute();
    }
}