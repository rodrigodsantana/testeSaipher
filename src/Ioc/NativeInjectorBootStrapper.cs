using App.Interfaces;
using App.Map;
using App.Services;
using AutoMapper;
using AutoMapper.Configuration;
using CrossCutting;
using Data.Context;
using Data.Repository;
using Dominio;
using Dominio.Interfaces;
using Dominio.Services;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Ioc
{


    public class MapperProvider
    {
        private readonly Container _container;

        public MapperProvider(Container container)
        {
            _container = container;
        }

        public IMapper GetMapper()
        {
            var mce = new MapperConfigurationExpression();
            mce.ConstructServicesUsing(_container.GetInstance);

            var profiles = typeof(ViewModelToDomainMappingProfile).Assembly.GetTypes()
            .Where(t => typeof(Profile).IsAssignableFrom(t))
            .ToList();


             mce.AddProfiles(new List<Profile> { new ViewModelToDomainMappingProfile(), new DomainToViewModelMappingProfile() });

            //mce.AddProfiles(profiles);

            var mc = new MapperConfiguration(mce);
           // mc.AssertConfigurationIsValid();

            IMapper m = new Mapper(mc, t => _container.GetInstance(t));

            return m;
        }
    }

    public class NativeInjectorBootStrapper
    {

        public static void RegisterServices(Container container)
        {

            // Register your types, for instance using the scoped lifestyle:
            /*conectar a varios bancos*/
            container.Register<IContexto, SqlFactory>(Lifestyle.Scoped);

            container.Register<LNoty>(Lifestyle.Scoped);

            container.Register<IVooApp, VooApp>(Lifestyle.Scoped);

            container.Register<IVooService, VooService>(Lifestyle.Scoped);

            container.Register<IAeronaveRepository, AeronaveRepository>(Lifestyle.Scoped);


            container.Register<IAeroportoRepository, AeroportoRepository>(Lifestyle.Scoped);

            container.Register<IVooRepository, VooRepository>(Lifestyle.Scoped);


            container.Register<IAeroportoApp, AeroportoApp>(Lifestyle.Scoped);

            container.Register<IAeronaveApp, AeronaveApp>(Lifestyle.Scoped);

            // Automapper
            container.RegisterSingleton(() => GetMapper(container));
        }

        private static AutoMapper.IMapper GetMapper(Container container)
        {
            var mp = container.GetInstance<MapperProvider>();
            return mp.GetMapper();
        }
    }
}
