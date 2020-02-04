using Autofac;
using TEK.Infrastructure.Interfaces;
using TEK.Infrastructure.Interfaces.DataContract;

namespace TEK.TaxCalculation.Engine
{
    public class ModuleResolution : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TaxCalculatorService>().As<ITaxCalculatorService>();
            builder.RegisterType<BasicTaxSpecification>().As<ISpecification<Product>>();
            builder.RegisterType<ImportTaxSpecification>().As<ISpecification<Product>>().PreserveExistingDefaults();
        }
    }
}
