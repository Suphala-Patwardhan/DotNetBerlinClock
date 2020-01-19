using System;
using System.Text.RegularExpressions;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        public string convertTime(string aTime)
        {

            #region splitting the string to get hours, minutes and seconds separately
            string[] arr = aTime.Split(':');
            if (arr.Length != 3)
            {
                Console.WriteLine("String entered is not in correct format");
            }
            int[] timeArray = new int[3];
            int count = 0;
            foreach (string st in arr)
            {
                try
                {
                    timeArray[count++] = Convert.ToInt32(st);
                }
                catch (FormatException)
                {
                    Console.WriteLine("The string value '{1}' is not in a recognizable format.", st);
                }
            }
            if (timeArray[0] < 0 || timeArray[0] > 24 || timeArray[1] < 0 || timeArray[1] > 59 || timeArray[2] < 0 || timeArray[2] > 59)
            {
                Console.WriteLine("Please enter time in correct format.");
            }
            #endregion

            string[] myTime = new string[5];

            #region determining the value for Row 1
            myTime[0] = timeArray[2] % 2 == 0 ? "Y" : "O";
            #endregion

            #region determining the value for Row 2
            int tempHrs = timeArray[0] / 5;
            myTime[1] = "OOOO";
            var regex = new Regex(Regex.Escape("O"));
            myTime[1] = regex.Replace(myTime[1], "R", tempHrs);
            #endregion

            #region determining the value for Row 3
            tempHrs = timeArray[0] % 5;
            myTime[2] = "OOOO";
            regex = new Regex(Regex.Escape("O"));
            myTime[2] = regex.Replace(myTime[2], "R", tempHrs);
            #endregion

            #region determining the value for Row 4
            int tempmin = timeArray[1] / 5;
            myTime[3] = "";
            for (count = 1; count <= tempmin; count++)
                myTime[3] = count % 3 == 0 ? myTime[3] + "R" : myTime[3] + "Y";
            
            while (tempmin < 11)
            {
                myTime[3] += "O";
                tempmin++;
            }
            #endregion

            #region determining the value for Row 5
            int tempSecMod = timeArray[2] % 5;
            myTime[4] = "OOOO";
            regex = new Regex(Regex.Escape("O"));
            myTime[4] = regex.Replace(myTime[4], "Y", tempSecMod);
            #endregion

            string time = string.Join("\r\n", myTime);
            return time;
        }
    }
}
