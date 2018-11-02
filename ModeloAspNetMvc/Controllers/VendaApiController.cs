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
            _vendaAppService.CadastrarResumosFinanceiros(resumos);

            return Ok();
        }

        [HttpPost]
        [Route("CadastrarResumoDebitosAReceber")]
        public IHttpActionResult CadastrarResumoDebitosAReceber(IEnumerable<ResumoDebitosAReceberAppModel> debitosAReceber)
        {
            _vendaAppService.CadastrarResumoDebitosAReceber(debitosAReceber);

            return Ok();
        }

        [HttpGet]
        [Route("ObterResumoFinanceiroMensal")]
        public IHttpActionResult ObterResumoFinanceiroMensal(string mesAno)
        {
            var resumo = _vendaAppService.ObterResumoFinanceiroMensal(mesAno);
            return Ok(resumo);
        }

        [HttpGet]
        [Route("ObterDebitosAReceber")]
        public IHttpActionResult ObterResumoDebitosAReceber(string dataReferencia)
        {
            var resumo = _vendaAppService.ObterResumoDebitosAReceber(dataReferencia);
            return Ok(resumo);
        }

    }
}
