
using MpcDigitize.FFmpeg.Net.Wrapper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    public class DisplayInfo
    {

        public void DisplayProgress(object sender, EncodingEventArgs e)
        {
         
            Console.WriteLine("Frame {0} Fps {1} Size {2} Time {3} Bitrate {4} Speed {5} Quantizer {6} Progress {7}",
                e.Frame, e.Fps, e.Size, e.Time, e.Bitrate, e.Speed, e.Quantizer, e.Progress);
        

        }


        public void DisplayCompleted(object sender, EncodedEventArgs e)
        {

            var meta = (string)e.EncodingJob.Metadata;
            Console.WriteLine("Title : {0}", meta );


        }

        public void DisplayExitCode(object sender, ExitedEventArgs e)
        {

            //var meta = (string)e.EncodingJob.Metadata;
            Console.WriteLine("ExitCode : {0}", e.ExitCode);


        }

        public void DisplayErrorMessage(object sender, ErrorEventArgs e)
        {

            //var meta = (string)e.EncodingJob.Metadata;
            Console.WriteLine("ErrorMessage : {0}", e.ErrorMessage);


        }
    }
}
