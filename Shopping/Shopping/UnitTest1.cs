using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Shopping
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var shoppingItems = new ShoppingCart[] { new ShoppingCart("Tide", 17.32),new ShoppingCart("Soap",3.45),new ShoppingCart("CaptainCrunch",7.99)};
            double a = 28.76;
            double delta = 1;
            Assert.AreEqual(a, CalculateTotalCost(shoppingItems), delta);
        }
        struct ShoppingCart
        {
            public string productName;
            public double productCost;
            public ShoppingCart (string productName, double productCost)
            {
                this.productName = productName;
                this.productCost = productCost;
            }
        }

        private double CalculateTotalCost(ShoppingCart[] shoppingItems)
        {
            double total = 0;
            for (int i = 0; i < shoppingItems.Length; i++)
                total += shoppingItems[i].productCost;
            return total;
        }
    }
}
