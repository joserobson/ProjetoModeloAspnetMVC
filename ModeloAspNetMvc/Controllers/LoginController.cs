using ModeloAspNetMvc.Models.Login;
using System.Web.Mvc;

namespace ModeloAspNetMvc.Controllers
{
    public class LoginController : Controller
    {

        public static string LOGIN_SESSION_NOME_USUARIO = "NomeUsuario";
        public static string LOGIN_SESSION_SENHA_USUARIO = "SenhaUsuario";

        // GET: Login
        public ActionResult Index()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Logar(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            Session[LOGIN_SESSION_NOME_USUARIO] = model.Usuario;
            Session[LOGIN_SESSION_SENHA_USUARIO] = model.Senha;

            return RedirectToAction("Index", "Venda");
        }


        public ActionResult LogOff()
        {
            Session.Remove(LOGIN_SESSION_NOME_USUARIO);
            Session.Remove(LOGIN_SESSION_SENHA_USUARIO);

            return View("Index");
        }
    }
}