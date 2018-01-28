using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mpcdigitize.ffmpeg.wrapper
{
    public class EncodingEventArgs
    {

        public string Duration { get; set; }
        public double Progress { get; set; }
        public string InputFile { get; set; }
        public string OutputFile { get; set; }
        public string Data { get; set; }
    }
}
