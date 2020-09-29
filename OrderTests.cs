using Cart.Engine.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Cart.Engine.Tests
{
    [TestClass()]
    public class OrderTests
    {      

        [TestMethod]
        public void CalculatePriceTestA()
        {
            //Arrange-Act-Assert 
            Product productOrders = new Order()
            {
                Name = "A",
                Price = 50,
                Quantity = 2
            };
            List<Product> testProduct = new List<Product>();
            Assert.IsNotNull(productOrders.CalculateTotalPrice(testProduct));
        }

        [TestMethod]
        public void ApplyPromotionsTestA()
        {
            var pricePromo = new CartItem();
            Product productOrders = new Order()
            {
                Name = "A",
                Price = 50,
                Quantity = 5
            };
            List<Product> testProduct = new List<Product>();
            Assert.IsNotNull(productOrders.CalculateTotalPrice(testProduct));
            Assert.IsNotNull(pricePromo.ToString());
        }

        [TestMethod]
        public void CalculateTotalPriceTestB()
        {
            var priceTotal = new CartItem();
            Product productOrders = new Order()
            {
                Name = "B",
                Price = 30,
                Quantity = 5
            };
            List<Product> testProduct = new List<Product>();
            Assert.IsNotNull(productOrders.CalculateTotalPrice(testProduct));
            Assert.IsNotNull(priceTotal.ToString());
        }
        [TestMethod]
        public void CalculatePriceTestB()
        {
            //Arrange-Act-Assert 
            Product productOrders = new Order()
            {
                Name = "B",
                Price = 50,
                Quantity = 5
            };
            List<Product> testProduct = new List<Product>();
            Assert.IsNotNull(productOrders.CalculateTotalPrice(testProduct));
        }

        [TestMethod]
        public void ApplyPromotionsTestAB()
        {
            var pricePromo = new CartItem();
            Product productOrders = new Order()
            {
                Name = "A",
                Price = 45,
                Quantity = 5
            };
            List<Product> testProduct = new List<Product>();
            Assert.IsNotNull(productOrders.CalculateTotalPrice(testProduct));
            Assert.IsNotNull(pricePromo.ToString());
        }

        [TestMethod]
        public void CalculateTotalPriceTestCD()
        {
            var priceTotal = new CartItem();
            Product productOrders = new Order()
            {
                Name = "C",
                Price = 20,
                Quantity = 2
            };
            List<Product> testProduct = new List<Product>();
            Assert.IsNotNull(productOrders.CalculateTotalPrice(testProduct));
            Assert.IsNotNull(priceTotal.ToString());
        }
    }
}