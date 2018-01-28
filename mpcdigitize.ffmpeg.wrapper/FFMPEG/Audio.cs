using Mpcdigitize.Ffmpeg.Wrapper;
using Mpcdigitize.Ffmpeg.Wrapper.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mpcdigitize.ffmpeg.wrapper
{
    public class Audio 
    {
        public ArgsSelector argsSelector { get; set; }
        private FfmpegArgumentsDictionary _arguments;

        public Audio()
        {
            _arguments = new FfmpegArgumentsDictionary();

        }

        public void Convert(string inputFile, AudioEncoder audioEncoder, Bitrate audioBitrate, string outputFile)
        {
            var encodingEngine = new EncodingEngine();

            var arguments = "-i " + inputFile +
                            _arguments.GetValue(audioEncoder.ToString()) +
                            _arguments.GetValue(audioBitrate.ToString()) +
                            outputFile;

            Console.WriteLine(arguments);

      //   encodingEngine.StartProcess(arguments, Ffmpeg.GetPath());


        }
    }
}
