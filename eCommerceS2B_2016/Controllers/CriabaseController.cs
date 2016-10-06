using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eCommerceS2B_2016.Models;
using Usuario = eCommerceS2B_2016.Models.Usuarios;

namespace eCommerceS2B_2016.Controllers
{
    public class CriabaseController : Controller
    {
        // GET: Criabase
        public string Index()
        {
            using (var ctx = new Models.ProdutosContext())
            {
                Usuario user = new Usuario("primeiro", "user", "12569874656", "primeiro@1.com", "12345");
                Usuario user1 = new Usuario("segundo", "user", "65897456325", "SEGUNDO@1.com", "98745");
                //Vendas v1 = new Vendas("primeira");
                //Vendas v2 = new Vendas("segunda");
                //Vendas v3 = new Vendas("terceira");
                //Vendas v4 = new Vendas("quarta");
                //ctx.Vendas.Add(v1);
                //ctx.Vendas.Add(v2);
                //ctx.Vendas.Add(v3);
                //ctx.Vendas.Add(v4);
                //ctx.SaveChanges();
                ctx.Usuarios.Add(user);
                ctx.Usuarios.Add(user1);
                ctx.SaveChanges();
                user.NovaVenda("Toalha de Banho", "Porto Alegre", 12.2m, Genero.Outros);
                user1.NovaVenda("Lapis vermelho", "Canoas",2.2m,Genero.Outros);

            }
            return "Base criada!";
        }
    }
}