using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Livraria.Sistema.Models;
using System.Data.SqlClient;

namespace Livraria.Sistema.Controllers
{
    public class LoginController : Controller
    {
        
        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Verificacao(Livraria.Sistema.Models.FUNCIONARIOS funcionario)
        {
            using (BDLIVRARIAEntities db = new BDLIVRARIAEntities())
            {
                var userDetails = db.FUNCIONARIOS.Where(x => x.USERNAME == funcionario.USERNAME && x.SENHA == funcionario.SENHA).FirstOrDefault();
                if (userDetails == null)
                {
                    funcionario.LoginErrorMessage = "Senha e/ou username incorretos.";
                    return View("Login", funcionario);
                }
                else
                {
                    Session["IDFUNCIONARIOS"] = userDetails.IDFUNCIONARIOS;
                    Session["USERNAME"] = userDetails.USERNAME;
                    return RedirectToAction("Index", "Livros");
                }
            }
          
        }
    }
}