using AutoMapper;
using ModeloAspNetMvc.Models.Venda;
using Project.Layer.App.AppServices;
using System;
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
        public ActionResult BalancoMensal(ResumoFinanceiroMensalModel model)
        {
            var mesAno = DateTime.Now.ToString("MM/yyyy");
            var balancoAppModel = _vendaAppService.ObterResumoFinanceiroMensal(mesAno);
            var balancoModel = Mapper.Map<ResumoFinanceiroMensalModel>(balancoAppModel);
            balancoModel.FiltroMesAno = mesAno;

            return View(balancoModel);
        }

        public ActionResult DebitosAReceber()
        {
            var dataReferencia = DateTime.Now.ToString("dd/MM/yyyy");

            var appModel = _vendaAppService.ObterResumoDebitosAReceber(dataReferencia);
            var viewModel = Mapper.Map<ResumoDebitosAReceberModel>(appModel);
            viewModel.FiltroDataReferencia = dataReferencia;

            return View(viewModel);
        }

        [HttpPost]
        public JsonResult BuscarDebitosAReceber(string dataReferencia)
        {

            var appModel = _vendaAppService.ObterResumoDebitosAReceber(dataReferencia);

            var viewModel = Mapper.Map<ResumoDebitosAReceberModel>(appModel);

            return Json(viewModel);

        }

        [HttpPost]
        public JsonResult BuscarResumoMensalVendas(string mesAno)
        {
            var appModel = _vendaAppService.ObterResumoFinanceiroMensal(mesAno);
            var viewModel = Mapper.Map<ResumoFinanceiroMensalModel>(appModel);

            return Json(viewModel);

        }
    }
}