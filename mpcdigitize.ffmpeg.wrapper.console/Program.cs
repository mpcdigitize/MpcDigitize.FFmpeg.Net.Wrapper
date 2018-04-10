
using MpcDigitize.FFmpeg.Net.Wrapper;
using System;

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
      


            var inputFile = @"C:\input\test File.wtv";
            //var outputFile = @"C:\videos\testConvert1.mkv";
            var outputFile = @"C:\videos\testConvert1_thumb.jpg";


            // job.Arguments = vargs.Convert(inputFile,VideoEncoder.Libx264, VideoResize.TV720p, VideoPreset.VeryFast, ConstantRateFactor.CrfNormal, AudioCodec.Ac3, outputFile);
            job.Arguments = vargs.GetFrame(inputFile, 20, FrameSize.SizeThumbnail, outputFile);
         
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
