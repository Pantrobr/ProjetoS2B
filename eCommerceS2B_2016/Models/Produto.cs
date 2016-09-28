using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace eCommerceS2B_2016.Models
{
    public enum Genero { Automovel, Livro, Eletronico, Decoracao, Outros }; 
    public class Produto
    {
        #region "Atributos"

        #endregion

        #region "Construtores"
        /// <summary>
        /// Classe Produto serve para instanciar um produto - Produto ira servir para as classes Compras e Vendas
        /// </summary>
        /// <param name="vendedor">recebe um User</param>
        /// <param name="genero">Um Genero é um tipo enum descrito no neste namespace</param>
        /// <param name="descr">String com a descrição do produto</param>
        /// <param name="valor">Recebe um decimal com o valor</param>
        public Produto(User vendedor, Genero genero, string descr, decimal valor)
        {
            this.IdVendedor = vendedor.UserID;
            this.GeneroProduto = genero;
            this.Description = descr;
            this.Valor = valor;
        }
        #endregion

        #region "Propriedades"
        [Key]
        public int ProdutoID { get; set; }
        public byte[] Imagem { get; set; }
        public int IdVendedor { get; set; }
        public Genero GeneroProduto { get; set; }
        public string Description { get; set; }

        [Required]
        [Range(0.01,100.0,ErrorMessage ="Valor deve estar entre R$ 0,01 e R$ 100,00")]
        public decimal Valor { get; set; }


        #endregion

        #region "Métodos"

        #endregion
    }
}