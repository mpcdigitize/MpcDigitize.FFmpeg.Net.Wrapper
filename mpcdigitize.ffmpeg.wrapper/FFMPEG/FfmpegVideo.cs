
using Mpcdigitize.Ffmpeg.Wrapper.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mpcdigitize.Ffmpeg.Wrapper
{

    /// <summary>
    ///     Contains Video conversion methods
    /// </summary>
    public partial class CliEncoder
    {

      

        public void ConvertVideo(string inputFile, VideoEncoder videoEncoder, VideoResize videoResize, VideoPreset videoPreset, VideoConstantRateFactor videoConstantRateFactor, AudioCodec audioCodec, Bitrate audioBitrate, string outputFile)
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


            Console.WriteLine(arguments);

           // encodingEngine.StartEncoding(arguments, _programmPath);
            encodingEngine.StartProcess(arguments, _programmPath);


        }

        public void ConvertVideo(string inputFile, VideoEncoder videoEncoder, VideoResize videoResize, VideoPreset videoPreset, VideoConstantRateFactor videoConstantRateFactor, AudioCodec audioCodec, string outputFile)
        {
            //-vf scale=-1:720 -c:v libx264 -preset veryfast -crf 23 -c:a aac -b:a 160k

            var encodingEngine = new EncodingEngine();


            var arguments = "-i " + inputFile +
                            _arguments.GetValue(videoResize.ToString()) +
                            _arguments.GetValue(videoEncoder.ToString()) +
                            _arguments.GetValue(videoPreset.ToString()) +
                            _arguments.GetValue(videoConstantRateFactor.ToString()) +
                            _arguments.GetValue(audioCodec.ToString()) +
                            outputFile;

            Console.WriteLine(arguments);

            //encodingEngine.StartEncoding(arguments, _programmPath);
            encodingEngine.StartProcess(arguments, _programmPath);


        }


     

    }
}
