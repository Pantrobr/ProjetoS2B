using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoS2B.Models;

namespace ProjetoS2B.Controllers
{
    public class HomeController : Controller
    {
        DataBaseContext db = new DataBaseContext();

        public ActionResult Index()
        {
            List<Produto> lista = new List<Produto>();
            List<Produto> disponiveis = new List<Produto>();
            lista = db.Produtos.ToList();
            foreach (Produto d in lista)
            {
                if (d.Disponivel == true)
                {
                    disponiveis.Add(d);
                }
            }
            return View(disponiveis);
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