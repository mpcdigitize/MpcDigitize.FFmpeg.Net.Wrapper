using mpcdigitize.ffmpeg.wrapper.Enums;
using mpcdigitize.ffmpeg.wrapper.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MpcDigitize.FFmpeg.Net.Wrapper
{
    public class EncodingEngine
    {
        private Process _process;
        private string _encoderPath;
        
        public event EventHandler<EncodedEventArgs> VideoEncoded;
        public event EventHandler<EncodingEventArgs> VideoEncoding;

        public EncodingEngine(string encoderPath)
        {
            _encoderPath = encoderPath;
            _process = new Process();

        }





        public void Cancel()
        {

            StreamWriter myStreamWriter = this._process.StandardInput;
            myStreamWriter.WriteLine("q");


        }

        public void DoWork(EncodingJob encodingJob)
        {

            this._process.EnableRaisingEvents = true;
            this._process.OutputDataReceived += new DataReceivedEventHandler(process_OutputDataReceived);
           
            this._process.ErrorDataReceived += new DataReceivedEventHandler(process_ErrorDataReceived);

            this._process.Exited += new EventHandler(process_Exited);

            this._process.StartInfo.FileName = _encoderPath;

            this._process.StartInfo.Arguments = encodingJob.Arguments;

            this._process.StartInfo.UseShellExecute = false;
            this._process.StartInfo.RedirectStandardError = true;
            this._process.StartInfo.RedirectStandardOutput = true;
            this._process.StartInfo.RedirectStandardInput = true;
            this._process.StartInfo.CreateNoWindow = true;
            this._process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;



            this._process.Start();
            this._process.BeginErrorReadLine();
            this._process.BeginOutputReadLine();

            this._process.WaitForExit();
            this._process.Close();
            
             OnVideoEncoded(new EncodedEventArgs() {EncodingJob = encodingJob });

        }


        protected virtual void OnVideoEncoded(EncodedEventArgs e)
        {

            VideoEncoded?.Invoke(this,e);

        }

       

        protected virtual void OnVideoEncoding(EncodingEventArgs e)
        {

            VideoEncoding?.Invoke(this, e);

        }




        public void process_Exited(object sender, EventArgs e)
        {
            //  Console.WriteLine(string.Format("process exited with code {0}\n", process.ExitCode.ToString()));
        }




        public void process_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {

            //raising event          
            OnVideoEncoding(new EncodingEventArgs() {

                Frame = e.Data.GetRegexValue(RegexKey.Frame,RegexGroup.Two),             
                Fps = e.Data.GetRegexValue(RegexKey.Fps, RegexGroup.Two),
                Size = e.Data.GetRegexValue(RegexKey.Size, RegexGroup.Two),
                Time = e.Data.GetRegexValue(RegexKey.Time, RegexGroup.Two),
                Bitrate = e.Data.GetRegexValue(RegexKey.Bitrate, RegexGroup.Two),
                Speed = e.Data.GetRegexValue(RegexKey.Speed, RegexGroup.Two),
                Quantizer = e.Data.GetRegexValue(RegexKey.Quantizer, RegexGroup.Two),
                Progress = e.Data.GetRegexValue(RegexKey.Time, RegexGroup.Two).ParseTotalSeconds(),
                Data = e.Data } );
        
         


        }

     

        public void process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            // Console.WriteLine(e.Data + "\n");
        }


    }
}

