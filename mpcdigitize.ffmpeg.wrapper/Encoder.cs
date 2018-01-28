using mpcdigitize.ffmpeg.wrapper.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mpcdigitize.ffmpeg.wrapper
{
    public class FfmpegEncoder
    {
        private Process _process;
        private StreamReader _reader;
        private EncodingStats _encodingStats;


       // public EncodingStats EncodingStats { get; set;}
        //{
        //    get
        //    {
        //        return _encodingStats;
        //    }
        //    set
        //    {
        //        //if (_encodingStats != value)
                //{
                //    EncodingEventArgs args = new EncodingEventArgs();
                //    args.Duration = this._encodingStats.Duration;
                //    args.Progress = this._encodingStats.Progress;

                //    VideoEncoding(this, args);


                //}

            //}

        //}



        public string ConsoleOutput;
        private string _encoderPath;


       // public event EventHandler VideoEncoded;
        public event EventHandler<EncodingEventArgs> VideoEncoding;

        public FfmpegEncoder(string encoderPath)
        {
            _encoderPath = encoderPath;
            _process = new Process();
            _encodingStats = new EncodingStats();

        }

        public void DoWork(EncodingJob encodingJob)
        {

            this._process.EnableRaisingEvents = true;
            this._process.OutputDataReceived += new System.Diagnostics.DataReceivedEventHandler(process_OutputDataReceived);
           
            this._process.ErrorDataReceived += new System.Diagnostics.DataReceivedEventHandler(process_ErrorDataReceived);

            this._process.Exited += new System.EventHandler(process_Exited);

            this._process.StartInfo.FileName = _encoderPath;

            this._process.StartInfo.Arguments = "-i " + encodingJob.InputFile +
                                                encodingJob.ConversionArguments +
                                                encodingJob.OutputFile;

            this._process.StartInfo.UseShellExecute = false;
            this._process.StartInfo.RedirectStandardError = true;
            this._process.StartInfo.RedirectStandardOutput = true;
           // this._process.StartInfo.CreateNoWindow = true;


            this._process.Start();
            this._process.BeginErrorReadLine();
            this._process.BeginOutputReadLine();

            this._process.WaitForExit();
            this._process.Close();

        }


        protected virtual void OnVideoEncoded()
        {



        }

        protected virtual void OnVideoEncoding(EncodingEventArgs e)
        {

            VideoEncoding?.Invoke(this, e);

            //EncodingEventArgs args = new EncodingEventArgs();
            //args.Data = this._encodingStats.Data;
            //args.Progress = this._encodingStats.Progress;

            Console.WriteLine("OnVideoEncoding : Progress > " + e.Progress + "  DATA > " + e.Data);

            //    VideoEncoding(this, new EncodingEventArgs(encodingStats));



            //}


        }




        public void process_Exited(object sender, EventArgs e)
        {
            //  Console.WriteLine(string.Format("process exited with code {0}\n", process.ExitCode.ToString()));
        }




        public void process_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {

           // var data = e.Data;

            //using (StreamReader reader = e.Data)
            //{
            //    while (!reader.EndOfStream)
            //    {
            //        string readerLine = reader.ReadLine();

            //    }
            //this._encodingStats = new EncodingStats();
            //this._encodingStats.Data = e.Data;
            //this._encodingStats.Progress = data.GetProgress();
            OnVideoEncoding(new EncodingEventArgs() { Progress = e.Data.GetProgress(), Data = e.Data } );
        
            // Console.WriteLine("DATA : " + this._encodingStats.Data);
            // Console.WriteLine("DATA : " + this._encodingStats.Progress);



        }

        //}

        public void process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            // Console.WriteLine(e.Data + "\n");
        }


    }
}

       






 



