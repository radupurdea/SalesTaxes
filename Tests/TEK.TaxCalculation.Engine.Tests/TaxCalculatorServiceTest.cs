using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TEK.TaxCalculation.Engine.Tests
{
    [TestClass]
    public class TaxCalculatorServiceTest
    {
        //[TestMethod]
        //[RaisedException(typeof(NullReferenceException))]
        //public void ApplyTaxThrowsNullReferenceException910()
        //{
        //    TaxCalculatorService taxCalculatorService;
        //    taxCalculatorService =
        //      new TaxCalculatorService((ICountryDefinitionService)null,
        //                               (IEnumerable<ISpecification<Product>>)null);
        //    this.ApplyTax(taxCalculatorService, (OrderProduct)null);
        //}

        //[TestMethod]
        //public void ApplyTax98()
        //{
        //    TaxCalculatorService taxCalculatorService;
        //    ISpecification<Product>[] iSpecifications = new ISpecification<Product>[0];
        //    taxCalculatorService =
        //      new TaxCalculatorService((ICountryDefinitionService)null,
        //                               (IEnumerable<ISpecification<Product>>)iSpecifications);
        //    this.ApplyTax(taxCalculatorService, (OrderProduct)null);
        //    Assert.IsNotNull((object)taxCalculatorService);
        //}

        //[TestMethod]
        //[RaisedException(typeof(NullReferenceException))]
        //public void ApplyTaxThrowsNullReferenceException650()
        //{
        //    TaxCalculatorService taxCalculatorService;
        //    ISpecification<Product>[] iSpecifications = new ISpecification<Product>[1];
        //    taxCalculatorService =
        //      new TaxCalculatorService((ICountryDefinitionService)null,
        //                               (IEnumerable<ISpecification<Product>>)iSpecifications);
        //    this.ApplyTax(taxCalculatorService, (OrderProduct)null);
        //}

        //[TestMethod]
        //[RaisedException(typeof(NullReferenceException))]
        //public void ApplyTaxThrowsNullReferenceException784()
        //{
        //    TaxCalculatorService taxCalculatorService;
        //    OrderProduct orderProduct;
        //    ISpecification<Product>[] iSpecifications = new ISpecification<Product>[1];
        //    taxCalculatorService =
        //      new TaxCalculatorService((ICountryDefinitionService)null,
        //                               (IEnumerable<ISpecification<Product>>)iSpecifications);
        //    orderProduct = new OrderProduct();
        //    orderProduct.Quantity = 0;
        //    orderProduct.Product = (Product)null;
        //    orderProduct.ExtendedAmount = default(decimal);
        //    orderProduct.TotalAmount = default(decimal);
        //    this.ApplyTax(taxCalculatorService, orderProduct);
        //}

        //[TestMethod]
        //[RaisedException(typeof(NullReferenceException))]
        //public void ApplyTaxThrowsNullReferenceException412()
        //{
        //    BasicTaxSpecification basicTaxSpecification;
        //    TaxCalculatorService taxCalculatorService;
        //    OrderProduct orderProduct;
        //    basicTaxSpecification =
        //      new BasicTaxSpecification((ICountryDefinitionService)null);
        //    ISpecification<Product>[] iSpecifications = new ISpecification<Product>[1];
        //    iSpecifications[0] = (ISpecification<Product>)basicTaxSpecification;
        //    taxCalculatorService =
        //      new TaxCalculatorService((ICountryDefinitionService)null,
        //                               (IEnumerable<ISpecification<Product>>)iSpecifications);
        //    orderProduct = new OrderProduct();
        //    orderProduct.Quantity = 0;
        //    orderProduct.Product = (Product)null;
        //    orderProduct.ExtendedAmount = default(decimal);
        //    orderProduct.TotalAmount = default(decimal);
        //    this.ApplyTax(taxCalculatorService, orderProduct);
        //}

        //[TestMethod]
        //[RaisedException(typeof(NullReferenceException))]
        //public void ApplyTaxThrowsNullReferenceException225()
        //{
        //    ImportTaxSpecification importTaxSpecification;
        //    TaxCalculatorService taxCalculatorService;
        //    OrderProduct orderProduct;
        //    importTaxSpecification =
        //      new ImportTaxSpecification((ICountryDefinitionService)null);
        //    ISpecification<Product>[] iSpecifications = new ISpecification<Product>[1];
        //    iSpecifications[0] = (ISpecification<Product>)importTaxSpecification;
        //    taxCalculatorService =
        //      new TaxCalculatorService((ICountryDefinitionService)null,
        //                               (IEnumerable<ISpecification<Product>>)iSpecifications);
        //    orderProduct = new OrderProduct();
        //    orderProduct.Quantity = 0;
        //    orderProduct.Product = (Product)null;
        //    orderProduct.ExtendedAmount = default(decimal);
        //    orderProduct.TotalAmount = default(decimal);
        //    this.ApplyTax(taxCalculatorService, orderProduct);
        //}

        //[TestMethod]
        //[RaisedException(typeof(NullReferenceException))]
        //public void ApplyTaxThrowsNullReferenceException186()
        //{
        //    ImportTaxSpecification importTaxSpecification;
        //    TaxCalculatorService taxCalculatorService;
        //    OrderProduct orderProduct;
        //    importTaxSpecification =
        //      new ImportTaxSpecification((ICountryDefinitionService)null);
        //    ISpecification<Product>[] iSpecifications = new ISpecification<Product>[1];
        //    iSpecifications[0] = (ISpecification<Product>)importTaxSpecification;
        //    taxCalculatorService =
        //      new TaxCalculatorService((ICountryDefinitionService)null,
        //                               (IEnumerable<ISpecification<Product>>)iSpecifications);
        //    Product s0 = new Product();
        //    s0.Name = (string)null;
        //    s0.ProductType = ProductType.Default;
        //    s0.UnitPrice = default(decimal);
        //    s0.CountryOfDelivery = (string)null;
        //    orderProduct = new OrderProduct();
        //    orderProduct.Quantity = 0;
        //    orderProduct.Product = s0;
        //    orderProduct.ExtendedAmount = default(decimal);
        //    orderProduct.TotalAmount = default(decimal);
        //    this.ApplyTax(taxCalculatorService, orderProduct);
        //}
    }
}
