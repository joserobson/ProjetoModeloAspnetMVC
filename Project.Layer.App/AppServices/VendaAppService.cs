using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Project.Layer.App.AppModels.Venda;
using Project.Layer.Domain.Entities;
using Project.Layer.Domain.Interfaces.Repositories;
using System;
using Project.CrossCutting.Exceptions;
using System.Net.Http;
using Project.Layer.App.Helper;

namespace Project.Layer.App.AppServices
{
    public class VendaAppService : IVendaAppService
    {

        private readonly IResumoFinanceiroMensalRepository _resumoFinanceiroMensalRepository;

        //public VendaAppService(IResumoFinanceiroMensalRepository resumoFinanceiroMensalRepository)
        //{
        //    _resumoFinanceiroMensalRepository = resumoFinanceiroMensalRepository;
        //}       

        public VendaAppService()
        {

        }

        public void CadastrarResumosFinanceiros(IEnumerable<ResumoFinanceiroMensalAppModel> resumosAppModel)
        {
            ResumoFinanceiroMensal resumoMensal = null;

            foreach (var itemResumo in resumosAppModel)
            {

                resumoMensal = Mapper.Map<ResumoFinanceiroMensal>(itemResumo);

                _resumoFinanceiroMensalRepository.Adicionar(resumoMensal);
            }

            _resumoFinanceiroMensalRepository.SalvarTodos();
        }        

        public ResumoFinanceiroMensalAppModel ObterResumoFinanceiroMensal(string mesAno)
        {
            //var resumoModel = _resumoFinanceiroMensalRepository.GetAll().FirstOrDefault(r => r.MesAno.Equals(mesAno));
            //return Mapper.Map<ResumoFinanceiroMensalAppModel>(resumoModel);


            var resumo = new ResumoFinanceiroMensalAppModel();

            var httpResponse = HttpServices.HttpServiceVenda.ObterResumoFinanceiroDoMes(mesAno);
            if (httpResponse.IsSuccessStatusCode)
            {
                resumo = httpResponse.Content.ReadAsAsync<ResumoFinanceiroMensalAppModel>().Result;
            }
            else
            {
                var erro = HttpServiceHelper.ObterMensagemHttpResponse(httpResponse);
                throw new BusinessException(erro);
            }

            return resumo;
        }

        public ResumoDebitosAReceberAppModel ObterResumoDebitosAReceber(string dataReferencia)
        {
            var resumo = new ResumoDebitosAReceberAppModel();
;
            //validar data
            DateTime dataValida;
            if (!DateTime.TryParse(dataReferencia, out dataValida))
            {
                throw new BusinessException("Data Referência Inválida");
            }

            //chamar http service
            var httpResponse = HttpServices.HttpServiceVenda.ObterDebitosDosClientesAReceber(dataReferencia);
            if (httpResponse.IsSuccessStatusCode)
            {
                resumo = httpResponse.Content.ReadAsAsync<ResumoDebitosAReceberAppModel>().Result;
            }
            else
            {
                var erro = HttpServiceHelper.ObterMensagemHttpResponse(httpResponse);
                throw new BusinessException(erro);
            }

            return resumo;
        }
    }
}
