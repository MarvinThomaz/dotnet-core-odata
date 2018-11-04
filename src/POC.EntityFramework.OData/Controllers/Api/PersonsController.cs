using Microsoft.AspNetCore.Mvc;
using POC.EntityFramework.OData.Domain.Models;
using POC.EntityFramework.OData.Domain.Services;
using System.Threading.Tasks;

namespace POC.EntityFramework.OData.Controllers
{
    /// <summary>
    /// Classe que gerência os dados de uma pessoa.
    /// </summary>
    [Route("api/persons")]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonApplicationService _service;

        /// <summary>
        /// Construtor da classe utilizando o serviço da aplicação.
        /// </summary>
        /// <param name="service">Serviço da aplicação</param>
        public PersonsController(IPersonApplicationService service)
        {
            _service = service;
        }

        /// <summary>
        /// Método de criação de pessoa.
        /// </summary>
        /// <param name="request">Dados para criação da pessoa.</param>
        /// <returns>Pessoa criada.</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreatePersonModel request)
        {
            var result = await _service.CreatePerson(request);

            return Ok(result);
        }

        /// <summary>
        /// Método de busca de pessoa com possibilidade de query odata.
        /// </summary>
        /// <returns>Listagem de pessoas.</returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _service.GetPersons();

            return Ok(result);
        }
    }
}