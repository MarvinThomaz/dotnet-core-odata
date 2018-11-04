using POC.EntityFramework.OData.Domain.Models;
using POC.EntityFramework.OData.Domain.Queries;
using POC.EntityFramework.OData.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POC.EntityFramework.OData.Application.Queries
{
    /// <summary>
    /// Query de busca de pessoas.
    /// </summary>
    public class GetPersonsQuery : IGetPersonsQuery
    {
        private readonly IPersonRepository _repository;

        /// <summary>
        /// Construtor da query.
        /// </summary>
        /// <param name="repository">Repositório de pessoas</param>
        public GetPersonsQuery(IPersonRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Método de exeução da query.
        /// </summary>
        /// <returns>Listagem de pessoas.</returns>
        public async Task<IEnumerable<GetPersonsViewModel>> Execute()
        {
            var result = await _repository.Get();

            return result.Select(p => new GetPersonsViewModel
            {
                Age = p.Age,
                Key = p.Key,
                Name = p.Name,
                Nickname = p.Nickname
            });
        }
    }
}
