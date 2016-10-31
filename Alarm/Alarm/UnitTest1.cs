using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Alarm
{
    [TestClass]
    public class AlarmProject  
    {
        [TestMethod]
        public void TestTheAlarm()
        {
            var weekAlarm = new Alarm { hour = 6, day = DayOfWeek.Monday | DayOfWeek.Tuesday | DayOfWeek.Wednesday | DayOfWeek.Thursday | DayOfWeek.Friday };
            var weekendAlarm = new Alarm { hour = 8, day = DayOfWeek.Saturday | DayOfWeek.Saturday };
            Assert.AreEqual(true, VerifyAlarm(6, DayOfWeek.Monday));

        }
        [Flags]
        enum Days
        { 
            Monday = 0x1,
            Tuesday = 0x2,
            Wednesday = 0x4,
            Thursday = 0x8,
            Friday = 0x10,
            Saturday = 0x20,
            Sunday = 0x40
        }
        struct Alarm
        {
            public DayOfWeek day;
            public int hour;
            public Alarm(DayOfWeek day, int hour)
            {
                this.day = day;
                this.hour = hour;
            }
        }
        private bool VerifyAlarm(int v, DayOfWeek monday)
        {
            throw new NotImplementedException();
        }
    }
}
