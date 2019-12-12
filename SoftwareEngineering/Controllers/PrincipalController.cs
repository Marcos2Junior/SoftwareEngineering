using SoftwareEngineering.Business;
using SoftwareEngineering.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace SoftwareEngineering.Controllers
{
    public class PrincipalController : Controller
    {
        DAL obj = new DAL();
        // GET: Principal
        [HttpGet]
        public ActionResult Index(string visualizar)
        {
            if (string.IsNullOrEmpty(visualizar))
            {
                return View(obj.RetornaSalasDestaques());
            }
            else
            {
                ViewBag.Visualizar = visualizar;
                return View();
            }
        }

        [HttpGet]
        public ActionResult Home(int idSala, string banir, string excluir, string sair)
        {
            try
            {
                if(!string.IsNullOrEmpty(sair))
                {
                    obj.ExcluiUsuarioSala(idSala, sair);
                    ViewBag.Action = "Excluir";
                    return View();
                }
                else if(!string.IsNullOrEmpty(excluir))
                {
                    obj.ExcluirSala(idSala);
                    ViewBag.Action = "Excluir";
                    return View();
                }

                EnviaMsg msg = new EnviaMsg();

                obj.GravaUsuarioSala(Session["usuario"].ToString(), idSala);
                msg.IdSala = idSala;
                msg.IdUsuario = Session["usuario"].ToString();
                if (!string.IsNullOrEmpty(banir))
                    obj.ExcluiUsuarioSala(idSala, banir);

                return View(msg);
            }
            catch (Exception)
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Home(EnviaMsg msg)
        {

            if (msg.Mensagem == null)
            {
                return View(msg);
            }
            else
            {
                try
                {
                    msg.IdUsuario = Session["usuario"].ToString();
                    msg.DataMensagem = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    msg.sequencia = obj.verificaSequenciaMsg(msg.IdSala);
                    obj.EnviaMsg(msg);
                    return View(msg);
                }
                catch (Exception)
                {
                    return View();
                }
            }
        }

        public ActionResult NovaSala()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NovaSala(Sala sala, HttpPostedFileBase upload)
        {
            ModelState.Clear();
            sala.DataInicio = DateTime.Now;
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(upload.FileName);
                    upload.SaveAs(Path.Combine(AppDomain.CurrentDomain.BaseDirectory.ToString() + "//images", sala.Id.ToString() + fileName));
                    sala.Image = sala.Id.ToString() + fileName;

                }
                try
                {
                    sala.Usuario = Session["usuario"].ToString();
                    sala.Id = obj.GravarSala(sala);
                    
                    return View(sala);
                }
                catch (Exception)
                {
                    return View();
                }
                
            }
            else
                return View();
        }
        [HttpGet]
        public ActionResult Perfil(string usuario)
        {
            Usuario user = new Usuario();
           user = obj.RetornaUsuario(usuario);
            return View(user);
        }

        [HttpGet]
        public ActionResult AlterarPerfil(string usuario)
        {
            Usuario user = new Usuario();
            user = obj.RetornaUsuario(usuario);
            return View(user);
        }

        [HttpPost]
        public ActionResult AlterarPerfil(Usuario usuario, HttpPostedFileBase upload)
        {
            if (upload != null && upload.ContentLength > 0)
            {
                var fileName = Path.GetFileName(upload.FileName);
                upload.SaveAs(Path.Combine(AppDomain.CurrentDomain.BaseDirectory.ToString() + "//images", usuario.Id.ToString() + fileName));
                usuario.Image = fileName;

            }

            obj.AtualizaUsuario(usuario);

            

            usuario = obj.RetornaUsuario(usuario.Nome);
            Session["usuario"] = usuario.Nome;
            return View(usuario);
        }




    }
}