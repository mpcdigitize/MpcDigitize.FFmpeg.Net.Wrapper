using Mpcdigitize.Ffmpeg.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mpcdigitize.ffmpeg.wrapper
{
    public class Video
    {
        public Ffmpeg Ffmpeg { get; set; }
        private FfmpegArgumentsDictionary _arguments;

        public Video()
        {
            _arguments = new FfmpegArgumentsDictionary();

        }

        public void DoSomething()
        {

            Console.WriteLine(Ffmpeg.GetPath());

            //  Console.WriteLine("DoSomething " + ffmpeg.GetPath());



        }
    }
}
