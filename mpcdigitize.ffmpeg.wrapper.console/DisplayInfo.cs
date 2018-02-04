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
            Console.WriteLine("HANDLER 2 : Progress > " + e.Progress + "  DATA > " + e.Data);

        }
    }
}
