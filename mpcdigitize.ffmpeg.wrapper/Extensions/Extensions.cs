using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace mpcdigitize.ffmpeg.wrapper.Extensions
{
    public static class Extensions
    {

        public static string GetFrame(this string line)
        {
            string result = "";

            if (line != null)
            {

                

                var frame = Regex.Match(line, @"(frame=) +(\d+)");

                //while (frame.Success)
                //{
                    result = frame.Groups[2].Value;
                //    frame.NextMatch();
                //}
                

            }

            return result;

           

        }

        public static string GetFps(this string line)
        {
            string result = "";

            if (line != null)
            {

                var fps = Regex.Match(line, @"(fps=)(\d+)");

               result =  fps.Groups[2].Value;

            }

            return result;

        }


        public static string GetSize(this string line)
        {

            string result = "";

            if (line != null)
            {
                var size = Regex.Match(line, @"(size=) +(\d+\w+)");

                result = size.Groups[2].Value;

            }

            return result;
        }

        public static string GetTime(this string line)
        {
            string result = "";

            if (line != null)
            {

                // double seconds = 0;
                var time = Regex.Match(line, @"(time=)(\d+:\d+:\d+.\d+)");


                //seconds = TimeSpan.Parse(time.Groups[2].Value).TotalSeconds;

                result =  time.Groups[2].Value;
                // return seconds;

            }

            return result;


        }


        public static string GetBitrate(this string line)
        {

            string result = "";
            string replaceLine = "";

            if (line != null)
            {
                replaceLine = Regex.Replace(line, "bitrate=", "bitrate= ");        
                var bitrate = Regex.Match(replaceLine, @"(bitrate=) +(\d+.\d+\w+\/\w+)");

                result =  bitrate.Groups[2].Value;
            }

            return result;
        }


        public static string GetSpeed(this string line)
        {

            string result = "";
            string replaceLine = "";

            if (line != null)
            {
                replaceLine = Regex.Replace(line, "speed=", "speed= ");
                var speed = Regex.Match(replaceLine, @"(speed=) +(\d+.\d+\w+)");

                result = speed.Groups[2].Value;

            }


            return result;
        }


        public static string GetPosition(this string line)
        {

            string result = "";

            if (line != null)
            {

                var position = Regex.Match(line, @"(Status Position - :)(\d+.\d+)");

            result =  position.Groups[2].Value;
            }


            return result;
        }


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
