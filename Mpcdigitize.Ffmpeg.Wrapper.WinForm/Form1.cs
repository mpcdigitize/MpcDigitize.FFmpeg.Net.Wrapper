using mpcdigitize.ffmpeg.wrapper;
using Mpcdigitize.Ffmpeg.Wrapper.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mpcdigitize.Ffmpeg.Wrapper.WinForm
{
    public partial class Form1 : Form
    {

        private BackgroundWorker bw;

        public Form1()
        {
            InitializeComponent();

            this.bw = new BackgroundWorker();
            this.bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            this.bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            this.bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            this.bw.WorkerReportsProgress = true;

            this.button1.Click += new EventHandler(button1_Click);
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.label1.Text = "The answer is: " + e.Result.ToString();
            this.button1.Enabled = true;
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.label1.Text = e.ProgressPercentage.ToString() + "% complete";
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker)sender;
            for (int i = 0; i < 100; ++i)
            {
                // report your progres
                worker.ReportProgress(i);

                // pretend like this a really complex calculation going on eating up CPU time
                System.Threading.Thread.Sleep(100);
            }
            e.Result = "42";
        }


        private void button1_Click(object sender, EventArgs e)
        {


            if (!this.bw.IsBusy)
            {
                this.bw.RunWorkerAsync();
                this.button1.Enabled = false;
            }
        }
    

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click1(object sender, EventArgs e)
        {


            var arguments = new FfmpegArgumentsDictionary();
            var job = new EncodingJob();
            var argsSelector = new ArgsSelector();


            job.InputFile = @"C:\input\testWTVShort.wtv";
            job.OutputFile = @"C:\videos\testConvert_3.mkv";
            job.ConversionArguments = argsSelector.Video.Convert3(VideoEncoder.Libx264, VideoResize.TV720p, VideoPreset.VeryFast, VideoConstantRateFactor.CrfNormal, AudioCodec.Ac3);


            var ffmpeg = new FfmpegEncoder(@"C:\ffmpeg\ffmpeg.exe");

            ffmpeg.VideoEncoding += ShowMessage;

            ffmpeg.DoWork(job);

            //Console.WriteLine("Completed");
            // MessageBox.Show("Completed");
        }

      


        public void ShowMessage(object sender, EncodingEventArgs e)
        {


            string output = "";
            output = e.Data;


            string path = @"C:\videos\testOutput.txt";
            using (var tw = new StreamWriter(path, true))
            {
                tw.WriteLine(output);
                tw.Close();
            }
           // listBox1.Items.Add(e.Progress);
        }

       
        

    }



   
}
