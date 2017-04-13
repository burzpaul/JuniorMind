using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RepairShop
{
    [TestClass]
    public class UnitTest1
    {
        public enum PriorityLevels { Low=1,Medium,High};
        struct OrdersInfo
        {
            public int orderNumber;
            public string orderProblem;
            public PriorityLevels priorityLevel;

            public OrdersInfo(int orderNumber, string orderProblem, PriorityLevels priorityLevel)
            {
                this.orderNumber = orderNumber;
                this.orderProblem = orderProblem;
                this.priorityLevel = priorityLevel;
            }
        }
        [TestMethod]
        public void TestForAplication()
        {
            var ordersInfo = new OrdersInfo[] { new OrdersInfo(3, "Engine", PriorityLevels.High),
                                                new OrdersInfo(5,"Direction",PriorityLevels.High),
                                                new OrdersInfo( 1, "Wheels", PriorityLevels.Medium),
                                                new OrdersInfo( 4, "FrontWindows", PriorityLevels.Medium),
                                                new OrdersInfo( 2, "Mirrors", PriorityLevels.Low),
                                                new OrdersInfo( 6, "Seat", PriorityLevels.Low),};

            var unorganizedOrders = new OrdersInfo[] { new OrdersInfo(1, "Wheels", PriorityLevels.Medium),
                                                new OrdersInfo(2,"Mirrors",PriorityLevels.Low),
                                                new OrdersInfo( 3, "Engine", PriorityLevels.High),
                                                new OrdersInfo( 4, "FrontWindows", PriorityLevels.Medium),
                                                new OrdersInfo( 5, "Direction", PriorityLevels.High),
                                                new OrdersInfo( 6, "Seat", PriorityLevels.Low)};
            var a = OrderTheOrders(unorganizedOrders);

            CollectionAssert.AreEqual(ordersInfo, a);
        }
        [TestMethod]
        public void TestFor_When_Both_Have_EqualPriorityLevelButDifferentOrderNumber()
        {
            var order1 = new OrdersInfo[] { new OrdersInfo(2, "Heat", PriorityLevels.High), new OrdersInfo(1, "Wheels", PriorityLevels.High) };
            var order2 = new OrdersInfo(1, "Wheels", PriorityLevels.High);
            var actual = OrderTheOrders(order1)[0];
            Assert.AreEqual(order2.orderNumber, actual.orderNumber);
        }
        [TestMethod]
        public void TestForSwap()
        {
            var firstOrder = new OrdersInfo(2, "Mirrors", PriorityLevels.Low);
            var secondOrder = new OrdersInfo(3, "Engine", PriorityLevels.High);
            Swap(ref secondOrder, ref firstOrder);
            Assert.AreEqual(secondOrder.orderProblem, "Mirrors");
        }
        private OrdersInfo[] OrderTheOrders(OrdersInfo[] ordersInformation)
        {
            QuickSort3(ordersInformation, 0, ordersInformation.Length - 1);
            return ordersInformation;
        } 
            private void QuickSort3(OrdersInfo[] ordersInformation, int start, int end)
            {
                if (end < start) return;
                int left = start;
                int right = end;
                var pivot = ordersInformation[start];
                int index = start;
                while (index < right)
            {
                if (LessThen(pivot, ordersInformation[index]))
                {
                    Swap(ref ordersInformation[left++], ref ordersInformation[index++]);
                }
                else if (LessThen(ordersInformation[index], pivot)) 
                {
                    Swap(ref ordersInformation[index], ref ordersInformation[right--]);
                }
                else
                {
                    index++;
                }
            }
            QuickSort3(ordersInformation, start, left - 1);
            QuickSort3(ordersInformation, right + 1, end);
            }

        private static bool LessThen(OrdersInfo a, OrdersInfo b)
        {
            if (a.priorityLevel == b.priorityLevel)
                return a.orderNumber < b.orderNumber;
            return a.priorityLevel < b.priorityLevel;
        }

        private void Swap(ref OrdersInfo ordersInfo1, ref OrdersInfo ordersInfo2)
        {
            var temp = ordersInfo1;
            ordersInfo1 = ordersInfo2;
            ordersInfo2 = temp;
        }
    }
}
