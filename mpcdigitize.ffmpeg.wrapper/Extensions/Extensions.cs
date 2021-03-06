﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace MpcDigitize.FFmpeg.Net.Wrapper
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
                var match = Regex.Match(replaceLine, keys.RegexSearchKey);

                result = match.Groups[(int)regexGroup].Value;


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
