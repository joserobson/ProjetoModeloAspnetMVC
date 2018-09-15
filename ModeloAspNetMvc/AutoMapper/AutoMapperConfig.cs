using AutoMapper;
using Project.Layer.App.AutoMapper;

namespace ModeloAspNetMvc.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<WebMappingProfile>();
                x.AddProfile<AppMappingProfile>();
            });
        }
    }
}