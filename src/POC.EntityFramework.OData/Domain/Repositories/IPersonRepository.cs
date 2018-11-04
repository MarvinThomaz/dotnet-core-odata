using POC.EntityFramework.OData.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POC.EntityFramework.OData.Domain.Repositories
{
    /// <summary>
    /// Repositório de pessoas.
    /// </summary>
    public interface IPersonRepository
    {
        /// <summary>
        /// Método de criação de pessoa.
        /// </summary>
        /// <param name="person">Pessoa a ser criada</param>
        /// <returns></returns>
        Task Create(Person person);

        /// <summary>
        /// Método de listagem de pessoas.
        /// </summary>
        /// <returns>Listagem de pessoas.</returns>
        Task<IEnumerable<Person>> Get();
    }
}