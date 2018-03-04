
using MpcDigitize.FFmpeg.Net.Wrapper;
using MpcDigitize.Wtv.FFprobe.Wrapper;
using MpcDigitize.Wtv.FFprobe.Wrapper.Enums;
using MpcDigitize.Wtv.FFprobe.Wrapper.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mpcdigitize.Ffmpeg.Wrapper.WinForm
{
    public partial class Form1 : Form
    {


        private BackgroundWorker bw;
        private EncodingEngine ffmpeg;
  

        public Form1()
        {
            InitializeComponent();

            this.ffmpeg = new EncodingEngine(@"C:\ffmpeg\ffmpeg.exe");
            this.bw = new BackgroundWorker();
            this.bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            this.bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);        
            this.bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            this.bw.WorkerReportsProgress = true;
            this.bw.WorkerSupportsCancellation = true;

            this.ffmpeg.VideoEncoding += GetProgress;
            this.button1.Click += new EventHandler(button1_Click);
           
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.label1.Text = "The job is: " + e.Result.ToString();
            this.button1.Enabled = true;
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var myObject = (EncodingStats)e.UserState;

            var ffprobe = new MetadataReader(@"C:\ffmpeg\ffprobe.exe");

            var InputFile = @"C:\input\testWTVShort.wtv";
        
            var output = ffprobe.DoWork(InputFile, OutputFormat.Json);
            var result = output.GetMetadata().format.duration;

            this.pbStatus.Maximum = (int)Convert.ToDouble(result);

            this.label2.Text = e.ProgressPercentage.ToString() + "% complete" + " Size: " + myObject.Size + " Speed: " + myObject.Speed;
            this.pbStatus.Value = e.ProgressPercentage;
            
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker)sender;

            //if (bw.CancellationPending)
            //{
            //    e.Cancel = true;
            //    ffmpeg.Cancel();
              
            //}
            //else
            //{
                this.Encode();
            //}
            


            //worker.ReportProgress(val);


            e.Result = "Completed";
        }


        private void button1_Click(object sender, EventArgs e)
        {


            if (!this.bw.IsBusy)
            {
                this.bw.RunWorkerAsync();
                this.button1.Enabled = false;
            }
        }
    




        public void Encode()
        {
            var arguments = new EncodingArgs();
            var job = new EncodingJob();
            var args = new VideoArgs();

               

            var inputFile = @"C:\input\testWTVShort.wtv";
          //  var outputFile = @"C:\videos\testConvert_3.mkv";
            var outputFile = @"C:\videos\CopyMKV.mkv";



            //job.Arguments = args.Convert(inputFile,VideoEncoder.Libx264, VideoResize.TV720p, VideoPreset.VeryFast, ConstantRateFactor.CrfNormal, AudioCodec.Ac3, outputFile);
            job.Arguments = args.Copy(inputFile,Streams.AllStreams,outputFile);


           
            ffmpeg.DoWork(job);

        }


    

        public void GetProgress(object sender, EncodingEventArgs e)
        {
            //  _progress = (int)e.Progress;
            // _progress = 50;

          
            bw.ReportProgress((int)e.Progress, new EncodingStats {Size = e.Size,Frame = e.Frame, Speed = e.Speed });

            //string path = @"C:\videos\testOutput2.txt";
            //using (var tw = new StreamWriter(path, true))
            //{
            //    tw.WriteLine(_progress);
            //    tw.Close();
            //}



        }

        private void button2_Click(object sender, EventArgs e)
        {

            ffmpeg.Cancel();
           // bw.CancelAsync();
         //   button2.Enabled = false;
        }

       
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
    }



   

