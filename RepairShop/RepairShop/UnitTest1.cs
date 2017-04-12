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
        public void TestMethod1()
        {
            var ordersInfo = new OrdersInfo[] { new OrdersInfo(3, "Engine", PriorityLevels.High),
                                                new OrdersInfo(5,"Direction",PriorityLevels.High),
                                                new OrdersInfo( 1, "Wheels", PriorityLevels.Medium),
                                                new OrdersInfo( 4, "FrontWindows", PriorityLevels.Medium),
                                                new OrdersInfo( 6, "Seat", PriorityLevels.Low),
                                                new OrdersInfo( 2, "Mirrors", PriorityLevels.Low)};

            var unorganizedOrders = new OrdersInfo[] { new OrdersInfo(1, "Wheels", PriorityLevels.Medium),
                                                new OrdersInfo(2,"Mirrors",PriorityLevels.Low),
                                                new OrdersInfo( 3, "Engine", PriorityLevels.High),
                                                new OrdersInfo( 4, "FrontWindows", PriorityLevels.Medium),
                                                new OrdersInfo( 5, "Direction", PriorityLevels.High),
                                                new OrdersInfo( 6, "Seat", PriorityLevels.Low)};

            Assert.AreEqual(ordersInfo, OrderTheOrders(unorganizedOrders));
        }
        [TestMethod]
        public void MyTestMethod()
        {
            var a = new OrdersInfo(2, "Mirrors", PriorityLevels.Low);
            var b = new OrdersInfo(3, "Engine", PriorityLevels.High);
            Swap(ref b, ref a);
            Assert.AreEqual(b.orderProblem, "Mirrors");
        }
        private OrdersInfo[] OrderTheOrders(OrdersInfo[] ordersInformation)
        {
            QuickSort(ordersInformation, 0, ordersInformation.Length - 1);
            return ordersInformation;
        }

        private void QuickSort(OrdersInfo[] ordersInformation, int left, int right)
        {
            if (right <= left)
                return;
            if(ordersInformation[right].priorityLevel < ordersInformation[left].priorityLevel)
            {
                Swap(ref ordersInformation[left], ref ordersInformation[right]);
            }
            int i = left + 1;
            int j = right - 1;
            int k = left + 1;
            
            while(i <= j )
            {
                if (ordersInformation[i].priorityLevel < ordersInformation[left].priorityLevel)
                    Swap(ref ordersInformation[i++], ref ordersInformation[k++]);
                else if (ordersInformation[right].priorityLevel < ordersInformation[j].priorityLevel)
                    Swap(ref ordersInformation[k], ref ordersInformation[j--]);
                else k++;
            }
            Swap(ref ordersInformation[left], ref ordersInformation[--i]);
            Swap(ref ordersInformation[right],ref ordersInformation[++j]);

            QuickSort(ordersInformation, left, i - 1);
            if (ordersInformation[i].priorityLevel < ordersInformation[j].priorityLevel)
                QuickSort(ordersInformation, i++, j--);
            QuickSort(ordersInformation, j++, right);
        }

        private void Swap(ref OrdersInfo ordersInfo1, ref OrdersInfo ordersInfo2)
        {
            var temp = new OrdersInfo();
            temp = ordersInfo1;
            ordersInfo1 = ordersInfo2;
            ordersInfo2 = temp;
        }
    }
}
