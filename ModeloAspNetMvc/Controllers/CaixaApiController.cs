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

            return Ok();
        }

        [HttpGet]
        [Route("ObterFechamentos")]
        public IHttpActionResult ObterFechamentos(int? numeroPagina, int? tamanhoPagina, string diaFechamento)
        {
            IEnumerable<FechamentoDiarioModel> resultado;

            if (string.IsNullOrEmpty(diaFechamento))
            {
                resultado = Mapper.Map<IEnumerable<FechamentoDiarioModel>>(_caixaAppService.ObterFechamentos(numeroPagina.Value, tamanhoPagina.Value));
            }
            else
            {
                resultado = Mapper.Map<IEnumerable<FechamentoDiarioModel>>(_caixaAppService.ObterFechamentosDoDia(diaFechamento, numeroPagina.Value, tamanhoPagina.Value));
            }

            return Ok(resultado);
        }

        [HttpGet]
        [Route("ObterCountFechamentos")]
        public IHttpActionResult ObterCountFechamentos(string diaFechamento)
        {
            int count = 0;

            if (string.IsNullOrEmpty(diaFechamento))
            {
                count = _caixaAppService.CountObterFechamentos();
            }
            else
            {
                count = _caixaAppService.CountObterFechamentosDoDia(diaFechamento);
            }

            return Ok(count);
        }

        [HttpGet]
        [Route("ObterEntradasDoCaixaPorDia")]
        public IHttpActionResult ObterEntradasDoDia(string diaFechamento)
        {
            var entradas = _caixaAppService.ObterEntradasDoCaixa(diaFechamento);
            var model = Mapper.Map<IEnumerable<MovimentoCaixaModel>>(entradas);
            return Ok(model);
        }

        [HttpGet]
        [Route("ObterRetiradasDoCaixaPorDia")]
        public IHttpActionResult ObterRetiradasDoDia(string diaFechamento)
        {
            var retiradas = _caixaAppService.ObterSaidasDoCaixa(diaFechamento);
            var model = Mapper.Map<IEnumerable<MovimentoCaixaModel>>(retiradas);
            return Ok(model);
        }

        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

    }
}
