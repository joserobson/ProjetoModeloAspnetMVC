using AutoMapper;
using ModeloAspNetMvc.Models.Venda;
using Project.Layer.App.AppServices;
using System.Web.Mvc;

namespace ModeloAspNetMvc.Controllers
{
    public class VendaController : Controller
    {

        private readonly IVendaAppService _vendaAppService;

        public VendaController(IVendaAppService vendaAppService)
        {
            _vendaAppService = vendaAppService;
        }

        // GET: Venda
        public ActionResult Index()
        {
            var balancoAppModel = _vendaAppService.ObterResumoFinanceiroMensal("");

            var balancoModel = Mapper.Map<ResumoFinanceiroMensalModel>(balancoAppModel);
            
            if (balancoModel == null)
            {
                balancoModel = new ResumoFinanceiroMensalModel();
            }

            return View("BalancoMensal", balancoModel);
        }
    }
}