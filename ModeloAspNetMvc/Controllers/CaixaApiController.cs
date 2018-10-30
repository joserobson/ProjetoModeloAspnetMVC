using AutoMapper;
using ModeloAspNetMvc.Models.Caixa;
using Project.Layer.App.AppModels.Caixa;
using Project.Layer.App.AppServices;
using System.Collections.Generic;
using System.Web.Http;

namespace ModeloAspNetMvc.Controllers
{
    [RoutePrefix("api/caixaApi")]
    public class CaixaApiController : ApiController
    {

        private ICaixaAppService _caixaAppService;
       

        public CaixaApiController(ICaixaAppService caixaAppService)
        {
            this._caixaAppService = caixaAppService;
        }

        [HttpPost]
        [Route("CadastrarFechamentoDiario")]
        public IHttpActionResult CadastrarFechamentoDiario(FechamentoDiarioModel model)
        {
            var appServiceModel = Mapper.Map<FechamentoDiarioAppModel>(model);
            this._caixaAppService.CadastrarFechamentoDiario(appServiceModel);

            //checar se existem mais de 100 registros e fazer o delete dos mais antigos

            return Ok();
        }

        [HttpGet]
        [Route("ObterFechamentos")]
        public IHttpActionResult ObterFechamentos()
        {            
            var dados = Mapper.Map<IEnumerable<FechamentoDiarioModel>>(_caixaAppService.ObterFechamentosComDetalhes());

            return Ok(dados);
        }

        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

    }
}
