using mpcdigitize.ffmpeg.wrapper;
using Mpcdigitize.Ffmpeg.Wrapper.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mpcdigitize.Ffmpeg.Wrapper.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BackgroundWorker bw;
        private FfmpegEncoder ffmpeg;

        public MainWindow()
        {
            InitializeComponent();
            this.ffmpeg = new FfmpegEncoder(@"C:\ffmpeg\ffmpeg.exe");
            this.bw = new BackgroundWorker();
            this.bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            this.bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            this.bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            this.bw.WorkerReportsProgress = true;

            this.ffmpeg.VideoEncoding += GetProgress;
         //   this.button1.Click += new EventHandler(button1_Click);
            this.pbStatus.Maximum = 84;

        }



        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.label1.Content = "The job is: " + e.Result.ToString();
            this.button1.IsEnabled = true;
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var myObject = (EncodingStats)e.UserState;

            this.label2.Content = e.ProgressPercentage.ToString() + "% complete" + " Size: " + myObject.Size + " Speed: " + myObject.Speed;
            this.pbStatus.Value = e.ProgressPercentage;

        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker)sender;


            this.Encode();


            //worker.ReportProgress(val);


            e.Result = "Completed";
        }


      





        public void Encode()
        {
            var arguments = new FfmpegArgumentsDictionary();
            var job = new EncodingJob();
            var argsSelector = new ArgsSelector();


            job.InputFile = @"C:\input\testWTVShort.wtv";
            job.OutputFile = @"C:\videos\testConvert_6.mkv";
            job.ConversionArguments = argsSelector.Video.Convert3(VideoEncoder.Libx264, VideoResize.TV720p, VideoPreset.VeryFast, VideoConstantRateFactor.CrfNormal, AudioCodec.Ac3);



            ffmpeg.DoWork(job);

        }




        public void GetProgress(object sender, EncodingEventArgs e)
        {
            //  _progress = (int)e.Progress;
            // _progress = 50;


            bw.ReportProgress((int)e.Progress, new EncodingStats { Size = e.Size, Frame = e.Frame, Speed = e.Speed });

            //string path = @"C:\videos\testOutput2.txt";
            //using (var tw = new StreamWriter(path, true))
            //{
            //    tw.WriteLine(_progress);
            //    tw.Close();
            //}



        }

        private void button1_Click_1(object sender, RoutedEventArgs e)
        {


            if (!this.bw.IsBusy)
            {
                this.bw.RunWorkerAsync();
                this.button1.IsEnabled = false;
            }
        }
    }
}
