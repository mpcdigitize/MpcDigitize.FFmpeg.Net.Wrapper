
using MpcDigitize.FFmpeg.Net.Wrapper;
using System;

namespace ConsoleApplication
{
    public class Program
    {
        static void Main(string[] args)
        {


            
            var ffmpeg = new EncodingEngine(@"C:\ffmpeg\ffmpeg.exe");
            //var arguments = new EncodingArgs();
            var job = new EncodingJob();
            var videoArgs = new VideoArgs();
            var audioArgs = new AudioArgs();
      


            var inputFile = @"C:\input\test File.wtv";
            //var outputFile = @"C:\videos\test Convert1.mkv";
            //var outputFile = @"C:\videos\testConvert1 thumb.jpg";
            //var audioOutputFile = @"C:\videos\testMp3.mp3";
            var outputFile = @"C:\videos\test_AudioAc3.ac3";

            //video convert
            //job.Arguments = videoArgs.Convert(inputFile,VideoEncoder.Libx264, VideoResize.TV720p,
            //                             VideoPreset.VeryFast, ConstantRateFactor.CrfNormal, AudioCodec.Ac3, outputFile);

            //get video frame
            //job.Arguments = vargs.GetFrame(inputFile, 20, FrameSize.SizeThumbnail, outputFile);

            //convert audio from video
            //job.Arguments = audioArgs.Convert(inputFile,AudioEncoder.Libmp3lame,Bitrate.BitrateNormal, audioOutputFile);


            //var streamInput = "http://148.163.81.10:8006/";
            //var streamInput = "http://stream3.polskieradio.pl:8900/;stream";
            //var streamOutput = @"C:\videos\streamRadioAacToMp3.mp3";

            //audio stream capture
            //job.Arguments = audioArgs.Capture(streamInput,60, AudioEncoder.Libmp3lame, Bitrate.BitrateNormal,streamOutput);


            //extract audio stream from video
            job.Arguments = videoArgs.ExtractStream(inputFile, Streams.AudioStream, outputFile);




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
