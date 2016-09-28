using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eCommerceS2B_2016.Models
{
    public abstract class Pessoa
    {
        #region "Atributos"

        #endregion

        #region "Construtores"
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

        }
        #endregion
    }
}