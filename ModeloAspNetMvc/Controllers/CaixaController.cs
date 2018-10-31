using AutoMapper;
using log4net;
using ModeloAspNetMvc.Models.Caixa;
using PagedList;
using Project.Layer.App.AppServices;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Mvc;

namespace ModeloAspNetMvc.Controllers
{
    public class CaixaController : Controller
    {
        private ICaixaAppRestService _caixaAppService;
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private const int paginaTamanho = 10;

        public CaixaController(ICaixaAppRestService caixaAppService)
        {
            this._caixaAppService = caixaAppService;
        }               

        public ActionResult FechamentoDiario(TelaFechamentoDiarioModel model, int? page)
        {
            log.Info("Buscar Fechametnos Diarios");
            var pageNumber = page ?? 1;
            var totalLinhas = 0;           


            IEnumerable<FechamentoDiarioModel> dados = new List<FechamentoDiarioModel>();

            if (model == null || string.IsNullOrEmpty(model.FiltroDia))
            {
                var diaFechamento = string.Empty;
                totalLinhas = _caixaAppService.CountObterFechamentosDoDia(diaFechamento);
                dados = Mapper.Map<IEnumerable<FechamentoDiarioModel>>(_caixaAppService.ObterFechamentosDoDia(diaFechamento,pageNumber, paginaTamanho));
            }
            else
            {
                totalLinhas = _caixaAppService.CountObterFechamentosDoDia(model.FiltroDia);
                dados = Mapper.Map<IEnumerable<FechamentoDiarioModel>>(_caixaAppService.ObterFechamentosDoDia(model.FiltroDia, pageNumber, paginaTamanho));
            }


            IPagedList<FechamentoDiarioModel> pageOrders = new StaticPagedList<FechamentoDiarioModel>(dados, pageNumber, paginaTamanho, totalLinhas);

            return View(new TelaFechamentoDiarioModel
            {
                Fechamentos = pageOrders,
                FiltroDia = model.FiltroDia,
                TotalItemCount = 10
            });
        }

        public ActionResult ExibirEntradasDoDia(int id)
        {
            var entradas = _caixaAppService.ObterEntradasDoCaixa(id);

            return PartialView("_MovimentosDoCaixa", Mapper.Map<IEnumerable<MovimentoCaixaModel>>(entradas));
        }

        public ActionResult ExibirSaidasDoDia(int id)
        {
            var saidas = _caixaAppService.ObterRetiradasDoCaixa(id);

            return PartialView("_MovimentosDoCaixa", Mapper.Map<IEnumerable<MovimentoCaixaModel>>(saidas));
        }
    }
}