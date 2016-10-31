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
            var alarms = new Alarm[] { new Alarm(0,DayOfWeek.Monday),
                                          new Alarm(6,DayOfWeek.Tuesday),
                                          new Alarm(7,DayOfWeek.Wednesday),
                                          new Alarm(6,DayOfWeek.Thursday),
                                          new Alarm(14,DayOfWeek.Friday),
                                          new Alarm(6,DayOfWeek.Saturday),
                                          new Alarm(8,DayOfWeek.Sunday)};
                            
            Assert.AreEqual(false, VerifyAlarm(6, DayOfWeek.Monday, alarms[0]));
            Assert.AreEqual(true, VerifyAlarm(6, DayOfWeek.Tuesday, alarms[1]));
            Assert.AreEqual(false, VerifyAlarm(6, DayOfWeek.Wednesday, alarms[2]));
            Assert.AreEqual(true, VerifyAlarm(6, DayOfWeek.Thursday, alarms[3]));
            Assert.AreEqual(false, VerifyAlarm(6, DayOfWeek.Friday, alarms[4]));
            Assert.AreEqual(false, VerifyAlarm(8, DayOfWeek.Saturday, alarms[5]));
            Assert.AreEqual(true, VerifyAlarm(8, DayOfWeek.Sunday, alarms[6]));
        }
        struct Alarm
        {
            
            public int hour;
            public DayOfWeek day;
            public Alarm( int hour, DayOfWeek day)
            {
                this.day = day;
                this.hour = hour;
            }
        }
        private bool VerifyAlarm(int hour,DayOfWeek day,Alarm alarm)
        {  
                if (((day & alarm.day) >= 0) && ((hour & alarm.hour) != 0))
                       if(hour == alarm.hour)
                            return true;           
            return false;
        }
    }
}
