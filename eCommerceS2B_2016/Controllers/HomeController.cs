using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eCommerceS2B_2016.Models;
using Usuario = eCommerceS2B_2016.Models.User;

namespace eCommerceS2B_2016.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var ctx = new Models.ProdutosContext())
            {
                Usuario user = new Usuario("primeiro", "user", "12569874656", "primeiro@1.com", "12345");
                Produto p1 = new Produto(user, Genero.Outros, "sem descrição", 10.2m);
                Vendas v1 = new Vendas(p1, user, "esta venda nao tem descriçao", "sem local");
                Compras c1 = new Compras(v1, user);
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}