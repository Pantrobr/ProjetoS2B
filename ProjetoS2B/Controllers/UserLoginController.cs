using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoS2B.Models;
using System.Web.Security;

namespace ProjetoS2B.Controllers
{
    public class UserLoginController : Controller
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(Usuario user)
        {
           Usuario user1 = db.Usuarios.FirstOrDefault(u => u.Login == user.Login);
           // if (ModelState.IsValid)
            //{
                if (IsValid(user.Login, user.Senha))
                {
                Session["UserID"] = user1.UserID.ToString();
                Session["Login"] = user.Login.ToString();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Login Falhou");
                }
            //}
            return View(user);
        }

        [HttpGet]
        public ActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registro([Bind(Include = "UserID,NroVendas,NroCompras,NroLikes,NroDislikes,Rating,Senha,SenhaRocks,Nome,Sobrenome,CPF,Login")]Usuario user)
        {
            if (ModelState.IsValid)
            {
                var crypto = new SimpleCrypto.PBKDF2();
                var encriptado = crypto.Compute(user.Senha);
                var dbUser = db.Usuarios.Create();
                //dbUser = user;
                dbUser.NroCompras = 0;
                dbUser.NroDislikes = 0;
                dbUser.NroVendas = 0;
                dbUser.NroLikes = 0;
                dbUser.Nome = user.Nome;
                dbUser.Sobrenome = user.Sobrenome;
                dbUser.Login = user.Login;
                dbUser.CPF = user.CPF;
                dbUser.Senha = encriptado;
                dbUser.SenhaRocks = crypto.Salt;
                db.Usuarios.Add(dbUser);
                db.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Registro inválido, confira seus dados");
            }
            return View();
        }

        public ActionResult LogOut()
        {
            Session["UserID"] = null;
            Session["Login"] = null;
            return RedirectToAction("Index", "Home");
        }

        private bool IsValid(string login, string senha)
        {
            bool valida = false;
            var crypto = new SimpleCrypto.PBKDF2();
            var user = db.Usuarios.FirstOrDefault(u => u.Login == login);
            if (user != null)
            {
                if (user.Senha == crypto.Compute(senha, user.SenhaRocks))
                {
                    valida = true;
                }
            }
            return valida;
        }

    }
}