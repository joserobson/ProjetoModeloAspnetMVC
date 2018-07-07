using AutoMapper;
using ModeloAspNetMvc.Models.Caixa;
using Project.Layer.App.AppModels.Caixa;

namespace ModeloAspNetMvc.AutoMapper
{
    public class WebMappingProfile: Profile
    {
        public WebMappingProfile()
        {
            //CreateMap<Filial, FilialView>().ReverseMap();

            CreateMap<FechamentoDiarioAppModel, FechamentoDiarioModel>().ReverseMap();
            CreateMap<MovimentoCaixaAppModel, MovimentoCaixaModel>().ReverseMap();
        }
    }
}