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
            var frame = Regex.Match(line, @"(frame=) (\d+)");

            return frame.Groups[2].Value;

        }

        public static string GetFps(this string line)
        {
            var fps = Regex.Match(line, @"(fps=)(\d+)");

            return fps.Groups[2].Value;

        }


        public static string GetSize(this string line)
        {
            var size = Regex.Match(line, @"(size=) (\d+)");

            return size.Groups[2].Value;

        }

        public static double GetTime(this string line)
        {
            double seconds = 0;
            var time = Regex.Match(line, @"(time=)(\d+:\d+:\d+.\d+)");


            seconds = TimeSpan.Parse(time.Groups[2].Value).TotalSeconds;
            return seconds;

        }


        public static string GetBitrate(this string line)
        {
            var bitrate = Regex.Match(line, @"(bitrate=) (\d+.\d+)");

            return bitrate.Groups[2].Value;

        }


        public static string GetSpeed(this string line)
        {
            var speed = Regex.Match(line, @"(speed=)(\d+.\d+)");

            return speed.Groups[2].Value;

        }


        public static string GetPosition(this string line)
        {
            var position = Regex.Match(line, @"(Status Position - :)(\d+.\d+)");

            return position.Groups[2].Value;

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
