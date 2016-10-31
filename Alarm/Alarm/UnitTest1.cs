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
            Assert.AreEqual(false, VerifyAlarm(6, DaysOfTheWeek.Monday, weekAlarm));//Monday was not set
            Assert.AreEqual(false, VerifyAlarm(8, DaysOfTheWeek.Monday, weekAlarm));
            Assert.AreEqual(true, VerifyAlarm(6, DaysOfTheWeek.Tuesday, weekAlarm));
            Assert.AreEqual(false, VerifyAlarm(15, DaysOfTheWeek.Wednesday, weekAlarm));
            Assert.AreEqual(true, VerifyAlarm(6, DaysOfTheWeek.Thursday, weekAlarm));
            Assert.AreEqual(false, VerifyAlarm(14, DaysOfTheWeek.Friday, weekAlarm));
            Assert.AreEqual(true, VerifyAlarm(8, DaysOfTheWeek.Saturday, weekendAlarm));
            Assert.AreEqual(false, VerifyAlarm(9, DaysOfTheWeek.Sunday, weekendAlarm));
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
            public DaysOfTheWeek day;
            public int hour;
            public Alarm(DaysOfTheWeek day, int hour)
            {
                this.day = day;
                this.hour = hour;
            }
        }
        private bool VerifyAlarm(int hour,DaysOfTheWeek day,Alarm alarm)
        {  
                if (((day & alarm.day) != 0) && ((hour & alarm.hour) != 0))
                       if(hour == alarm.hour)
                            return true;           
            return false;
        }
    }
}
