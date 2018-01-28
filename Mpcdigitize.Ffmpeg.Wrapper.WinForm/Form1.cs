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

        private void button1_Click(object sender, EventArgs e)
        {
            var arguments = new FfmpegArgumentsDictionary();
          


            var job = new EncodingJob();
            var argsSelector = new ArgsSelector();


            job.InputFile = @"C:\input\testWTVShort.wtv";
            job.OutputFile = @"C:\videos\testConvert_2.mkv";
            job.ConversionArguments = argsSelector.Video.Convert3(VideoEncoder.Libx264, VideoResize.TV720p, VideoPreset.VeryFast, VideoConstantRateFactor.CrfNormal, AudioCodec.Ac3);


            var ffmpeg = new FfmpegEncoder(@"C:\ffmpeg\ffmpeg.exe");

            ffmpeg.VideoEncoding += DisplayProgress;

            ffmpeg.DoWork(job);

            MessageBox.Show("Completed");

        }


        public void DisplayProgress(object source,EncodingEventArgs e)
        {
            //label1.Text = e.Progress.ToString();
            // Console.WriteLine(e.Progress.ToString());
            MessageBox.Show("Converting");
            //MessageBox.Show(e.Progress.ToString());
            //label1.Refresh();


        }


    }
}
