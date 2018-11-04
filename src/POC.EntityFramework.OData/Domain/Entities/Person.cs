using System;
using System.ComponentModel.DataAnnotations;

namespace POC.EntityFramework.OData.Domain.Entities
{
    /// <summary>
    /// Classe de representação de pessoa.
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Chave de identificação de pessoa.
        /// </summary>
        /// <value></value>
        [Key]
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