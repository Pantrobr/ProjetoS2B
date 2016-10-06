using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace eCommerceS2B_2016.Models
{
    public class Admin : Pessoa
    {
        #region "Atributos"
        public List<DateTime> loginDatas;
        #endregion

        #region "Construtores"
        public Admin(string nome, string sobrenome, string cpf, string login, string senha) : base(nome, sobrenome, cpf, login, senha)
        {
            loginDatas = new List<DateTime>();
        }
        #endregion

        #region "Propriedades"
        [Key]
        public int AdminID { get; set; }

        public List<DateTime> LogIn { get; }
        #endregion

        #region "Métodos"
        public void Logou()
        {
            loginDatas.Add(DateTime.Now);
        }
        #endregion
        //branche 0.1  
    }
}