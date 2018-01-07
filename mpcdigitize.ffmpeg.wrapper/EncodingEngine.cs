using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Mpcdigitize.Ffmpeg.Wrapper
{
    public class EncodingEngine
    {

        public double Progress { get; set; }

        public void StartEncoding(string arguments, string encoderPath)
        {
            var process = new Process();

            process.StartInfo.Arguments = arguments;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            process.StartInfo.FileName = encoderPath;


           // process.StartInfo.RedirectStandardOutput = true;
            //process.StartInfo.UseShellExecute = false;
            //string output = process.StandardOutput.ReadToEnd();

            process.Start();
            process.WaitForExit();

            
            //startInfo.CreateNoWindow = true;
           

            //Console.WriteLine(output);



        }



        /// <summary>
        ///     Diaplays progress in seconds in  Console window
        /// </summary>
        /// <param name="arguments"></param>
        /// <param name="encoderPath"></param>
        public void StartProcess(string arguments, string encoderPath)
        {
            var start = new ProcessStartInfo();
            start.Arguments = arguments;
            start.FileName = encoderPath;
            start.UseShellExecute = false;
            //start.RedirectStandardOutput = true;
           start.RedirectStandardError = true;
            //
            // Start the process.
            //

          
            using (Process process = Process.Start(start))
            {
                //process.BeginOutputReadLine();
                //process.BeginOutputReadLine();

                // Read in all the text from the process with the StreamReader.
                //
                using (StreamReader reader = process.StandardError)
                {
                    while (!reader.EndOfStream)
                    {
                       Processed(reader.ReadLine());
                      // Console.Write(reader.ReadLine());
                    }

                  //  string result = reader.ReadToEnd();
                    //Console.Write(result);

                   // Console.WriteLine("Progress:" + process.StandardError);
                }

            
            }



         
    }


        public void Processed(string v)
        {
            try
            {
                string[] split = v.Split(' ');
                foreach (var row in split)
                {
                    if (row.StartsWith("time="))
                    {
                        var time = row.Split('=');
                        Progress = TimeSpan.Parse(time[1]).TotalSeconds;
                        Console.WriteLine("Status Position - :" + Progress);
                    }
                }
            }
            catch { }
        }
    }



//    private void timer1_Tick(object sender, EventArgs e)
//    {
//        try
//        {
//            int progress = int.Parse(utilityVideo.Progress.ToString("0"));

//            if (progress > 0)
//            {
//                RefreshProgressBar(Progress);
//            }
//        }
//    }
//    catch { }
//    }

//private void RefreshProgressBar(int currentTimeProcessed)
//{
//    if (InvokeRequired)
//    {
//        BeginInvoke((MethodInvoker)delegate { RefreshProgressBar(currentTimeProcessed); });
//        return;
//    }
//    progressBar1.Value = currentTimeProcessed;
//}




}
