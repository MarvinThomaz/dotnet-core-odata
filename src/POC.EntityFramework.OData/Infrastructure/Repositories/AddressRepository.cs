using Microsoft.EntityFrameworkCore;
using POC.EntityFramework.OData.Domain.Entities;
using POC.EntityFramework.OData.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POC.EntityFramework.OData.Infrastructure.Repositories
{
    /// <summary>
    /// Repositório de endereço
    /// </summary>
    public class AddressRepository : IAddressRepository
    {
        private readonly Context.Context _context;

        /// <summary>
        /// Construtor do repositório.
        /// </summary>
        /// <param name="context">Contexto de acesso aos dados.</param>
        public AddressRepository(Context.Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Método de criação de endereço.
        /// </summary>
        /// <param name="person">Endereço a ser criado.</param>
        /// <returns></returns>
        public async Task Create(Address person)
        {
            await _context.AddAsync(person);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Método de busca de endereços
        /// </summary>
        /// <param name="personKey">Chave da pessoa</param>
        /// <returns>Listagem de endereços.</returns>
        public async Task<IEnumerable<Address>> Get(Guid personKey)
        {
            var addresses =  await _context.Set<Address>().ToListAsync();

            return addresses.Where(a => a.PersonKey == personKey);
        }

        /// <summary>
        /// Método de listagem de todos os endereços.
        /// </summary>
        /// <returns>Listagem de endereços</returns>
        public async Task<IEnumerable<Address>> Get()
        {
            return await _context.Set<Address>().ToListAsync();
        }
    }
}
