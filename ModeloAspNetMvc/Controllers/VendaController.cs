using AutoMapper;
using ModeloAspNetMvc.ActionFilters;
using ModeloAspNetMvc.Models.Venda;
using Project.Layer.App.AppServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ModeloAspNetMvc.Controllers
{
    [BasicAuthenticationAttribute]
    public class VendaController : BaseController
    {

        private readonly IVendaAppRestService _vendaAppService;
        private readonly IFuncionarioAppService _funcionarioAppService;

        public VendaController(IVendaAppRestService vendaAppService, IFuncionarioAppService funcionarioAppService)
        {
            _vendaAppService = vendaAppService;
            _funcionarioAppService = funcionarioAppService;
        }

        // GET: Venda
        public ActionResult BalancoMensal(ResumoFinanceiroMensalModel model)
        {
            var mesAno = DateTime.Now.ToString("MM/yyyy");
            var balancoAppModel = _vendaAppService.ObterResumoFinanceiroMensal(mesAno);
            var balancoModel = Mapper.Map<ResumoFinanceiroMensalModel>(balancoAppModel);

            if (balancoModel == null)
            {
                balancoModel = new ResumoFinanceiroMensalModel();
            }

            balancoModel.FiltroMesAno = mesAno;

            return View(balancoModel);
        }

        public ActionResult DebitosAReceber()
        {
            var dataReferencia = DateTime.Now.ToString("dd/MM/yyyy");

            var appModel = _vendaAppService.ObterResumoDebitosAReceber(dataReferencia);
            var viewModel = Mapper.Map<ResumoDebitosAReceberModel>(appModel);

            if (viewModel == null)
            {
                viewModel = new ResumoDebitosAReceberModel { TotalEmDebitosAReceber = "0", TotalEmDebitosRetroativos = "0", ValorTotal = "0" };
            }

            viewModel.FiltroDataReferencia = dataReferencia;

            return View(viewModel);
        }

        [HttpPost]
        public JsonResult BuscarDebitosAReceber(string dataReferencia)
        {

            var appModel = _vendaAppService.ObterResumoDebitosAReceber(dataReferencia);

            var viewModel = Mapper.Map<ResumoDebitosAReceberModel>(appModel);

            if (viewModel == null)
            {
                viewModel = new ResumoDebitosAReceberModel();
            }

            return Json(viewModel);

        }

        [HttpPost]
        public JsonResult BuscarResumoMensalVendas(string mesAno)
        {
            var appModel = _vendaAppService.ObterResumoFinanceiroMensal(mesAno);
            var viewModel = Mapper.Map<ResumoFinanceiroMensalModel>(appModel);

            if (viewModel == null)
            {
                viewModel = new ResumoFinanceiroMensalModel();
            }

            return Json(viewModel);

        }

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

        public ActionResult VendasPorFuncionario()
        {
            var funcionarios = _funcionarioAppService.ObterTodosOsFuncionarios();                  

            return View(new VendaPorFuncionarioModel
            {
                DataInicio = $"01/{DateTime.Now.ToString("MM/yyyy")}",
                DataFim = DateTime.Now.ToString("dd/MM/yyyy"),
                SelectListFuncionarios = SelectListItemDeFuncionarios()
            });
        }

        [HttpPost]
        public ActionResult VendasPorFuncionario(VendaPorFuncionarioModel model)
        {           
            var resumo = _vendaAppService.ObterResumoDeVendasPorFuncionario(model.DataInicio, model.DataFim, model.IdFuncionario);
            model.ResumoDeVendas = Mapper.Map<IEnumerable<ResumoVendaPorFuncionarioModel>>(resumo);

            model.SelectListFuncionarios = SelectListItemDeFuncionarios();            

            return View(model);
        }
        
        private IEnumerable<SelectListItem> SelectListItemDeFuncionarios()
        {
            var funcionarios = _funcionarioAppService.ObterTodosOsFuncionarios();
            var selectListItemFuncionario = new List<SelectListItem>();
            selectListItemFuncionario.Add(new SelectListItem { Text = "TODOS", Value = "-1" });
            selectListItemFuncionario.AddRange(funcionarios.Select(f => new SelectListItem
            {
                Text = f.Nome,
                Value = f.Id
            }));

            return selectListItemFuncionario;
        }

        public ActionResult ResumoDePagamentosECaixa()
        {                       
            return View(new ResumoPagamentoCaixaModel
            {
                DataInicio = $"01/{DateTime.Now.ToString("MM/yyyy")}",
                DataFim = DateTime.Now.ToString("dd/MM/yyyy")
            });
        }

        [HttpPost]
        public ActionResult ResumoDePagamentosECaixa(ResumoPagamentoCaixaModel model)
        {

            var balancoAppModel = _vendaAppService.ObterResumoDosPagamentosEEntradasDoCaixa(model.DataInicio, model.DataFim);
            var balancoModel = Mapper.Map<ResumoPagamentoCaixaModel>(balancoAppModel);

            balancoModel.DataInicio = model.DataInicio;
            balancoModel.DataFim = model.DataFim;

            return View(balancoModel);
        }
    }
}