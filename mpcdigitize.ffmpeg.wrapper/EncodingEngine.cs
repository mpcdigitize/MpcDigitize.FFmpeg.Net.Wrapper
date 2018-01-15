using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using mpcdigitize.ffmpeg.wrapper;

namespace Mpcdigitize.Ffmpeg.Wrapper
{
    public class EncodingEngine
    {

       // public JobStatus JobStatus = new JobStatus();
        public double Progress { get; set; }
       public string StringOutput = "";
        Process process = new Process();
        public StringWriter sw {get;set;}

        //  public string ConsoleOutput;



        public void Work(string arguments, string encoderPath)
        {
       

        }


        public void DoConvert(string arguments, string encoderPath)
        {

            Process process = new Process();

            process.StartInfo.Arguments = arguments;
            process.StartInfo.FileName = encoderPath;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();

            // Synchronously read the standard output of the spawned process. 
            StreamReader reader = process.StandardOutput;
            StringOutput = reader.ReadToEnd();

            // Write the redirected output to this application's window.
           //Console.WriteLine(StringOutput);

            process.WaitForExit();
            process.Close();

            Console.WriteLine("\n\nPress any key to exit.");
            Console.ReadLine();

        }

        public void  LaunchProcess(string arguments, string encoderPath)
        {


            process.EnableRaisingEvents = true;
            process.OutputDataReceived += new System.Diagnostics.DataReceivedEventHandler(process_OutputDataReceived);
            process.ErrorDataReceived += new System.Diagnostics.DataReceivedEventHandler(process_ErrorDataReceived);
            process.Exited += new System.EventHandler(process_Exited);

            process.StartInfo.FileName = encoderPath;
            process.StartInfo.Arguments = arguments;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.RedirectStandardOutput = true;

            process.Start();
            process.BeginErrorReadLine();
            process.BeginOutputReadLine();



          


            //below line is optional if we want a blocking call
            //process.WaitForExit();
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
               // output = e.Data;

                Console.SetOut(writer);

                Console.WriteLine(e.Data); // or make your DLL calls :)

                writer.Flush(); // when you're done, make sure everything is written out

            StringOutput = writer.GetStringBuilder().ToString();


            }

          
           Console.SetOut(originalConsoleOut); // restore Console.Out


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


        public string WriteToConsole()
        {
           Console.Write(StringOutput);
            //Console.WriteLine(output);

            return StringOutput;

        }







        public void StartEncoding(string arguments, string encoderPath)
        {
            var process = new Process();

            process.StartInfo.Arguments = arguments;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            process.StartInfo.FileName = encoderPath;

            //redirects to Console window
            
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;

           
            process.Start();
           

            Console.WriteLine(process.StandardOutput.ReadToEnd());

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
               // string some = process.StandardError.ReadToEnd();

                
                // Read in all the text from the process with the StreamReader.
                //
                using (StreamReader reader = process.StandardError)
                {
                    

                    while (!reader.EndOfStream)
                    {
                       Processed(reader.ReadLine());
                        //JobStatus.ConsoleOutput = reader.ReadLine();

                      Console.Write(reader.ReadLine());
                    }

                  //  string result = reader.ReadToEnd();
                    //Console.Write(result);

                   // Console.WriteLine("Progress:" + process.StandardError);
                }


               // Console.Write(some);

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
