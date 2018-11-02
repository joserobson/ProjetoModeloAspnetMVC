using AutoMapper;
using ModeloAspNetMvc.Models.Caixa;
using ModeloAspNetMvc.Models.Venda;
using Project.Layer.App.AppModels.Caixa;
using Project.Layer.App.AppModels.Venda;
using Project.Layer.Domain.Entities;

namespace ModeloAspNetMvc.AutoMapper
{
    public class WebMappingProfile : Profile
    {
        public WebMappingProfile()
        {
            //CreateMap<Filial, FilialView>().ReverseMap();

            CreateMap<FechamentoDiarioAppModel, FechamentoDiarioModel>().ReverseMap();

            CreateMap<MovimentoCaixaAppModel, MovimentoCaixaModel>().ReverseMap();


            CreateMap<ResumoFinanceiroMensalAppModel, ResumoFinanceiroMensalModel>()
                .ForMember(model => model.ValorDasPrestacoesRecebidasNoCartao, appModel => appModel.MapFrom(o => o.ValorDasPrestacoesRecebidasNoCartao.ToString("C2")))
                .ForMember(model => model.ValorDasPrestacoesRecebidasNoCheque, appModel => appModel.MapFrom(o => o.ValorDasPrestacoesRecebidasNoCheque.ToString("C2")))
                .ForMember(model => model.ValorDasPrestacoesRecebidasNoDinheiro, appModel => appModel.MapFrom(o => o.ValorDasPrestacoesRecebidasNoDinheiro.ToString("C2")))
                .ForMember(model => model.ValorDasVendasAPrazo, appModel => appModel.MapFrom(o => o.ValorDasVendasAPrazo.ToString("C2")))
                .ForMember(model => model.ValorDasVendasAVista, appModel => appModel.MapFrom(o => o.ValorDasVendasAVista.ToString("C2")))
                .ForMember(model => model.ValorDosPagsRecebidosAVistaNoCartao, appModel => appModel.MapFrom(o => o.ValorDosPagsRecebidosAVistaNoCartao.ToString("C2")))
                .ForMember(model => model.ValorDosPagsRecebidosAVistaNoCheque, appModel => appModel.MapFrom(o => o.ValorDosPagsRecebidosAVistaNoCheque.ToString("C2")))
                .ForMember(model => model.ValorDosPagsRecebidosAVistaNoDinheiro, appModel => appModel.MapFrom(o => o.ValorDosPagsRecebidosAVistaNoDinheiro.ToString("C2")))
                .ForMember(model => model.ValorTotalDosPagsRecebidosAVista, appModel => appModel.MapFrom(o => o.ValorTotalDosPagsRecebidosAVista.ToString("C2")))
                .ForMember(model => model.ValorTotalEmPagamentosRecebidos, appModel => appModel.MapFrom(o => o.ValorTotalEmPagamentosRecebidos.ToString("C2")))
                .ForMember(model => model.ValorTotalEmPrestacoesRecebidas, appModel => appModel.MapFrom(o => o.ValorTotalEmPrestacoesRecebidas.ToString("C2")))
                .ForMember(model => model.ValorTotalEmVendas, appModel => appModel.MapFrom(o => o.ValorTotalEmVendas.ToString("C2")));


            CreateMap<ResumoDebitosAReceberAppModel, ResumoDebitosAReceberModel>()
                .ForMember(model => model.TotalEmDebitosAReceber, appModel => appModel.MapFrom(o => o.ValorAReceber.ToString("C2")))
                .ForMember(model => model.TotalEmDebitosRetroativos, appModel => appModel.MapFrom(o => o.ValorRetroativo.ToString("C2")))
                .ForMember(model => model.ValorTotal, appModel => appModel.MapFrom(o => (o.ValorAReceber + o.ValorRetroativo).ToString("C2")));


            CreateMap<ResumoDebitosAReceberAppModel, ResumoDebitosAReceber>().ReverseMap();


            CreateMap<ResumoFinanceiroMensal, ResumoFinanceiroMensalAppModel>().ReverseMap();
        }
    }
}