using mpcdigitize.ffmpeg.wrapper.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mpcdigitize.ffmpeg.wrapper
{
    public class RegexPatterns
    {
        private Dictionary<string, RegexSearchPattern> _patterns;

        public RegexPatterns ()
        {
            _patterns = new Dictionary<string, RegexSearchPattern>();


           // replaceLine = Regex.Replace(line, "frame=", "frame= ");
            //var frame = Regex.Match(replaceLine, @"(frame=) +(\d+)");
            _patterns.Add("Frame", new RegexSearchPattern() {OriginalKey = "frame=", ReplaceKey = "frame= ", RegexSearchKey = @"(frame=) +(\d+)" });

        }


        public RegexSearchPattern GetValue(RegexKey regexKey)
        {

            // string value = "";

            RegexSearchPattern regexSearchPattern = new RegexSearchPattern();

            _patterns.TryGetValue(regexKey.ToString(), out regexSearchPattern);

            return regexSearchPattern;
        }

    }
}
