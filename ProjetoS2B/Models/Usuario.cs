using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoS2B.Models
{
    public class Usuario : Pessoa
    {
        #region "Atributos"
        public enum qualificacao { Negativo, Neutro, Positivo };
        #endregion

        #region "Construtor"
        public Usuario(): base() { }
        public Usuario(string nome, string sobrenome, string cpf, string email, string senha) : base(nome, sobrenome, cpf, email)
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
        
        [Required]
        [DataType(DataType.Password)]
        [StringLength(250, MinimumLength = 6)]
        public string Senha { get; set; }

        public string SenhaRocks { get; set; }

        public ICollection<Produto> Venda { get; set; }
        public ICollection<Produto> Compra { get; set; }

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
            }
            else if (NroLikes == NroDislikes)
            {
                return qualificacao.Neutro;
            }
            else
            {
                return qualificacao.Negativo;
            }
        }

        //Serve para adicionar uma venda na sua List de vendas
        public void NovaVenda(string descricaoProduto, string localVenda, string descVenda, decimal valorProduto, Genero gen)
        {

        }

        //Serve para adcionar uma nova compra na sua List de compras
        public void NovaCompra(Produto vendido)
        {

        }

        #endregion

    }
}