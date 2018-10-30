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
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private const int paginaTamanho = 10;

        public CaixaController(ICaixaAppService caixaAppService)
        {
            this._caixaAppService = caixaAppService;
        }

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
            var pageNumber = page ?? 1;
            var totalLinhas = 0;

            IEnumerable<FechamentoDiarioModel> dados = new List<FechamentoDiarioModel>();

            if (string.IsNullOrEmpty(model.FiltroDia))
            {
                totalLinhas = _caixaAppService.CountObterFechamentos();
                dados = Mapper.Map<IEnumerable<FechamentoDiarioModel>>(_caixaAppService.ObterFechamentos(pageNumber, paginaTamanho));
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
            var saidas = _caixaAppService.ObterSaidasDoCaixa(id);

            return PartialView("_MovimentosDoCaixa", Mapper.Map<IEnumerable<MovimentoCaixaModel>>(saidas));
        }
    }
}