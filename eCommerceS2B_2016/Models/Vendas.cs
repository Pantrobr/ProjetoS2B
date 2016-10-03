using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace eCommerceS2B_2016.Models
{
    public class Vendas
    {
        #region "Atributos"
        #endregion

        #region "Construtores"
        public Vendas() { }
        /// <summary>
        /// Clase Vendas serve para instanciar um novo produto a venda
        /// </summary>
        /// <param name="produto">Recebe o produto à venda</param>
        /// <param name="vendedor">Recebe um User</param>
        /// <param name="desc">Descrição da venda até 25 caracteres</param>
        /// <param name="local"></param>
        public Vendas(Produto produto, User vendedor, string desc, string local)
        {
            this.IdProduto = produto.ProdutoID;
            this.IdVendedor = vendedor.UserID;
            this.Status = true;
            this.Description = desc;
            this.DataDaPostagem = DateTime.Now;
            this.Local = local;
        }
        #endregion

        #region "Propriedades"
        [Key]
        public int VendasID { get; set; }

        public int IdProduto { get; private set; }
        public int IdVendedor { get; private set; }
        public int IdComprador { get; set; }

        [Required]
        [DisplayName("Titulo")]
        [StringLength(25, ErrorMessage ="Máximo 25 caracterres")]
        public string Description { get; set; }

        public bool Status { get; set; }

        [DisplayName("Endereço")]
        [StringLength(200, ErrorMessage ="Nomaximo 200 caracteres")]
        public string Local { get; set; }

        public DateTime DataDaVenda { get; set; }
        public DateTime DataDaPostagem { get; private set; }
        #endregion

        #region "Métodos"

        //Serve para vender ela muda o estatus da venda e guarda o id do comprador e a data da compra
        public void Vendeu(User comprador)
        {
            this.Status = false;
            this.DataDaVenda = DateTime.Now;
            IdComprador = comprador.UserID;
        }
        #endregion

    }
}