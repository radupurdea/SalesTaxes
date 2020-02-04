using Autofac;
using TEK.Infrastructure.Interfaces;

namespace TEK.Order.DataAccess
{
    public class ModuleResolution : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CountryDefinitionService>().As<ICountryDefinitionService>().InstancePerLifetimeScope(); 
            builder.RegisterType<StoreDefinitionService>().As<IStoreDefinitionService>().InstancePerLifetimeScope(); 
        }
    }
}
