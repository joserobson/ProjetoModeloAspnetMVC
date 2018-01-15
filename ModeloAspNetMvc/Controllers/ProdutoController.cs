using System.Web.Mvc;

namespace ModeloAspNetMvc.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Relatorio()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GerarRelatorio()
        {
            return View("OK");
        }
    }
}