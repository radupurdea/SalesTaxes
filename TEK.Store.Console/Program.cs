using Autofac;
using System.Collections.Generic;
using System.Linq;
using TEK.Infrastructure.Interfaces;
using TEK.Infrastructure.Interfaces.DataContract;
using System;

namespace TEK.Store.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<TEK.Order.DataAccess.ModuleResolution>();
            builder.RegisterModule<TEK.TaxCalculation.Engine.ModuleResolution>();
            builder.RegisterModule<TEK.Purchase.Manager.ModuleResolution>();

            var container = builder.Build();

            IStoreDefinitionService storeDefinitionService = container.Resolve<IStoreDefinitionService>();
            ICountryDefinitionService countryDefinitionService = container.Resolve<ICountryDefinitionService>();
            ICartService cartService = container.Resolve<ICartService>();

            Country storeCountry = countryDefinitionService.GetCountry();
            List<Product> storeProducts = storeDefinitionService.GetStoreProducts();

            #region Input/Output 1
            List<Product> selectedProductsForOutput1 = storeProducts.Where(x => new string[] { "book", "music CD", "chocolate bar" }.Contains(x.Name)).ToList();

            CheckoutScenario(cartService, selectedProductsForOutput1);
            #endregion

            #region Input/Output 2
            List<Product> selectedProductsForOutput2 = storeProducts.Where(x =>
                (x.Name == "box of chocolates" && x.UnitPrice == 10M)
                || (x.Name == "bottle of perfume" && x.UnitPrice == 47.50M)
            ).ToList();
            
            CheckoutScenario(cartService, selectedProductsForOutput2);
            #endregion

            #region Input/Output 3
            List<Product> selectedProductsForOutput3 = storeProducts.Where(x =>
                (x.Name == "bottle of perfume" && x.UnitPrice == 27.99M)
                || (x.Name == "bottle of perfume" && x.UnitPrice == 18.99M)
                || (x.Name == "packet of headache pills")
                || (x.Name == "box of chocolates" && x.UnitPrice == 11.25M)
            ).ToList();
            
            CheckoutScenario(cartService, selectedProductsForOutput3);
            #endregion

            System.Console.ReadLine();
        }

        private static void CheckoutScenario(ICartService cartService, List<Product> selectedProducts)
        {
            selectedProducts.ForEach(selectedProduct => cartService.AddToCart(selectedProduct));

            Receipt previewReceipt = cartService.PreviewCart();

            PrintPreviewReceipt(previewReceipt);

            System.Console.WriteLine();

            Receipt receipt = cartService.Checkout();

            PrintReceipt(receipt);

            System.Console.WriteLine("---------------------------------------");

            cartService.ClearCart();
        }

        private static void PrintPreviewReceipt(Receipt receipt)
        {
            receipt.LineItems.ForEach(lineItem => System.Console.WriteLine($"{lineItem.Quantity} {lineItem.Name} at {lineItem.Total}"));
        }

        private static void PrintReceipt(Receipt receipt)
        {
            receipt.LineItems.ForEach(lineItem => System.Console.WriteLine($"{lineItem.Quantity} {lineItem.Name}: {lineItem.Total}"));
            System.Console.WriteLine($"Sales Taxes: {receipt.TotalTax} Total: {receipt.Total}");
        }
    }
}
