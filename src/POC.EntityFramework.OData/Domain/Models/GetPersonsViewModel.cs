using System;

namespace POC.EntityFramework.OData.Domain.Models
{
    /// <summary>
    /// Modelo de busca de pessoa.
    /// </summary>
    public class GetPersonsViewModel
    {        
        /// <summary>
        /// Chave da pessoa.
        /// </summary>
        /// <value></value>
        public Guid Key { get; set; }

        /// <summary>
        /// Nome da pessoa.
        /// </summary>
        /// <value></value>
        public string Name { get; set; }

        /// <summary>
        /// Apelido da pessoa
        /// </summary>
        /// <value></value>
        public string Nickname { get; set; }

        /// <summary>
        /// Idade da pessoa.
        /// </summary>
        /// <value></value>
        public int Age { get; set; }
    }
}