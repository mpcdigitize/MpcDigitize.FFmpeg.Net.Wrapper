
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
        public event EventHandler<ExitedEventArgs> Exited;
        public event EventHandler<ErrorEventArgs> ErrorReceived;

        public EncodingEngine(string encoderPath)
        {
            _encoderPath = encoderPath;
            this._process = new Process();

        }


        public void Cancel()
        {

            StreamWriter myStreamWriter = this._process.StandardInput;
            myStreamWriter.WriteLine("q");


        }

        public void DoWork(EncodingJob encodingJob)
        {
           
            this._process.EnableRaisingEvents = true;    
            this._process.ErrorDataReceived += new DataReceivedEventHandler(this.GetStandardErrorDataReceived);
           // this._process.OutputDataReceived += new System.Diagnostics.DataReceivedEventHandler(OutputDataReceived);

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
           // this._process.BeginOutputReadLine();
    

            this._process.WaitForExit();
                   
            OnVideoEncoded(new EncodedEventArgs() {EncodingJob = encodingJob });
            OnExit(new ExitedEventArgs() { ExitCode = this._process.ExitCode.ToString() });

            this._process.Close();
        }


        protected virtual void OnVideoEncoded(EncodedEventArgs e)
        {

            VideoEncoded?.Invoke(this,e);

        }

       

        protected virtual void OnVideoEncoding(EncodingEventArgs e)
        {

            VideoEncoding?.Invoke(this, e);

        }

        protected virtual void OnExit(ExitedEventArgs e)
        {

            Exited?.Invoke(this, e);

        }


        protected virtual void OnErrorReceived(ErrorEventArgs e)
        {

            ErrorReceived?.Invoke(this, e);

        }


        private void GetStandardErrorDataReceived(object sender, DataReceivedEventArgs e)
        {

                     
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

        public void OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            // Console.WriteLine(e.Data + "\n");
        }



    }
}

