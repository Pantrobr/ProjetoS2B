using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace eCommerceS2B_2016.Models
{
    public class Compras
    {
        #region "Atributos"

        #endregion

        #region "Construtores"
        public Compras(Vendas venda, User comprador)
        {
            this.DataDaCompra = DateTime.Now;
            this.IdComprador = comprador.UserID;
            this.IdVendedor = venda.IdVendedor;
            this.IdProduto = venda.IdProduto;
        }
        #endregion

        #region "Propriedades"
        [Key]
        public int CompraID { get; set; }

        public int IdProduto { get; set; }
        public int IdVendedor { get; set; }
        public int IdComprador { get; set; }
        public DateTime DataDaCompra { get; private set; }
        #endregion

        #region "Métodos"

        #endregion
    }
}