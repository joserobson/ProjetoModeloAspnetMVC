using ModeloAspNetMvc.Extensions;
using System;
using System.Web.Mvc;

namespace ModeloAspNetMvc.Controllers
{
    public class BaseController: Controller
    {
        protected override void OnException(ExceptionContext filterContext)
        {
            var logger = NLog.LogManager.GetCurrentClassLogger();
            logger.Error(filterContext.Exception, filterContext.Exception.Message);

            if (filterContext.Exception is Exception)
            {
                this.AddNotification(filterContext.Exception.Message, NotificationType.WARNING);
            }
            else
            {
                this.AddNotification("Tivemos um probleminha, entre em contato como Adm do Sistema", NotificationType.ERROR);
            }

            filterContext.ExceptionHandled = true;
            var action = this.ControllerContext.RouteData.Values["action"].ToString();
            filterContext.Result = RedirectToAction(action);

        }
    }
}