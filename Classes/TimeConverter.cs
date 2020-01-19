using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        public string convertTime(string aTime)
        {
            string time = string.Empty;
            string[] arr = aTime.Split(':');            
            int[] timeArray = new int[3];
            int count = 0;
            foreach (string st in arr)
                timeArray[count++] = Convert.ToInt32(st);

            string[] myTime = new string[5];

            myTime[0] = timeArray[2] % 2 == 0 ? "Y" : "O";
            int tempHrs = timeArray[0] / 5;
            switch (tempHrs)
            {
                case 0: myTime[1] = "OOOO"; break;
                case 1: myTime[1] = "ROOO"; break;
                case 2: myTime[1] = "RROO"; break;
                case 3: myTime[1] = "RRRO"; break;
                case 4: myTime[1] = "RRRR"; break;
                default:
                    break;
            }
            tempHrs = timeArray[0] % 5;
            switch (tempHrs)
            {
                case 0: myTime[2] = "OOOO"; break;
                case 1: myTime[2] = "ROOO"; break;
                case 2: myTime[2] = "RROO"; break;
                case 3: myTime[2] = "RRRO"; break;
                case 4: myTime[2] = "RRRR"; break;
                default:
                    break;
            }
            int tempmin = timeArray[1] / 5;
            myTime[3] = "";
            for (count = 1; count <= tempmin; count++)
            {
                myTime[3] = count % 3 == 0 ? myTime[3] + "R" : myTime[3] + "Y";
            }
            while (tempmin < 11)
            {
                myTime[3] += "O";
                tempmin++;
            }            
            int tempSecMod = timeArray[2] % 5;
            switch (tempSecMod)
            {
                case 0: myTime[4] = "OOOO"; break;
                case 1: myTime[4] = "YOOO"; break;
                case 2: myTime[4] = "YYOO"; break;
                case 3: myTime[4] = "YYYO"; break;
                case 4: myTime[4] = "YYYY"; break;
                default:
                    break;
            }
            time = System.String.Join("\r\n", myTime);
            return time;
        }
    }
}
