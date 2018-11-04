using POC.EntityFramework.OData.Domain.Models;
using System.Threading.Tasks;

namespace POC.EntityFramework.OData.Domain.Commands
{
    /// <summary>
    /// Comando de criação de pessoa
    /// </summary>
    public interface ICreatePersonCommand
    {
        /// <summary>
        /// Modelo de criação de pessoa.
        /// </summary>
        /// <value></value>
        CreatePersonModel Model { get; set; }

        /// <summary>
        /// Método de execução do comando
        /// </summary>
        /// <returns>Pesso acriada.</returns>
        Task<CreatePersonViewModel> Execute();
    }
}