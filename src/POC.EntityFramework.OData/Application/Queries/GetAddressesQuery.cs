using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using POC.EntityFramework.OData.Domain.Models;
using POC.EntityFramework.OData.Domain.Queries;
using POC.EntityFramework.OData.Domain.Repositories;

namespace POC.EntityFramework.OData.Application.Queries
{
    /// <summary>
    /// Consulta de endereços.
    /// </summary>
    public class GetAddressesQuery : IGetAddressesQuery
    {
        private readonly IAddressRepository _repository;

        /// <summary>
        /// Construtor da consulta
        /// </summary>
        /// <param name="repository">Repositório de endereços.</param>
        public GetAddressesQuery(IAddressRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Método de execução da consulta
        /// </summary>
        /// <returns>Listagem de endereços</returns>
        public async Task<IEnumerable<GetAddressViewModel>> Execute()
        {
            var result = await _repository.Get();

            return result.Select(a => new GetAddressViewModel
            {
                Key = a.Key,
                PersonKey = a.PersonKey,
                Street = a.Street,
                Number = a.Number
            });
        }
    }
}