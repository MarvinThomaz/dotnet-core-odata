using System;
using System.Threading.Tasks;
using POC.EntityFramework.OData.Domain.Commands;
using POC.EntityFramework.OData.Domain.Entities;
using POC.EntityFramework.OData.Domain.Models;
using POC.EntityFramework.OData.Domain.Repositories;

namespace POC.EntityFramework.OData.Application.Commands
{
    /// <summary>
    /// Comando de criação de endereço
    /// </summary>
    public class CreateAddressCommand : ICreateAddressCommand
    {
        private readonly IAddressRepository _repository;

        /// <summary>
        /// Construtor do comando
        /// </summary>
        /// <param name="repository">Repositório de endereços.</param>
        public CreateAddressCommand(IAddressRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Modelo de criação de endereço
        /// </summary>
        /// <value></value>
        public CreateAddressModel Model { get; set; }

        /// <summary>
        /// Método de execução de comando.
        /// </summary>
        /// <param name="personKey">Chave da pessoa</param>
        /// <returns>Endereço criado.</returns>
        public async Task<CreateAddressViewModel> Execute(Guid personKey)
        {
            var address = new Address
            {
                Key = Guid.NewGuid(),
                Number = Model.Number,
                PersonKey = personKey,
                Street = Model.Street
            };

            await _repository.Create(address);

            return new CreateAddressViewModel
            {
                Key = address.Key,
                Number = address.Number,
                PersonKey = address.PersonKey,
                Street = address.Street
            };
        }
    }
}