using AutoMapper;
using ModeloAspNetMvc.Models.Venda;
using Project.Layer.App.AppModels.Venda;
using Project.Layer.App.AppServices;
using System.Collections.Generic;
using System.Web.Http;

namespace ModeloAspNetMvc.Controllers
{
    [RoutePrefix("api/vendaApi")]
    public class VendaApiController : ApiController
    {
        private readonly IVendaAppService _vendaAppService;


        public VendaApiController(IVendaAppService vendaAppService)
        {
            _vendaAppService = vendaAppService;
        }

        [HttpPost]
        [Route("CadastrarResumosFinanceiros")]
        public IHttpActionResult CadastrarResumosFinanceiros(IEnumerable<ResumoFinanceiroMensalAppModel> resumos)
        {            
            //_vendaAppService.CadastrarResumosFinanceiros(resumos);

            return Ok();
        }

    }
}
