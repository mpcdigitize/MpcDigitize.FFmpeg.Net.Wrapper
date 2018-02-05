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
            _patterns.Add("Fps", new RegexSearchPattern() { OriginalKey = "fps=", ReplaceKey = "fps= ", RegexSearchKey = @"(fps=) +(\d+)" });
            _patterns.Add("Time", new RegexSearchPattern() { OriginalKey = "time=", ReplaceKey = "time= ", RegexSearchKey = @"(time=) +(\d+:\d+:\d+.\d+)" });
            _patterns.Add("Size", new RegexSearchPattern() { OriginalKey = "size=", ReplaceKey = "size= ", RegexSearchKey = @"(size=) +(\d+\w+)" });
            _patterns.Add("Bitrate", new RegexSearchPattern() { OriginalKey = "bitrate=", ReplaceKey = "bitrate= ", RegexSearchKey = @"(bitrate=) +(\d+.\d+\w+\/\w+)" });
            _patterns.Add("Speed", new RegexSearchPattern() { OriginalKey = "speed=", ReplaceKey = "speed= ", RegexSearchKey = @"(speed=) +(\d+.\d+\w+)" });
            _patterns.Add("Quantizer", new RegexSearchPattern() { OriginalKey = "q=", ReplaceKey = "q= ", RegexSearchKey = @"(q=) +(\d+\.\d+)" });
           // _patterns.Add("Progress", new RegexSearchPattern() { OriginalKey = "frame=", ReplaceKey = "frame= ", RegexSearchKey = @"(frame=) +(\d+)" });
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
