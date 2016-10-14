using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoS2B.Models;

namespace ProjetoS2B.Controllers
{
    public class AddProdutoController : Controller
    {
        // GET: AddProduto
        public ActionResult Index()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("LogIn", "UserLogin");
            }
        }

        [HttpPost]
        public ActionResult Index(Produto produto)
        {
            if(Session["UserID"] != null)
            {
                int id = Convert.ToInt32(Session["UserID"]);
                using(var db = new DataBaseContext())
                {
                    Usuario user = db.Usuarios.FirstOrDefault(u => u.UserID == id);
                    if(user != null)
                    {
                        user.NovaVenda(produto.Description, produto.Valor, produto.GeneroProduto, id);
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            else
            {
                return RedirectToAction("LogIn", "UserLogin");
            }
            return View(produto);
        }
    }
}