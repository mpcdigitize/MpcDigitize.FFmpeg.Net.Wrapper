using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using mpcdigitize.ffmpeg.wrapper.Enums;

namespace mpcdigitize.ffmpeg.wrapper.Extensions
{
    public static class Extensions
    {

        public static string GetRegexValue(this string line, RegexKey regexKey, RegexGroup regexGroup)
        {
            string result = "";
            string replaceLine = "";

            var patterns = new RegexPatterns();
            var keys = patterns.GetValue(regexKey);

            if (line != null)
            {

                replaceLine = Regex.Replace(line, keys.OriginalKey, keys.ReplaceKey);
                var frame = Regex.Match(replaceLine, keys.RegexSearchKey);

                result = frame.Groups[(int)regexGroup].Value;


            }


             return result;



        }


        public static string GetFrame(this string line)
        {
            string result = "";
            string replaceLine = "";

            if (line != null)
            {

                replaceLine = Regex.Replace(line, "frame=", "frame= ");
                var frame = Regex.Match(replaceLine, @"(frame=) +(\d+)");

                result = frame.Groups[2].Value;


            }

         
                return result;
     

        }

        public static string GetQuantizer(this string line)
        {
            string result = "";
            string replaceLine = "";

            if (line != null)
            {

                replaceLine = Regex.Replace(line, "q=", "q= ");
                var quantizer = Regex.Match(replaceLine, @"(q=) +(\d+\.\d+)");

                result = quantizer.Groups[2].Value;


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

              
                var time = Regex.Match(line, @"(time=)(\d+:\d+:\d+.\d+)");
                result =  time.Groups[2].Value;
                

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


      
    


        public static double ParseTotalSeconds(this string time)
        {
            double totalSeconds = 0;

            TimeSpan result;

            if (TimeSpan.TryParse(time, out result))
            {
                totalSeconds = result.TotalSeconds;
            }
            return totalSeconds;


        }


    }
}
