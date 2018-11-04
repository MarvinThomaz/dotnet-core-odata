using POC.EntityFramework.OData.Domain.Models;
using POC.EntityFramework.OData.Domain.Queries;
using POC.EntityFramework.OData.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POC.EntityFramework.OData.Application.Queries
{
    /// <summary>
    /// Query de busca de endereços.
    /// </summary>
    public class GetAddressesByPersonQuery : IGetAddressesByPersonQuery
    {
        private readonly IAddressRepository _repository;

        /// <summary>
        /// Construtor da query.
        /// </summary>
        /// <param name="repository">Repositório de endereços.</param>
        public GetAddressesByPersonQuery(IAddressRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Método de execução da query.
        /// </summary>
        /// <param name="personKey">Chave da pessoa.</param>
        /// <returns>Listagem de endereços</returns>
        public async Task<IEnumerable<GetAddressViewModel>> Execute(Guid personKey)
        {
            var result = await _repository.Get(personKey);

            return result.Select(p => new GetAddressViewModel
            {
                Key = p.Key,
                Number = p.Number,
                PersonKey = p.PersonKey,
                Street = p.Street
            });
        }
    }
}
