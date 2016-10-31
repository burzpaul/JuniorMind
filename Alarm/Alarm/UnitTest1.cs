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
            var weekAlarm = new Alarm { hour = 6, day = DaysOfTheWeek.Tuesday | DaysOfTheWeek.Wednesday | DaysOfTheWeek.Thursday | DaysOfTheWeek.Friday };
            var weekendAlarm = new Alarm { hour = 8, day = DaysOfTheWeek.Saturday | DaysOfTheWeek.Saturday };
            Assert.AreEqual(false, VerifyAlarm(6,weekAlarm));//Monday was not set
            Assert.AreEqual(false, VerifyAlarm(8,weekAlarm));
            Assert.AreEqual(true, VerifyAlarm(6,weekAlarm));
            Assert.AreEqual(false, VerifyAlarm(15,weekAlarm));
            Assert.AreEqual(true, VerifyAlarm(6,weekAlarm));
            Assert.AreEqual(false, VerifyAlarm(14, weekAlarm));
            Assert.AreEqual(true, VerifyAlarm(8,weekendAlarm));
            Assert.AreEqual(false, VerifyAlarm(9,weekendAlarm));

        }
        [Flags]
        enum DaysOfTheWeek
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
            
            public int hour;
            public DaysOfTheWeek day;
            public Alarm( int hour, DaysOfTheWeek day)
            {
                this.day = day;
                this.hour = hour;
            }
        }
        private bool VerifyAlarm(int hour,Alarm alarm)
        {  
                       if(hour == alarm.hour)
                            return true;           
            return false;
        }
    }
}