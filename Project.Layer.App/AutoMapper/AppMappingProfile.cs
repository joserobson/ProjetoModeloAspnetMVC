using AutoMapper;
using Project.Layer.App.AppModels.Venda;
using Project.Layer.Domain.Entities;

namespace Project.Layer.App.AutoMapper
{
    public class AppMappingProfile: Profile
    {
        public AppMappingProfile()
        {
            CreateMap<ResumoFinanceiroMensalAppModel, ResumoFinanceiroMensal>().ReverseMap();
        }
    }
}
