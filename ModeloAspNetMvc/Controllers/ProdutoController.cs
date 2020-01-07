using ModeloAspNetMvc.ActionFilters;
using ModeloAspNetMvc.Helpers;
using Project.Layer.App.AppServices;
using System;
using System.Linq;
using System.Web.Mvc;

namespace ModeloAspNetMvc.Controllers
{
    [BasicAuthenticationAttribute]
    public class ProdutoController : Controller
    {
        private readonly IProdutoAppService _produtoAppService;

        public ProdutoController(IProdutoAppService produtoAppService)
        {
            _produtoAppService = produtoAppService;
        }

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
            var produtos = _produtoAppService.ObterRelatorioDeProdutos();
            string[] columns = { "Codigo", "Descricao","Estoque","Preco" };

            var dataTable = ExcelExportHelper.ListToDataTable(produtos.ToList());
            byte[] filecontent = ExcelExportHelper.ExportExcel(dataTable, "Relatório de Produtos", true, columns);
            return File(filecontent, ExcelExportHelper.ExcelContentType, $"RelatorioProdutos{DateTime.Now.ToShortDateString()}.xlsx");
        }
    }
}