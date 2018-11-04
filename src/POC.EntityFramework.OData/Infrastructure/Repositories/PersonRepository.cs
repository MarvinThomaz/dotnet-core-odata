using Microsoft.EntityFrameworkCore;
using POC.EntityFramework.OData.Domain.Entities;
using POC.EntityFramework.OData.Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POC.EntityFramework.OData.Infrastructure.Repositories
{
    /// <summary>
    /// Repositório de pessoas.
    /// </summary>
    public class PersonRepository : IPersonRepository
    {
        private readonly Context.Context _context;

        /// <summary>
        /// Construtor do repositório.
        /// </summary>
        /// <param name="context">Contexto de acesso aos dados.</param>
        public PersonRepository(Context.Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Método de criação de pessoa.
        /// </summary>
        /// <param name="person">Pessoa a ser criada</param>
        /// <returns></returns>
        public async Task Create(Person person)
        {
            await _context.AddAsync(person);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Método de listagem de pessoas.
        /// </summary>
        /// <returns>Listagem de pessoas.</returns>
        public async Task<IEnumerable<Person>> Get()
        {
            return await _context.Set<Person>().ToListAsync();
        }
    }
}
