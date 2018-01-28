using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mpcdigitize.ffmpeg.wrapper.Extensions
{
    public static class Extensions
    {


        public static double GetProgress(this string line)
        {

            double progress = 0;

            try
            {
               


                string[] split = line.Split(' ');


                foreach (var row in split)
                {
                    if (row.StartsWith("time="))
                    {
                        var time = row.Split('=');
                        progress = TimeSpan.Parse(time[1]).TotalSeconds;
                     //   Console.WriteLine("Status Position - :" + Progress);
                    }
                }
            }
            catch { }


            return progress;



        }


    }
}
