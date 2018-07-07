using AutoMapper;
using ModeloAspNetMvc.Models.Caixa;
using Project.Layer.App.AppModels.Caixa;
using Project.Layer.App.AppServices;
using System.Collections.Generic;
using System.Web.Http;

namespace ModeloAspNetMvc.Controllers
{
    [RoutePrefix("api/caixaapi")]
    public class CaixaApiController : ApiController
    {

        private ICaixaAppService _caixaAppService;
       

        public CaixaApiController(ICaixaAppService caixaAppService)
        {
            this._caixaAppService = caixaAppService;
        }

        [HttpPost]
        public IHttpActionResult CadastrarFechamentoDiario(FechamentoDiarioModel model)
        {
            var appServiceModel = Mapper.Map<FechamentoDiarioAppModel>(model);
            this._caixaAppService.CadastrarFechamentoDiario(appServiceModel);

            return Ok();
        }

        [HttpGet]
        [Route("ObterFechamentos")]
        public IHttpActionResult ObterFechamentos()
        {            
            var dados = Mapper.Map<IEnumerable<FechamentoDiarioModel>>(_caixaAppService.ObterFechamentos());

            return Ok(dados);
        }

        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

    }
}
