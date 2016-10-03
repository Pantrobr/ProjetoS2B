using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Data.Entity;

namespace eCommerceS2B_2016.Models
{
    public abstract class Pessoa : DbContext
    {
        #region "Atributos"

        #endregion

        #region "Construtores"
        public Pessoa() { }
        /// <summary>
        /// Classe Pessoa é abstrata e define os elementos básicos que um registro de usuario ou administrador deve ter
        /// </summary>
        /// <param name="nome">Primeiro nome do cadastrado</param>
        /// <param name="sobrenome">Sobrenome do cadastrado</param>
        /// <param name="cpf">CPF - provavelmente terá alguma regra especifica de validação</param>
        /// <param name="login">o login deve ser um string do formato email@email.com</param>
        /// <param name="senha">string com o password</param>
        public Pessoa(string nome, string sobrenome, string cpf, string login, string senha)
        {
            this.Nome = nome;
            this.Sobrenome = sobrenome;
            this.CPF = cpf;
            this.Login = login;
            this.Senha = senha;
        }
        #endregion

        #region "Propriedades"
        [Required]
        [DisplayName("Primeiro Nome")]
        public string Nome { get; set; }

        [Required]
        [DisplayName("Sobrenome")]
        public string Sobrenome { get; set; }

        [Required]
        [StringLength(11,ErrorMessage ="CPF deve ter 11 caracteres",MinimumLength = 11)]
        public string CPF { get; set; }

        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage ="Formato de email errado deve ser ex: a@a.com ")]
        public string Login { get; set; }

        [Required]
        public string Senha { get; set; }
        #endregion

        #region "Métodos"

        #endregion
    }
}