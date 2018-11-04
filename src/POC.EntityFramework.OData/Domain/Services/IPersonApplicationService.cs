using POC.EntityFramework.OData.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POC.EntityFramework.OData.Domain.Services
{
    /// <summary>
    /// Serviço de gerênciamento de pessoas.
    /// </summary>
    public interface IPersonApplicationService
    {   
        /// <summary>
        /// Método de criação de pessoa
        /// </summary>
        /// <param name="request">Dados de pessoa.</param>
        /// <returns>Pessoa criada.</returns>
        Task<CreatePersonViewModel> CreatePerson(CreatePersonModel request);
        
        /// <summary>
        /// Método de busca de pessoas.
        /// </summary>
        /// <returns>Listagem de pessoas.</returns>
        Task<IEnumerable<GetPersonsViewModel>> GetPersons();
    }
}