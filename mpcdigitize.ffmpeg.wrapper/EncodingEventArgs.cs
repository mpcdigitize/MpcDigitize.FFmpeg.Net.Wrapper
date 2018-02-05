using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mpcdigitize.ffmpeg.wrapper
{
    public class EncodingEventArgs: EventArgs
    {
        

        public string Frame { get; set; }
        public string Fps { get; set; }
        public string Size { get; set; }
        public string Time { get; set; }
        public string TimeInSeconds { get; set; }
        public string Bitrate { get; set; }
        public string Speed { get; set;}
        public string Position { get; set;}
        public string Data { get; set;} 
       
    }
}
