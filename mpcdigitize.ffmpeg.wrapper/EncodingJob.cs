using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mpcdigitize.ffmpeg.wrapper
{
    public class EncodingJob
    {

        public string InputFile { get; set; }
        public string OutputFile { get; set; }
        public string ConversionArguments { get; set; }
    }
}
