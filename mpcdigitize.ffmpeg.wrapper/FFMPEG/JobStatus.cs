using Mpcdigitize.Ffmpeg.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mpcdigitize.ffmpeg.wrapper
{
    public class JobStatus
    {
        public Double Duration { get; set;}
        public string ConsoleOutput { get; set; }
        public EncodingEngine EncodingEngine { get; set;}

        public JobStatus(EncodingEngine encodingEngine)
        {
            EncodingEngine = encodingEngine;

        }


    }
}
