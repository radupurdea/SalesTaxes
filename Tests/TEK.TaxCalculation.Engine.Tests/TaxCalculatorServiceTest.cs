using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using TEK.Infrastructure.Interfaces;
using TEK.Infrastructure.Interfaces.DataContract;
using System.Linq;

namespace TEK.TaxCalculation.Engine.Tests
{
    [TestClass]
    public class TaxCalculatorServiceTest
    {
        protected ITaxCalculatorService _taxCalculatorService;
        protected Mock<ICountryDefinitionDataAccess> _mockCountryDefinitionService;
        protected Mock<IEnumerable<ISpecification<Product>>> _mockSpecifications;
        protected Mock<ISpecification<Product>> _mockTaxSpecification;
        protected Mock<ITaxableType> _mockTaxableType;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockTaxableType = new Mock<ITaxableType>(MockBehavior.Strict);
            _mockTaxSpecification = new Mock<ISpecification<Product>>(MockBehavior.Strict);
            _mockTaxSpecification.As<ITaxableType>();
            _mockCountryDefinitionService = new Mock<ICountryDefinitionDataAccess>(MockBehavior.Strict);
            _mockSpecifications = new Mock<IEnumerable<ISpecification<Product>>>(MockBehavior.Strict);
            _mockSpecifications.Setup(c => c.GetEnumerator()).Returns(new List<ISpecification<Product>> { _mockTaxSpecification.Object }.Select(x => x).GetEnumerator());

            _taxCalculatorService = new TaxCalculatorService(_mockCountryDefinitionService.Object, _mockSpecifications.Object);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _mockTaxableType.VerifyAll();
            _mockTaxSpecification.VerifyAll();
            _mockCountryDefinitionService.VerifyAll();
            _mockSpecifications.VerifyAll();
        }

        [TestMethod]
        public void ApplyTax_BasicTax_ShouldCalculateTax()
        {
            _mockTaxSpecification.Setup(f => f.IsSatisfied(It.IsAny<Product>())).Returns(true);

            _mockCountryDefinitionService.Setup(f => f.GetCountry()).Returns(new Country()
            {
                Name = "Canada",
                TaxBands = new List<TaxBand>()
                {
                     new TaxBand()
                     {
                          Percentage = 10M,
                          ProductType = Infrastructure.Interfaces.Enum.ProductType.Default,
                          TaxType = Infrastructure.Interfaces.Enum.TaxType.BasicSalesTax
                     }
                }
            });

            _mockTaxSpecification.As<ITaxableType>().SetupGet(x => x.TaxType).Returns(Infrastructure.Interfaces.Enum.TaxType.BasicSalesTax);

            OrderProduct orderProduct = new OrderProduct()
            {
                Product = new Product()
                {
                    CountryOfDelivery = "Canada",
                    Name = "lollipop",
                    ProductType = Infrastructure.Interfaces.Enum.ProductType.Default,
                    UnitPrice = 10.45M
                },
                 Quantity = 1,
                 ExtendedAmount = 10.45M
            };

            _taxCalculatorService.ApplyTax(orderProduct);

            Assert.AreEqual(1, orderProduct.ApplicableTaxes.Count);
            Assert.AreEqual(1.05M, orderProduct.ApplicableTaxes[0].TaxAmount);
        }
    }
}
