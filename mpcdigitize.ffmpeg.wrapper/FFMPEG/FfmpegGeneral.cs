
using Mpcdigitize.Ffmpeg.Wrapper.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mpcdigitize.Ffmpeg.Wrapper
{

    /// <summary>
    ///     Contains file access methods    
    /// </summary>
    public partial class Ffmpeg_old
    {

        private string _programmPath;
        private FfmpegArgumentsDictionary _arguments;

        public Ffmpeg_old(string programmPath, FfmpegArgumentsDictionary arguments)
        {
            _programmPath = programmPath;
            _arguments = arguments;
        }


        public void ExtractVideoFrame(string inputFile, int timeInSeconds,FrameSize frameSize, string outputFile)
        {
            //ffmpeg -ss 01:23:45 -i input -vframes 1 -q:v 2 output.jpg

            var encodingEngine = new EncodingEngine();

            var arguments = "-ss " + timeInSeconds + 
                            " -i " + inputFile +
                            " -frames:v 1" +
                            _arguments.GetValue(frameSize.ToString()) +
                            " -q:v 2" +
                             " " + outputFile;

            Console.WriteLine(arguments);

        //    encodingEngine.StartEncoding(arguments, _programmPath);

        }


  

        public void SaveMetadata(string inputFile, string outputFile)
        {

            //ffmpeg -i input_video -f ffmetadata metadata.txt
           
            var encodingEngine = new EncodingEngine();

            var arguments = " -i " + inputFile +
                            " -f ffmetadata " +
                            outputFile;

            Console.WriteLine(arguments);

           // encodingEngine.StartEncoding(arguments, _programmPath);

        }







    }
}
