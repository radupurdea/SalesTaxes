using Autofac;
using TEK.Infrastructure.Interfaces;

namespace TEK.Purchase.Manager
{
    public class ModuleResolution : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CartService>().As<ICartService>();
        }
    }
}
