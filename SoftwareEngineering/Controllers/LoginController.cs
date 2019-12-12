using SoftwareEngineering.Business;
using SoftwareEngineering.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SoftwareEngineering.Controllers
{
    public class LoginController : Controller
    {
        // GET: Cadastro
        [HttpGet]
        public ActionResult Novo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Novo(Usuario usuario, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(upload.FileName);
                    upload.SaveAs(Path.Combine(AppDomain.CurrentDomain.BaseDirectory.ToString() + "//images", usuario.Id.ToString() + fileName));
                    usuario.Image = usuario.Id.ToString() + fileName;

                }

                DAL obj = new DAL();
                obj.GravarUsuario(usuario);
                return View(usuario);
            }
            else
                return View();
        }

        [HttpGet]
        public ActionResult Entrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Entrar(Usuario usuario)
        {
            DAL obj = new DAL();
            usuario.Nome = usuario.Nome.ToUpper();
            if (obj.VerificaLogin(usuario))
            {
                return View(usuario);
            }
            else
                return View();
        }

        [HttpGet]
        public ActionResult NovaSenha()
        {

            return View();
        }

        [HttpPost]
        public ActionResult NovaSenha(Usuario usuario)
        {

            return View(usuario);
        }


    }
}