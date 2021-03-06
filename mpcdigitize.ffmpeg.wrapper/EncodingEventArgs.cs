﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MpcDigitize.FFmpeg.Net.Wrapper
{
    public class EncodingEventArgs: EventArgs
    {
        

        public string Frame { get; set; }
        public string Fps { get; set; }
        public string Size { get; set; }
        public string Time { get; set; }  
        public string Bitrate { get; set; }
        public string Speed { get; set;}
        public string Quantizer { get; set; }
        public string Data { get; set;}
        public double Progress { get; set; }
     

    }
}
