using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace eCommerceS2B_2016.Models
{
    /// <summary>
    /// Classe serve para instanciar um usuário que podera comprar ou vender produtos
    /// </summary>
    public class User : Pessoa
    {
        #region "Atributos"
        public enum qualificacao { Negativo, Neutro, Positivo};
        public List<Vendas> vendas;
        public List<Compras> compras;
        #endregion

        #region "Construtor"
        public User(string nome, string sobrenome, string cpf, string login, string senha) : base(nome, sobrenome, cpf, login, senha)
        {
            NroCompras = 0;
            NroVendas = 0;
            NroLikes = 0;
            NroDislikes = 0;
            Rating = qualificacao.Neutro;
        }
        #endregion

        #region "Propriedades"
        public byte[] Imagem { get; set; }

        [Key]
        public int UserID { get; set; }

        public int NroVendas { get; set; }

        public int NroCompras { get; set; }

        public int NroLikes { get; set; }
        public int NroDislikes { get; set; }

        public qualificacao Rating { get; private set; }

        public List<Compras> ListaDeCompras { get; }
        public List<Vendas> ListaDeVendas { get; }


        #endregion

        #region "Métodos"
        //Serve para incrementar o Likes usado para calcular o Rating
        public void RecebeLike()
        {
            this.NroLikes += 1; 
        }

        //Serve para incrementar o Dislikes usado para calcular o Rating
        public void RecebeDislike()
        {
            this.NroDislikes += 1;
        }

        //Serve para calcular o Rating
        public qualificacao CalculaRating()
        {
            if (NroLikes > NroDislikes)
            {
                return qualificacao.Positivo;
            } else if (NroLikes == NroDislikes)
            {
                return qualificacao.Neutro;
            } else
            {
                return qualificacao.Negativo;
            }
        }

        //Serve para adicionar uma venda na sua List de vendas
        public void NovaVenda(Vendas nova)
        {
            vendas.Add(nova);
        }

        //Serve para adcionar uma nova compra na sua List de compras
        public void NovaCompra(Compras nova)
        {
            compras.Add(nova);
        }
        #endregion
        

    }
}