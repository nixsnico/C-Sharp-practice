using Figgle.Fonts;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;


namespace myNamespace
{
    class programm
    {
        static void Main()
        {
            int lastSecond = -1;
            while (true)
            {
                string date = DateTime.Now.ToString("HH : mm : ss");
                DateTime currentTime = DateTime.Now;
                int second = currentTime.Second;

                int timeUntilHour = 12 - currentTime.Hour;
                int timeUntilMinute = 59 - currentTime.Minute;
                int timeUntilSecond = 59 - currentTime.Second;
                int timeElapsedHour = 5 - timeUntilHour;
                int timeElapsedMinute = 59 - timeUntilMinute;
                int timeElapsedSecond = 59 - timeUntilSecond;


                //int timeUNtilMinute1 = 89 - currentTime.Minute;

                if (second != lastSecond)
                {
                    Console.Clear();
                    Console.WriteLine(FiggleFonts.Standard.Render("Current time:              " + date));
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(FiggleFonts.Standard.Render("Time until   13 : 00:    " + timeUntilHour + " : " + timeUntilMinute + " : " + timeUntilSecond));
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(FiggleFonts.Standard.Render("Time elapsed:                       " + timeElapsedHour + " : " + timeElapsedMinute + " : " + timeElapsedSecond));
                    Console.ForegroundColor = ConsoleColor.White;
                    //Console.Write("Time until 17:30: " + timeUntilHour + " hours and " + timeUNtilMinute1 + " minutes and " + timeUntilSecond + " seconds");
                    lastSecond = second;
                }
            }
        }
    }
}
 