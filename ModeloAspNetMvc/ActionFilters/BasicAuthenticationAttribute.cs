using ModeloAspNetMvc.Controllers;
using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace ModeloAspNetMvc.ActionFilters
{
    public class BasicAuthenticationAttribute : ActionFilterAttribute
    {
        public string BasicRealm { get; set; }
        protected string Username { get; set; }
        protected string Password { get; set; }

        public BasicAuthenticationAttribute()
        {
            this.Username = "admin";
            this.Password = "comfacil";
        }
        //public BasicAuthenticationAttribute(string username, string password)
        //{
        //    this.Username = username;
        //    this.Password = password;
        //}

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            var nomeUsuario = filterContext.HttpContext.Session[LoginController.LOGIN_SESSION_NOME_USUARIO]?.ToString();
            var senhaUsuario = filterContext.HttpContext.Session[LoginController.LOGIN_SESSION_SENHA_USUARIO]?.ToString();

            if (!string.IsNullOrEmpty(nomeUsuario) && !string.IsNullOrEmpty(senhaUsuario))
            {
                var user = new { Name = nomeUsuario, Pass = senhaUsuario };
                if (user.Name == Username && user.Pass == Password) return;
            }

            //var req = filterContext.HttpContext.Request;
            //var auth = req.Headers["Authorization"];
            //if (!String.IsNullOrEmpty(auth))
            //{
            //    var cred = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(auth.Substring(6))).Split(':');
            //    var user = new { Name = cred[0], Pass = cred[1] };
            //    if (user.Name == Username && user.Pass == Password) return;
            //}
            //filterContext.HttpContext.Response.AddHeader("WWW-Authenticate", String.Format("Basic realm=\"{0}\"", BasicRealm ?? "Ryadel"));
            /// thanks to eismanpat for this line: https://www.ryadel.com/en/http-basic-authentication-asp-net-mvc-using-custom-actionfilter/#comment-2507605761
            //filterContext.Result = new HttpUnauthorizedResult();

            //filterContext.Result = new RedirectResult("/login");

            filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary
                {
                    {"controller", "Login"},
                    {"action", "Index"}
                }
            );
            return;
        }
    }
}