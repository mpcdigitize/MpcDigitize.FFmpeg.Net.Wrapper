using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mpcdigitize.ffmpeg.wrapper
{
    public class Encoder
    {
        private Process _process;
        private StreamReader _reader;
        public string ConsoleOutput;
        private string _encoderPath;


        public event EventHandler<VideoEventArgs> VideoEncoded;
        public event EventHandler VideoEncoding;

        public Encoder(string encoderPath)
        {
            _encoderPath = encoderPath;
            _process = new Process();
            
        }

        public void DoWork(EncodingJob encodingJob)
        {

            this._process.EnableRaisingEvents = true;
            this._process.OutputDataReceived += new System.Diagnostics.DataReceivedEventHandler(process_OutputDataReceived);
            this._process.ErrorDataReceived += new System.Diagnostics.DataReceivedEventHandler(process_ErrorDataReceived);
            this._process.Exited += new System.EventHandler(process_Exited);

            this._process.StartInfo.FileName = _encoderPath;

            this._process.StartInfo.Arguments = encodingJob.InputFile + 
                                                encodingJob.ConversionArguments + 
                                                encodingJob.OutputFile; 

            this._process.StartInfo.UseShellExecute = false;
            this._process.StartInfo.RedirectStandardError = true;
            this._process.StartInfo.RedirectStandardOutput = true;


            this._process.Start();
            this._process.BeginErrorReadLine();
            this._process.BeginOutputReadLine();

            this._process.WaitForExit();
            this._process.Close();

        }


        protected virtual void OnVideoEncoded(EncodingJob encodingJob)
        {

            if (VideoEncoded != null)
            {
                VideoEncoded(this, new VideoEventArgs());

            }


        }

        protected virtual void OnVideoEncoding(EncodingJob encodingJob)
        {

            if (VideoEncoding != null)
            {
                VideoEncoded(this, new VideoEventArgs());

            }


        }




        public void process_Exited(object sender, EventArgs e)
        {
            //  Console.WriteLine(string.Format("process exited with code {0}\n", process.ExitCode.ToString()));
        }

        public void process_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {

            var originalConsoleOut = Console.Out; // preserve the original stream

            using (var writer = new StringWriter())
            {
              //  ConsoleOutput = e.Data;

                Console.SetOut(writer);

                Console.WriteLine(e.Data); // or make your DLL calls :)

                writer.Flush(); // when you're done, make sure everything is written out

                ConsoleOutput = writer.GetStringBuilder().ToString();


            }


            Console.SetOut(originalConsoleOut); // restore Console.Out

            this.ReadOutput();

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
        }

        public void process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            // Console.WriteLine(e.Data + "\n");
        }



    }
}
