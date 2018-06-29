using AutoMapper;
using ModeloAspNetMvc.Models.Caixa;
using Project.Layer.App.AppModels.Caixa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModeloAspNetMvc.AutoMapper
{
    public class WebMappingProfile: Profile
    {
        public WebMappingProfile()
        {
            //CreateMap<Filial, FilialView>().ReverseMap();

            CreateMap<FechamentoDiarioAppModel, FechamentoDiarioModel>().ReverseMap();
        }
    }
}