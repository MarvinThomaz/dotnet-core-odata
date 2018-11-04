using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using POC.EntityFramework.OData.Domain.Entities;

namespace POC.EntityFramework.OData.Infrastructure.Context
{
    /// <summary>
    /// Contexto de gerênciamento de dados de pessoa.
    /// </summary>
    public class Context : DbContext
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Construtor do contexto.
        /// </summary>
        /// <param name="configuration">Configuração de aplicação</param>
        public Context(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Método de configuração de contexto.
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(_configuration.GetConnectionString("DefaultConnection"));

            base.OnConfiguring(optionsBuilder);
        }

        /// <summary>
        /// Método de configuração dos dados que serão persistidos.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>();
            modelBuilder.Entity<Address>();

            base.OnModelCreating(modelBuilder);
        }
    }
}