using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using POC.EntityFramework.OData.Domain.Services;

namespace POC.EntityFramework.OData.Controllers.OData
{
    /// <summary>
    /// Controller de consulta de pessoas com possibilidade de filtros odata.
    /// </summary>
    [Route("odata/persons")]
    public class PersonsController : ODataController
    {
        private readonly IPersonApplicationService _service;

        /// <summary>
        /// Construtor do controller
        /// </summary>
        /// <param name="service">Serviço de gerênciamento de pessoas.</param>
        public PersonsController(IPersonApplicationService service)
        {
            _service = service;
        }

        /// <summary>
        /// Método de busca de pessoas com possibilidade de filtro odata.
        /// </summary>
        /// <returns>Listagem de pessoas.</returns>
        [HttpGet]
        [EnableQuery]
        public async Task<IActionResult> Get()
        {
            var result = await _service.GetPersons();

            return Ok(result);
        }
    }
}