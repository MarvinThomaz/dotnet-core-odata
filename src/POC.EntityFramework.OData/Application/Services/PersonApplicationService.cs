using System.Collections.Generic;
using System.Threading.Tasks;
using POC.EntityFramework.OData.Domain.Commands;
using POC.EntityFramework.OData.Domain.Models;
using POC.EntityFramework.OData.Domain.Queries;
using POC.EntityFramework.OData.Domain.Services;

namespace POC.EntityFramework.OData.Application.Services
{
    /// <summary>
    /// Serviço de gerênciamento de pessoas.
    /// </summary>
    public class PersonApplicationService : IPersonApplicationService
    {
        private readonly ICreatePersonCommand _command;
        private readonly IGetPersonsQuery _query;

        /// <summary>
        /// Construtor do serviço.
        /// </summary>
        /// <param name="command">Comando de criação de pessoa.</param>
        /// <param name="query">Query de busca de pessoas.</param>
        public PersonApplicationService(ICreatePersonCommand command, IGetPersonsQuery query)
        {
            _command = command;
            _query = query;
        }

        /// <summary>
        /// Método de criação de pessoa
        /// </summary>
        /// <param name="request">Dados de pessoa.</param>
        /// <returns>Pessoa criada.</returns>
        public async Task<CreatePersonViewModel> CreatePerson(CreatePersonModel request)
        {
            _command.Model = request;

            return await _command.Execute();
        }

        /// <summary>
        /// Método de busca de pessoas.
        /// </summary>
        /// <returns>Listagem de pessoas.</returns>
        public async Task<IEnumerable<GetPersonsViewModel>> GetPersons()
        {
            return await _query.Execute();
        }
    }
}