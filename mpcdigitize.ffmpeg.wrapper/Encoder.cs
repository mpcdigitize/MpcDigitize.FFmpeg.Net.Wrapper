﻿using System;
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
        private EncodingStats _encodingStats;


        public EncodingStats EncodingStats
        {
            get
            {
                return _encodingStats;
            }
            set
            {
                if (_encodingStats != value)
                {
                    EncodingEventArgs args = new EncodingEventArgs();
                    args.Duration = this._encodingStats.Duration;
                    args.Progress = this._encodingStats.Progress;

                    VideoEncoding(this, args);


                }

            }

        }



        public string ConsoleOutput;
        private string _encoderPath;


        public event EventHandler VideoEncoded;
        public event EventHandler<EncodingEventArgs> VideoEncoding;

        public Encoder(string encoderPath)
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


        protected virtual void OnVideoEncoded()
        {



        }

        protected virtual void OnVideoEncoding(EncodingStats encodingStats)
        {

            if (VideoEncoding != null)
            {
                VideoEncoded(this, new EncodingEventArgs());

            }


        }




        public void process_Exited(object sender, EventArgs e)
        {
            //  Console.WriteLine(string.Format("process exited with code {0}\n", process.ExitCode.ToString()));
        }




        public void process_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {



            using (StreamReader reader = e.Data())
            {
                while (!reader.EndOfStream)
                {
                    string readerLine = reader.ReadLine();

                    this._encodingStats.Progress = readerLine.GetProgress();



                }

            }




        }

        public void process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            // Console.WriteLine(e.Data + "\n");
        }






    }
}
