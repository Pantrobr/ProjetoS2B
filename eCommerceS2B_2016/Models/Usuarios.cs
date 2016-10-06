using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace eCommerceS2B_2016.Models
{
    
    public class Usuarios : Pessoa
    {
        #region "Atributos"
        public enum qualificacao { Negativo, Neutro, Positivo};
        #endregion

        #region "Construtor"
        public Usuarios(): base() { }
        public Usuarios(string nome, string sobrenome, string cpf, string login, string senha) : base(nome, sobrenome, cpf, login, senha)
        {
            NroCompras = 0;
            NroVendas = 0;
            NroLikes = 0;
            NroDislikes = 0;
            Rating = qualificacao.Neutro;
        }
        #endregion

        #region "Propriedades"
        [Key]
        public int UserID { get; set; }

        public Arquivo Avatar { get; set; }

        public int NroVendas { get; set; }

        public int NroCompras { get; set; }

        public int NroLikes { get; set; }
        public int NroDislikes { get; set; }

        public qualificacao Rating { get; private set; }

        public IList<Compras> ListaDeCompras { get; set; }
        public IList<Vendas> ListaDeVendas { get; set; }

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
        public void NovaVenda(string descricaoProduto, string localVenda, decimal valorProduto, Genero gen)
        {
            
        }

        //Serve para adcionar uma nova compra na sua List de compras
        public void NovaCompra(Vendas nova)
        {
            Compras compra = new Compras(nova, this);
            this.ListaDeCompras.Add(compra);
            ProdutosContext ctx = new ProdutosContext();
            ctx.Compras.Add(compra);
            ctx.SaveChanges();
        }

        
        #endregion
        

    }
}