
using MpcDigitize.FFmpeg.Net.Wrapper;
using System;
using System.ComponentModel;
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
            var userState = (EncodingStats)e.UserState;
          
            //Get duration using ffprobe
            this.pbStatus.Maximum = 100; 

            this.label1.Text = e.ProgressPercentage.ToString() + "% complete" + " Size: " + userState.Size + " Speed: " + userState.Speed;
            this.pbStatus.Value = e.ProgressPercentage;
            
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker)sender;

          
                this.Encode();
          
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

               

            var inputFile = @"C:\input\testFile.wtv";
            var outputFile = @"C:\videos\testConvert.mkv";
            
            job.Arguments = args.Convert(inputFile,VideoEncoder.Libx264, VideoResize.TV720p, VideoPreset.VeryFast, ConstantRateFactor.CrfNormal, AudioCodec.Ac3, outputFile);
        
            ffmpeg.DoWork(job);

        }


    

        public void GetProgress(object sender, EncodingEventArgs e)
        {
                
            bw.ReportProgress((int)e.Progress, new EncodingStats {Size = e.Size,Frame = e.Frame, Speed = e.Speed });

      

        }

        private void button2_Click(object sender, EventArgs e)
        {

            ffmpeg.Cancel();
          
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

      
    }
    }



   

