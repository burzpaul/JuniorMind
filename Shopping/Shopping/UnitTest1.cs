using System;
using System.Linq;
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
            double expected = 28.76;
            double delta = 1;
            Assert.AreEqual(expected, CalculateTotalCost(shoppingItems), delta);
        }
        [TestMethod]
        public void TheCheapestItem()
        {
            var shoppingItems = new ShoppingCart[] { new ShoppingCart("Tide", 17.32), new ShoppingCart("Soap", 3.45), new ShoppingCart("CaptainCrunch", 7.99), new ShoppingCart("BubbleGum", 1.25), new ShoppingCart("AfterShave",3.75)};
            Assert.AreEqual(shoppingItems[3].productName, FindItem(shoppingItems,false));
        }
        [TestMethod]
        public void EliminateMostExpensiveItem()
        {
            var shoppingItems = new ShoppingCart[] { new ShoppingCart("Tide", 17.32), new ShoppingCart("Soap", 3.45), new ShoppingCart("CaptainCrunch", 7.99), new ShoppingCart("BubbleGum", 1.25), new ShoppingCart("AfterShave", 3.75) };
            EliminateMostExpensiveItem(shoppingItems);
            Assert.AreEqual(shoppingItems[1].productName, FindItem(shoppingItems, true));
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
        private string FindItem(ShoppingCart[] shoppingItems, bool whatItem)
        {
            double element = 0;
            string item = null;
            if (whatItem)
                for (int i = 0; i < shoppingItems.Length; i++)

                    if (element < shoppingItems[i].productCost)
                    {
                        element = shoppingItems[i].productCost;
                        item = shoppingItems[i].productName;
                    }
                        

            if (!whatItem)
              element = shoppingItems[0].productCost;
            for (int i = 0; i < shoppingItems.Length; i++)

                if (element > shoppingItems[i].productCost)
                {
                    element = shoppingItems[i].productCost;
                    item = shoppingItems[i].productName;
                }
            
            return item;
        }
        private void EliminateMostExpensiveItem(ShoppingCart[] shoppingItems)
        {
            for (int i = 0; i < shoppingItems.Length; i++)
                if (FindItem(shoppingItems, true) == shoppingItems[i].productName)
                    for (int j = i; j < shoppingItems.Length-1; j++)
                    {
                        shoppingItems[j].productName = shoppingItems[j + 1].productName;
                        shoppingItems[j].productCost = shoppingItems[j + 1].productCost;
                    }
            Array.Resize(ref shoppingItems, shoppingItems.Length - 1);             
        }
    }
}
