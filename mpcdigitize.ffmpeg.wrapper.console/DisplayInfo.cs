using mpcdigitize.ffmpeg.wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    public class DisplayInfo
    {

        public void DisplayProgress(object sender, EncodingEventArgs e)
        {
            Console.WriteLine("Frame {0} Fps {1} Size {2} TimeInseconds {3} Bitrate {4} Speed {5} Position {6}}", e.Frame, e.Fps, e.Size, e.TimeInSeconds, e.Bitrate, e.Speed, e.Position);

        }
    }
}
