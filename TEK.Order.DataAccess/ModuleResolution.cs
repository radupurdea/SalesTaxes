using Autofac;
using TEK.Infrastructure.Interfaces;

namespace TEK.Order.DataAccess
{
    public class ModuleResolution : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CountryDefinitionDataAccess>().As<ICountryDefinitionDataAccess>().InstancePerLifetimeScope(); 
            builder.RegisterType<StoreDefinitionDataAccess>().As<IStoreDefinitionDataAccess>().InstancePerLifetimeScope(); 
            builder.RegisterType<CartItemDataAccess>().As<ICartItemDataAccess>().InstancePerLifetimeScope();
        }
    }
}
