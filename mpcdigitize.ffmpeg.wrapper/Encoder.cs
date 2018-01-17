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

        public Encoder()
        {

            _process = new Process();
            

        }


        public void SetProcess(string arguments, string encoderPath)
        {

            //this._process.StartInfo.Arguments = arguments;
            //this._process.StartInfo.FileName = encoderPath;
            //this._process.StartInfo.UseShellExecute = false;
            //this._process.StartInfo.RedirectStandardOutput = true;

            this._process.EnableRaisingEvents = true;
            this._process.OutputDataReceived += new System.Diagnostics.DataReceivedEventHandler(process_OutputDataReceived);
            this._process.ErrorDataReceived += new System.Diagnostics.DataReceivedEventHandler(process_ErrorDataReceived);
            this._process.Exited += new System.EventHandler(process_Exited);

            this._process.StartInfo.FileName = encoderPath;
            this._process.StartInfo.Arguments = arguments;
            this._process.StartInfo.UseShellExecute = false;
            this._process.StartInfo.RedirectStandardError = true;
            this._process.StartInfo.RedirectStandardOutput = true;

        }


        public string ReadOutput()
        {
          //  this._reader = this._process.StandardOutput;
            //ConsoleOutput = this._reader.ReadToEnd();

            return ConsoleOutput;
        }

        public void Start()
        {

            this._process.Start();
            this._process.BeginErrorReadLine();
            this._process.BeginOutputReadLine();

        }



        public void WaitForExit()
        {
            this._process.WaitForExit();
            this._process.Close();

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
