
using MpcDigitize.FFmpeg.Net.Wrapper;
using MpcDigitize.Wtv.FFprobe.Wrapper;
using MpcDigitize.Wtv.FFprobe.Wrapper.Enums;
using MpcDigitize.Wtv.FFprobe.Wrapper.Extensions;
using System;

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    public class Program
    {
        static void Main(string[] args)
        {


            
            var ffmpeg = new EncodingEngine(@"C:\ffmpeg\ffmpeg.exe");
            var arguments = new EncodingArgs();
            var job = new EncodingJob();
            var vargs = new VideoArgs();
      


            var inputFile = @"C:\input\test.wtv";
            var outputFile = @"C:\videos\testConvert.mkv";


             job.Arguments = vargs.Convert(inputFile,VideoEncoder.Libx264, VideoResize.TV720p, VideoPreset.VeryFast, ConstantRateFactor.CrfNormal, AudioCodec.Ac3, outputFile);
         
            string title = "My conversion test file";

            job.Metadata = title;

            ffmpeg.VideoEncoding += DisplayProgress;
            ffmpeg.VideoEncoded += DisplayCompleted;
            ffmpeg.Exited += DisplayExitCode;
         

            ffmpeg.DoWork(job);
           
            Console.WriteLine("Completed");
            Console.ReadLine();


        }


        public static void DisplayProgress(object sender, EncodingEventArgs e)
        {

            Console.WriteLine("Frame {0} Fps {1} Size {2} Time {3} Bitrate {4} Speed {5} Quantizer {6} Progress {7}",
                e.Frame, e.Fps, e.Size, e.Time, e.Bitrate, e.Speed, e.Quantizer, e.Progress);


        }


        public static void DisplayCompleted(object sender, EncodedEventArgs e)
        {

            var meta = (string)e.EncodingJob.Metadata;
            Console.WriteLine("Title : {0}", meta);


        }

        public static void DisplayExitCode(object sender, ExitedEventArgs e)
        {
            Console.WriteLine("ExitCode : {0}", e.ExitCode);


        }

       


    }
}
