using Microsoft.AspNetCore.Mvc;
using POC.EntityFramework.OData.Domain.Models;
using POC.EntityFramework.OData.Domain.Services;
using System;
using System.Threading.Tasks;

namespace POC.EntityFramework.OData.Controllers
{
    /// <summary>
    /// Controller de gerênciamento de endereços.
    /// </summary>
    [Route("api/persons/{personKey}/addresses")]
    public class AddressesController : ControllerBase
    {
        private readonly IAddressApplicationService _service;

        /// <summary>
        /// Contrutor que recebe o serviço de aplicação.
        /// </summary>
        /// <param name="service"></param>
        public AddressesController(IAddressApplicationService service)
        {
            _service = service;
        }

        /// <summary>
        /// Método de criação de endereço para uma pessoa.
        /// </summary>
        /// <param name="personKey">Chave da pessoa</param>
        /// <param name="request">Dados do endereço.</param>
        /// <returns>Endereço criado.</returns>
        [HttpPost]
        public async Task<IActionResult> Post(Guid personKey, [FromBody] CreateAddressModel request)
        {
            var result = await _service.CreateAddress(personKey, request);

            return Ok(result);
        }

        /// <summary>
        /// Método de busca de endereços de uma pessoa.
        /// </summary>
        /// <param name="personKey">Chave da pessoa</param>
        /// <returns>Listagem de endereços</returns>
        [HttpGet]
        public async Task<IActionResult> Get(Guid personKey)
        {
            var result = await _service.GetAddressesByPerson(personKey);

            return Ok(result);
        }
    }
}