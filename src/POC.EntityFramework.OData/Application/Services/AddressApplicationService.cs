using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using POC.EntityFramework.OData.Domain.Commands;
using POC.EntityFramework.OData.Domain.Models;
using POC.EntityFramework.OData.Domain.Queries;
using POC.EntityFramework.OData.Domain.Services;

namespace POC.EntityFramework.OData.Application.Services
{
    /// <summary>
    /// Serviço de gerênciamento de endereços.
    /// </summary>
    public class AddressApplicationService : IAddressApplicationService
    {
        private readonly ICreateAddressCommand _command;
        private readonly IGetAddressesByPersonQuery _getAddressesByPersonQuery;
        private readonly IGetAddressesQuery _getAddressesQuery;

        /// <summary>
        /// Construtor do serviço.
        /// </summary>
        /// <param name="command">Comando de criação de endereço.</param>
        /// <param name="getAddressesByPersonQuery">Query de busca de endereços por pessoa.</param>
        /// <param name="getAddressesQuery">Query de busca de endereços</param>
        public AddressApplicationService(ICreateAddressCommand command, IGetAddressesByPersonQuery getAddressesByPersonQuery, IGetAddressesQuery getAddressesQuery)
        {
            _command = command;
            _getAddressesByPersonQuery = getAddressesByPersonQuery;
            _getAddressesQuery = getAddressesQuery;
        }

        /// <summary>
        /// Método de criação de endereço.
        /// </summary>
        /// <param name="personKey">Chave da pessoa.</param>
        /// <param name="request">Dados de endereço</param>
        /// <returns>Endereço criado.</returns>
        public async Task<CreateAddressViewModel> CreateAddress(Guid personKey, CreateAddressModel request)
        {
            _command.Model = request;

            return await _command.Execute(personKey);
        }

        /// <summary>
        /// Método que busca todos os endereços.
        /// </summary>
        /// <returns>Listagem de endereços.</returns>
        public async Task<IEnumerable<GetAddressViewModel>> GetAddresses()
        {
            return await _getAddressesQuery.Execute();
        }

        /// <summary>
        /// Método de busca de endereços.
        /// </summary>
        /// <param name="personKey">Chave da pessoa.</param>
        /// <returns>Listagem de endereços.</returns>
        public async Task<IEnumerable<GetAddressViewModel>> GetAddressesByPerson(Guid personKey)
        {
            return await _getAddressesByPersonQuery.Execute(personKey);
        }
    }
}