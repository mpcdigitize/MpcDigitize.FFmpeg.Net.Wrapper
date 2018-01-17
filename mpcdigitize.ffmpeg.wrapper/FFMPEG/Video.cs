using Mpcdigitize.Ffmpeg.Wrapper;
using Mpcdigitize.Ffmpeg.Wrapper.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mpcdigitize.ffmpeg.wrapper
{
    public class Video
    {
        public Ffmpeg Ffmpeg { get; set; }
        private FfmpegArgumentsDictionary _arguments;
        public string mconsole;

        public string StringOutput = "";

        public Video()
        {
            _arguments = new FfmpegArgumentsDictionary();

        }


        public void Convert1(string inputFile, VideoEncoder videoEncoder, VideoResize videoResize, VideoPreset videoPreset, VideoConstantRateFactor videoConstantRateFactor, AudioCodec audioCodec, Bitrate audioBitrate, string outputFile)
        {
            //-vf scale=-1:720 -c:v libx264 -preset veryfast -crf 23 -c:a aac -b:a 160k

            var encodingEngine = new EncodingEngine();


            var arguments = "-i " + inputFile +
                            _arguments.GetValue(videoResize.ToString()) +
                            _arguments.GetValue(videoEncoder.ToString()) +
                            _arguments.GetValue(videoPreset.ToString()) +
                            _arguments.GetValue(videoConstantRateFactor.ToString()) +
                            _arguments.GetValue(audioCodec.ToString()) +
                            _arguments.GetValue(audioBitrate.ToString()) +
                            outputFile;


            // Console.WriteLine(arguments);


            encodingEngine.LaunchProcess(arguments, Ffmpeg.GetPath());
            // encodingEngine.StartEncoding(arguments, Ffmpeg.GetPath());
           // encodingEngine.StartProcess(arguments, Ffmpeg.GetPath());


        }

        Process process = new Process();


        public void Convert2(string inputFile, VideoEncoder videoEncoder, VideoResize videoResize, VideoPreset videoPreset, VideoConstantRateFactor videoConstantRateFactor, AudioCodec audioCodec, string outputFile)
        {
            //-vf scale=-1:720 -c:v libx264 -preset veryfast -crf 23 -c:a aac -b:a 160k

            var encodingEngine = new EncodingEngine();
            var jobStatus = new JobStatus(encodingEngine);


            var encoder = new Encoder();


            var arguments = "-i " + inputFile +
                            _arguments.GetValue(videoResize.ToString()) +
                            _arguments.GetValue(videoEncoder.ToString()) +
                            _arguments.GetValue(videoPreset.ToString()) +
                            _arguments.GetValue(videoConstantRateFactor.ToString()) +
                            _arguments.GetValue(audioCodec.ToString()) +
                            outputFile;

            encoder.SetProcess(arguments, Ffmpeg.GetPath());

            encoder.Start();

            Console.Write("TEST :" + encoder.ReadOutput());

            encoder.WaitForExit();


            ////  Console.WriteLine(arguments);

            ////var originalConsoleOut = Console.Out; // preserve the original stream

            //Console.WriteLine("UP: " + encodingEngine.WriteToConsole());
            //encodingEngine.LaunchProcess(arguments, Ffmpeg.GetPath());

            
            ////encodingEngine.StartEncoding(arguments, Ffmpeg.GetPath());
            ////encodingEngine.StartProcess(arguments, Ffmpeg.GetPath());


        }

        public void Convert3(string inputFile, VideoEncoder videoEncoder, VideoResize videoResize, VideoPreset videoPreset, VideoConstantRateFactor videoConstantRateFactor, AudioCodec audioCodec, string outputFile)
        {
            //-vf scale=-1:720 -c:v libx264 -preset veryfast -crf 23 -c:a aac -b:a 160k

           


            var encoder = new Encoder();


            var arguments = "-i " + inputFile +
                            _arguments.GetValue(videoResize.ToString()) +
                            _arguments.GetValue(videoEncoder.ToString()) +
                            _arguments.GetValue(videoPreset.ToString()) +
                            _arguments.GetValue(videoConstantRateFactor.ToString()) +
                            _arguments.GetValue(audioCodec.ToString()) +
                            outputFile;



            process.EnableRaisingEvents = true;
            process.OutputDataReceived += new System.Diagnostics.DataReceivedEventHandler(process_OutputDataReceived);
            process.ErrorDataReceived += new System.Diagnostics.DataReceivedEventHandler(process_ErrorDataReceived);
            process.Exited += new System.EventHandler(process_Exited);

            process.StartInfo.FileName = Ffmpeg.GetPath();
            process.StartInfo.Arguments = arguments;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.RedirectStandardOutput = true;

            process.Start();
            process.BeginErrorReadLine();
            process.BeginOutputReadLine();


            process.WaitForExit();

           

         
        }


        public void process_Exited(object sender, EventArgs e)
        {
            //  Console.WriteLine(string.Format("process exited with code {0}\n", process.ExitCode.ToString()));
        }

        public void process_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {


            //Console.WriteLine(e.Data); // or make your DLL calls :)

            // writer.Flush(); // when you're done, make sure everything is written out

            StringOutput = e.Data;


            string path = @"C:\videos\test.txt";
            using (var tw = new StreamWriter(path, true))
            {
                tw.WriteLine(StringOutput);
                tw.Close();
            }
          //  Console.WriteLine(StringOutput);

           // return StringOutput;
        }


           


            // this.WriteToConsole();

            //  Console.Write("TT: " + output);
            //using (var outputCapture = new OutputCapture())
            //{
            //    // Console.SetOut(e.Data);
            //    //  Console.Write("test");
            //    Console.WriteLine(e.Data);
            //  //  outputCapture.WriteLine("captured: " + e.Data);
            //    //Console.Write("Second line");
            //    // Now you can look in this exact copy of what you've been outputting.
            //    output = outputCapture.Captured.ToString();
            //}

            ////  Console.WriteLine(e.Data + "\n");
            //// this.GetOutput(output);
            //Console.WriteLine("OU: " + output.Length);
        

        public void process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            // Console.WriteLine(e.Data + "\n");
        }

    

}
}
