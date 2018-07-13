﻿using Project.Layer.App.AppServices;
using Project.Layer.Data.Contexto;
using Project.Layer.Data.Repositories;
using Project.Layer.Domain.Interfaces.Repositories;
using SimpleInjector;

namespace Project.CrossCutting.Ioc
{
    public class DIContainer
    {
        public static Container container;

        public static void RegisterDependencies(Container containerToInject)
        {
            containerToInject.Register<ProjectContext>(Lifestyle.Scoped);

            containerToInject.Register<IClienteAppService, ClienteAppService>();
            containerToInject.Register<ICaixaAppService, CaixaAppService>();

            containerToInject.Register<ICaixaRepository, CaixaRepository>(Lifestyle.Scoped);
        }
    }
}
