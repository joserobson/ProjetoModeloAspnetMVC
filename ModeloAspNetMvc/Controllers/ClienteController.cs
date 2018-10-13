using ModeloAspNetMvc.Helpers;
using Project.Layer.App.AppServices;
using System.Linq;
using System.Web.Mvc;

namespace ModeloAspNetMvc.Controllers
{
    public class ClienteController : Controller
    {
        private IClienteAppService _clienteAppService;

        //public ClienteController(IClienteAppService clienteAppService)
        //{
        //    this._clienteAppService = clienteAppService;
        //}

        public ClienteController()
        {

        }

        // GET: Cliente
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Relatorio()
        {
            return View();
        }

        [HttpPost]
        public FileContentResult GerarRelatorio()
        {                                   
            var clientes = _clienteAppService.GerarRelatorio();
            string[] columns = { "NumeroDaFicha", "NomeDoCliente" };

            var dataTable = ExcelExportHelper.ListToDataTable(clientes.ToList());
            byte[] filecontent = ExcelExportHelper.ExportExcel(dataTable, "Relatório de Clientes", true, columns);
            return File(filecontent, ExcelExportHelper.ExcelContentType, "RelatorioClientes.xlsx");
        }
    }
}