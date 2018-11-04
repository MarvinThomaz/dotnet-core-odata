using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using POC.EntityFramework.OData.Domain.Services;

namespace POC.EntityFramework.OData.Controllers.OData
{
    /// <summary>
    /// Controller de busca de dados de endereço utilizando o protocolo odata.
    /// </summary>
    [Route("odata/addresses")]
    public class AddressesController : ODataController
    {
        private readonly IAddressApplicationService _service;

        /// <summary>
        /// Construtor do controller
        /// </summary>
        /// <param name="service">Serviço de gerênciamento de endereços.</param>
        public AddressesController(IAddressApplicationService service)
        {
            _service = service;
        }

        /// <summary>
        /// Método que busca todos os endereços da base e possibilita o filtro via odata.
        /// </summary>
        /// <returns>Listagem de endereços.</returns>
        [HttpGet]
        [EnableQuery]
        public async Task<IActionResult> Get()
        {
            var result = await _service.GetAddresses();

            return Ok(result);
        }
    }
}