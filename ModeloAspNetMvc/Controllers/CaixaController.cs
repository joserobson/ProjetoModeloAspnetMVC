using AutoMapper;
using log4net;
using ModeloAspNetMvc.Models.Caixa;
using PagedList;
using Project.Layer.App.AppServices;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Mvc;

namespace ModeloAspNetMvc.Controllers
{
    public class CaixaController : Controller
    {
        private ICaixaAppService _caixaAppService;
        private static  readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        //public CaixaController(ICaixaAppService caixaAppService)
        //{
        //    this._caixaAppService = caixaAppService;
        //}

        public CaixaController()
        {

        }

        // GET: Caixa
        public ActionResult Index()
        {
            log.Info("Index");

            return View("FechamentoDiario", new TelaFechamentoDiarioModel());
        }

        public ActionResult FechamentoDiario(TelaFechamentoDiarioModel model, int? page)
        {
            log.Info("Buscar Fechametnos Diarios");

            IEnumerable<FechamentoDiarioModel> dados = new List<FechamentoDiarioModel>();
            
            if (string.IsNullOrEmpty(model.FiltroDia))
            {
                dados = Mapper.Map<IEnumerable<FechamentoDiarioModel>>(_caixaAppService.ObterFechamentos());
            }
            else
            {
                dados = Mapper.Map<IEnumerable<FechamentoDiarioModel>>(_caixaAppService.ObterFechamentosDoDia(model.FiltroDia));
            }

            var pageNumber = page ?? 1;
            int paginaTamanho = 15;

            return View(new TelaFechamentoDiarioModel
            {
                Fechamentos = dados.ToPagedList(pageNumber, paginaTamanho),
                FiltroDia = model.FiltroDia
            });
        }

        public ActionResult ExibirEntradasDoDia(int id)
        {
            var entradas = _caixaAppService.ObterEntradasDoCaixa(id);            

            return PartialView("_MovimentosDoCaixa",  Mapper.Map<IEnumerable<MovimentoCaixaModel>>(entradas));
        }

        public ActionResult ExibirSaidasDoDia(int id)
        {
            var saidas = _caixaAppService.ObterSaidasDoCaixa(id);            

            return PartialView("_MovimentosDoCaixa", Mapper.Map<IEnumerable<MovimentoCaixaModel>>(saidas));
        }
    }
}