using System;
using System.Threading.Tasks;
using POC.EntityFramework.OData.Domain.Commands;
using POC.EntityFramework.OData.Domain.Entities;
using POC.EntityFramework.OData.Domain.Models;
using POC.EntityFramework.OData.Domain.Repositories;

namespace POC.EntityFramework.OData.Application.Commands
{
    /// <summary>
    /// Comando de criação de pessoa
    /// </summary>
    public class CreatePersonCommand : ICreatePersonCommand
    {
        private readonly IPersonRepository _repository;

        /// <summary>
        /// Construtor do comando.
        /// </summary>
        /// <param name="repository">Repositório de pessoas</param>
        public CreatePersonCommand(IPersonRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Modelo de criação de pessoa.
        /// </summary>
        /// <value></value>
        public CreatePersonModel Model { get; set; }

        /// <summary>
        /// Método de execução do comando
        /// </summary>
        /// <returns>Pesso acriada.</returns>
        public async Task<CreatePersonViewModel> Execute()
        {
            var person = new Person
            {
                Age = Model.Age,
                Key = Guid.NewGuid(),
                Name = Model.Name,
                Nickname = Model.Nickname
            };

            await _repository.Create(person);

            return new CreatePersonViewModel
            {
                Age = person.Age,
                Key = person.Key,
                Name = person.Name,
                Nickname = person.Nickname
            };
        }
    }
}