using AutoMapper;
using log4net;
using ModeloAspNetMvc.ActionFilters;
using ModeloAspNetMvc.Models.Caixa;
using PagedList;
using Project.Layer.App.AppServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ModeloAspNetMvc.Controllers
{
    [BasicAuthenticationAttribute]
    public class CaixaController : Controller
    {
        private ICaixaAppRestService _caixaAppService;
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private const int paginaTamanho = 10;

        public CaixaController(ICaixaAppRestService caixaAppService)
        {
            this._caixaAppService = caixaAppService;
        }               

        public async Task<ActionResult> FechamentoDiario(TelaFechamentoDiarioModel model, int? page)
        {
            log.Info("Buscar Fechametnos Diarios");
            var pageNumber = page ?? 1;
            var totalLinhas = 0;
            var mes = model.Mes ?? DateTime.Now.Month.ToString();
            var ano = model.Ano ?? DateTime.Now.Year.ToString();

            IEnumerable<FechamentoDiarioModel> dados = new List<FechamentoDiarioModel>();
            IPagedList<FechamentoDiarioModel> pageOrders = null;

            if (!string.IsNullOrEmpty(model.FiltroDia))
            {
                totalLinhas = _caixaAppService.CountObterFechamentosDoDia(model.FiltroDia);
                var fechamentosDoDia = await _caixaAppService.ObterFechamentosDoDiaAsync(model.FiltroDia, pageNumber, paginaTamanho);
                dados = Mapper.Map<IEnumerable<FechamentoDiarioModel>>(fechamentosDoDia);
                pageOrders = new StaticPagedList<FechamentoDiarioModel>(dados, pageNumber, paginaTamanho, totalLinhas);
            }
            else
            {              
                var mesFormatado = mes.Length == 1 ? $"0{mes}" : mes;
                var mesAno = $"{mesFormatado}/{ano}";
                var fechamentosDoMes = await _caixaAppService.ObterFechamentosDoMesAsync(mesAno);
                var fechamentosPaginados = fechamentosDoMes.Skip((pageNumber - 1) * paginaTamanho).Take(paginaTamanho);
                dados = Mapper.Map<IEnumerable<FechamentoDiarioModel>>(fechamentosPaginados);
                
                pageOrders = new StaticPagedList<FechamentoDiarioModel>(dados, pageNumber, paginaTamanho, fechamentosDoMes.Count());
            }
            

            return View(new TelaFechamentoDiarioModel
            {
                Fechamentos = pageOrders,
                FiltroDia = model.FiltroDia,
                TotalItemCount = 10,
                Mes = mes.ToString(),
                Ano = ano.ToString()
            });
        }

        public ActionResult ExibirEntradasDoDia(string diaFechamento)
        {
            var entradas = _caixaAppService.ObterEntradasDoCaixa(diaFechamento);

            return PartialView("_MovimentosDoCaixa", Mapper.Map<IEnumerable<MovimentoCaixaModel>>(entradas));
        }

        public ActionResult ExibirSaidasDoDia(string diaFechamento)
        {
            var saidas = _caixaAppService.ObterRetiradasDoCaixa(diaFechamento);

            return PartialView("_MovimentosDoCaixa", Mapper.Map<IEnumerable<MovimentoCaixaModel>>(saidas));
        }
    }
}