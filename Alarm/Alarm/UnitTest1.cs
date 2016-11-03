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
            var weekendAlarm = new Alarm { hour = 8, day = DaysOfTheWeek.Saturday | DaysOfTheWeek.Sunday };
            Assert.AreEqual(false, VerifyAlarm(6, DaysOfTheWeek.Monday,weekAlarm));//Monday was not set
            Assert.AreEqual(false, VerifyAlarm(8, DaysOfTheWeek.Tuesday, weekAlarm));
            Assert.AreEqual(true, VerifyAlarm(6, DaysOfTheWeek.Wednesday, weekAlarm));
            Assert.AreEqual(false, VerifyAlarm(0, DaysOfTheWeek.Thursday, weekAlarm));
            Assert.AreEqual(true, VerifyAlarm(6, DaysOfTheWeek.Friday, weekAlarm));
            Assert.AreEqual(false, VerifyAlarm(0, DaysOfTheWeek.Saturday, weekendAlarm));
            Assert.AreEqual(true, VerifyAlarm(8, DaysOfTheWeek.Sunday, weekendAlarm));
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
            
            public byte hour;
            public DaysOfTheWeek day;
            public Alarm(byte hour, DaysOfTheWeek day)
            {
                this.day = day;
                this.hour = hour;
            }
        }
        private bool VerifyAlarm(byte hour,DaysOfTheWeek day,Alarm alarm)
        {    
                return ((day & alarm.day) == 0) & ((hour & alarm.hour) == 0);           
        }
    }
}