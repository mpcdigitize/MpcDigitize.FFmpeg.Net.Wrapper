
using MpcDigitize.FFmpeg.Net.Wrapper;
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
        private EncodingEngine ffmpeg;

        public MainWindow()
        {
            InitializeComponent();
            this.ffmpeg = new EncodingEngine(@"C:\ffmpeg\ffmpeg.exe");
            this.bw = new BackgroundWorker();
            this.bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            this.bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            this.bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            this.bw.WorkerReportsProgress = true;

            this.ffmpeg.VideoEncoding += GetProgress;

            //get duration using ffprobe
            this.pbStatus.Maximum = 100;

        }



        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.label1.Content = "The job is: " + e.Result.ToString();
            this.button1.IsEnabled = true;
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var stats = (EncodingStats)e.UserState;

            this.label2.Content = e.ProgressPercentage.ToString() + "% complete" + " Size: " + stats.Size + " Speed: " + stats.Speed;
            this.pbStatus.Value = e.ProgressPercentage;

        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker)sender;


            this.Encode();

            e.Result = "Completed";
        }



        public void Encode()
        {
            var arguments = new EncodingArgs();
            var job = new EncodingJob();
            var args = new VideoArgs();


            var inputFile = @"C:\input\test.wtv";
            var outputFile = @"C:\videos\testConvert_01.mkv";
            job.Arguments = args.Convert(inputFile,VideoEncoder.Libx264, VideoResize.TV720p, VideoPreset.VeryFast, ConstantRateFactor.CrfNormal, AudioCodec.Ac3, outputFile);



            ffmpeg.DoWork(job);

        }




        public void GetProgress(object sender, EncodingEventArgs e)
        {
          

            bw.ReportProgress((int)e.Progress, new EncodingStats { Size = e.Size, Frame = e.Frame, Speed = e.Speed });
            
           



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
