using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Shopping
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CalculateTotalCost()
        {
            var shoppingItems = new Product[] { new Product("Tide", 17.32),new Product("Soap",3.45),new Product("CaptainCrunch",7.99)};
            double expected = 28.76;
            double delta = 1;
            Assert.AreEqual(expected, CalculateTotalCost(shoppingItems), delta);
        }
        [TestMethod]
        public void TheCheapestItem()
        {
            var shoppingItems = new Product[] { new Product("Tide", 17.32), new Product("Soap", 3.45), new Product("CaptainCrunch", 7.99), new Product("BubbleGum", 1.25), new Product("AfterShave",3.75)};
            Assert.AreEqual(shoppingItems[3].productName, FindCheapestItem(shoppingItems));
        }
        [TestMethod]
        public void FindMostExpensiveItem()
        {
            var shoppingItems = new Product[] { new Product("Tide", 17.32), new Product("Soap", 3.45), new Product("CaptainCrunch", 7.99), new Product("BubbleGum", 1.25), new Product("AfterShave", 3.75) };
            Assert.AreEqual(shoppingItems[0].productName, FindMostExpensiveItem(shoppingItems));
        }
        [TestMethod]
        public void EliminateMostExpensiveItem()
        {
            var shoppingItems = new Product[] { new Product("Tide", 17.32), new Product("Soap", 3.45), new Product("CaptainCrunch", 7.99), new Product("BubbleGum", 1.25), new Product("AfterShave", 3.75) };
            EliminateMostExpensiveItem(shoppingItems);
            Assert.AreEqual("CaptainCrunch", FindMostExpensiveItem(shoppingItems));
        }
        [TestMethod]
        public void AddNewItem()
        {
            var shoppingItems = new Product[] { new Product("Tide", 17.32), new Product("Soap", 3.45), new Product("CaptainCrunch", 7.99), new Product("BubbleGum", 1.25), new Product("AfterShave", 3.75) };
            int a = shoppingItems.Length;
            AddNewItem(shoppingItems, "Magnum P51 Mustang", 88.999);
            Assert.AreEqual(a, shoppingItems.Length);
        }
        [TestMethod]
        public void AveragePrice()
        {
            var shoppingItems = new Product[] { new Product("Tide", 17.32), new Product("Soap", 3.45), new Product("CaptainCrunch", 7.99), new Product("BubbleGum", 1.25), new Product("AfterShave", 3.75) };
            double expected = 6.752;
            double delta = 1;
            Assert.AreEqual(expected, CalculateAveragePrice(shoppingItems), delta);
        }
        struct Product
        {
            public string productName;
            public double productCost;
            public Product (string productName, double productCost)
            {
                this.productName = productName;
                this.productCost = productCost;
            }
        }
        private double CalculateTotalCost(Product[] shoppingItems)
        {
            double total = 0;
            for (int i = 0; i < shoppingItems.Length; i++)
                total += shoppingItems[i].productCost;
            return total;
        }
        private string FindMostExpensiveItem(Product[] shoppingItems)
        {
            double element = 0;
            int position = 0;
                for (int i = 0; i < shoppingItems.Length; i++)
                    if (element < shoppingItems[i].productCost)
                    {
                        element = shoppingItems[i].productCost;
                    position = i;
                    }
            return shoppingItems[position].productName;
        }
        private string FindCheapestItem(Product[] shoppingItems)
        {
            double element = shoppingItems[0].productCost;
            int position = 0;
            for (int i = 1; i < shoppingItems.Length; i++)
                if (element > shoppingItems[i].productCost)
                {
                    element = shoppingItems[i].productCost;
                    position = i;
                }
            return shoppingItems[position].productName;
        }
        private void EliminateMostExpensiveItem(Product[] shoppingItems)
        {
            int i = 0;
            for (i = 0; i < shoppingItems.Length; i++)
                if (FindMostExpensiveItem(shoppingItems) == shoppingItems[i].productName) 
                    break;
            for (int j = i; j < shoppingItems.Length; j++) 
            {
                if (j == shoppingItems.Length - 1)
                {
                    Array.Resize(ref shoppingItems, shoppingItems.Length - 1);
                    break;
                }
                    shoppingItems[j].productName = shoppingItems[j + 1].productName;
                    shoppingItems[j].productCost = shoppingItems[j + 1].productCost;
            }       
        }
        private void AddNewItem(Product[] shoppingItems, string newItemName, double newItemCost)
        {
            Array.Resize(ref shoppingItems, shoppingItems.Length + 1);
            shoppingItems[shoppingItems.Length - 1].productName = newItemName;
            shoppingItems[shoppingItems.Length - 1].productCost = newItemCost;
        }
        private double CalculateAveragePrice(Product[] shoppingItems)
        {
            return CalculateTotalCost(shoppingItems)/shoppingItems.Length;
        }
    }
}