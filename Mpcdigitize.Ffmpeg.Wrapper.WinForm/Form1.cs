using mpcdigitize.ffmpeg.wrapper;
using Mpcdigitize.Ffmpeg.Wrapper.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mpcdigitize.Ffmpeg.Wrapper.WinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private delegate void DiaplayProgressDelagate(object sender,EncodingEventArgs e);

        private void button1_Click(object sender, EventArgs e)
        {
            var arguments = new FfmpegArgumentsDictionary();
          


            var job = new EncodingJob();
            var argsSelector = new ArgsSelector();


            job.InputFile = @"C:\input\testWTVShort.wtv";
            job.OutputFile = @"C:\videos\testConvert_1.mkv";
            job.ConversionArguments = argsSelector.Video.Convert3(VideoEncoder.Libx264, VideoResize.TV720p, VideoPreset.VeryFast, VideoConstantRateFactor.CrfNormal, AudioCodec.Ac3);


            var ffmpeg = new FfmpegEncoder(@"C:\ffmpeg\ffmpeg.exe");

         //  ffmpeg.VideoEncoding += DisplayProgress;

            ffmpeg.DoWork(job);

            Console.WriteLine("Completed");

        }


        //public void DisplayProgress(object sender,EncodingEventArgs e)
        //{

        //    if (label1.InvokeRequired == true)
        //    {
        //        DiaplayProgressDelagate del = new DiaplayProgressDelagate(DisplayProgress);
        //        this.BeginInvoke(del, new object[] { e });

        //    }
        //    else
        //    {
        //        MessageBox.Show("MainThhread");
        //        //Console.WriteLine(e._encodingStats.Data);
        //        label1.Text = e.Progress.ToString();
        //     //   label1.Refresh();

        //    }
        //    // Console.WriteLine(e.Progress.ToString());
        //   // MessageBox.Show("Converting");
        //    //MessageBox.Show(e.Progress.ToString());
          


        //}


    }
}
