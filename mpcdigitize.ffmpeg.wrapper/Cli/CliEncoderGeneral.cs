using FfmpegWrapper.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FfmpegWrapper
{

    /// <summary>
    ///     Contains file access methods    
    /// </summary>
    public partial class CliEncoder
    {

        private string _encoderPath;
        private EncodingArgumentsDictionary _arguments;

        public CliEncoder(string encoderPath, EncodingArgumentsDictionary arguments)
        {
            _encoderPath = encoderPath;
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

            encodingEngine.StartEncoding(arguments, _encoderPath);

        }


        /// <summary>
        ///     Using FFPROBE
        /// </summary>
        /// <param name="inputFile"></param>
        public void GetInfo(string inputFile)
        {


            var encodingEngine = new EncodingEngine();
            var ffprobe = @"C:\ffmpeg\ffprobe.exe";

            //ffprobe -v quiet -print_format json -show_format -show_streams "lolwut.mp4" > "lolwut.mp4.json"
            //ffprobe -show_streams -select_streams a INPUT

           // var arguments = " -v quiet -print_format json -show_format -show_streams " + inputFile ;
            var arguments = " -v quiet -print_format xml -show_format -show_streams " + inputFile;



            Console.WriteLine(arguments);

            //encodingEngine.StartEncoding(arguments, ffprobe);
            encodingEngine.StartProcess(arguments, ffprobe);

        }


        public void SaveMetadata(string inputFile, string outputFile)
        {

            //ffmpeg -i input_video -f ffmetadata metadata.txt
           
            var encodingEngine = new EncodingEngine();

            var arguments = " -i " + inputFile +
                            " -f ffmetadata " +
                            outputFile;

            Console.WriteLine(arguments);

            encodingEngine.StartEncoding(arguments, _encoderPath);

        }







    }
}
