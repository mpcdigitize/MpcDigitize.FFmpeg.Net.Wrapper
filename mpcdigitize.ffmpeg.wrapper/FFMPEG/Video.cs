using Mpcdigitize.Ffmpeg.Wrapper;
using Mpcdigitize.Ffmpeg.Wrapper.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mpcdigitize.ffmpeg.wrapper
{
    public class Video
    {
        public Ffmpeg Ffmpeg { get; set; }
        private FfmpegArgumentsDictionary _arguments;
        public string mconsole;

        public Video()
        {
            _arguments = new FfmpegArgumentsDictionary();

        }


        public void Convert1(string inputFile, VideoEncoder videoEncoder, VideoResize videoResize, VideoPreset videoPreset, VideoConstantRateFactor videoConstantRateFactor, AudioCodec audioCodec, Bitrate audioBitrate, string outputFile)
        {
            //-vf scale=-1:720 -c:v libx264 -preset veryfast -crf 23 -c:a aac -b:a 160k

            var encodingEngine = new EncodingEngine();


            var arguments = "-i " + inputFile +
                            _arguments.GetValue(videoResize.ToString()) +
                            _arguments.GetValue(videoEncoder.ToString()) +
                            _arguments.GetValue(videoPreset.ToString()) +
                            _arguments.GetValue(videoConstantRateFactor.ToString()) +
                            _arguments.GetValue(audioCodec.ToString()) +
                            _arguments.GetValue(audioBitrate.ToString()) +
                            outputFile;


            // Console.WriteLine(arguments);


            encodingEngine.LaunchProcess(arguments, Ffmpeg.GetPath());
            // encodingEngine.StartEncoding(arguments, Ffmpeg.GetPath());
           // encodingEngine.StartProcess(arguments, Ffmpeg.GetPath());


        }

        public void Convert2(string inputFile, VideoEncoder videoEncoder, VideoResize videoResize, VideoPreset videoPreset, VideoConstantRateFactor videoConstantRateFactor, AudioCodec audioCodec, string outputFile)
        {
            //-vf scale=-1:720 -c:v libx264 -preset veryfast -crf 23 -c:a aac -b:a 160k

            var encodingEngine = new EncodingEngine();
            var jobStatus = new JobStatus(encodingEngine);


            var arguments = "-i " + inputFile +
                            _arguments.GetValue(videoResize.ToString()) +
                            _arguments.GetValue(videoEncoder.ToString()) +
                            _arguments.GetValue(videoPreset.ToString()) +
                            _arguments.GetValue(videoConstantRateFactor.ToString()) +
                            _arguments.GetValue(audioCodec.ToString()) +
                            outputFile;

            //  Console.WriteLine(arguments);

            encodingEngine.LaunchProcess(arguments, Ffmpeg.GetPath());
           //Console.WriteLine(jobStatus.EncodingEngine.output);
            //encodingEngine.StartEncoding(arguments, Ffmpeg.GetPath());
            //encodingEngine.StartProcess(arguments, Ffmpeg.GetPath());


        }
    }
}
