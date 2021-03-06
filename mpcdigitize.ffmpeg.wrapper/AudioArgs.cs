using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MpcDigitize.FFmpeg.Net.Wrapper
{
    public class AudioArgs
    {

        private EncodingArgs _arguments;

        public AudioArgs()
        {

            _arguments = new EncodingArgs();

        }

        public string Convert(string inputFile, AudioEncoder audioEncoder, Bitrate audioBitrate, string outputFile)
        {

            var arguments = "-i " + "\"" + inputFile + "\"" +
                            " -v quiet -stats " +
                            _arguments.GetValue(audioEncoder.ToString()) +
                            _arguments.GetValue(audioBitrate.ToString()) +
                            " -y " + outputFile;

            return arguments;


        }
        
        
        public string Capture(string inputFile, string outputFile)
        {
            
            var arguments = "-i " + "\"" + inputFile + "\"" +
                            " -y " + "\"" + outputFile + "\"";

            return arguments;
        }


        public string Capture(string inputFile,int durationInSeconds, string outputFile)
        {
            
            var arguments = "-i " + "\"" + inputFile + "\"" +
                            " -c copy" +
                            " -t " + durationInSeconds +
                            " -y " + "\"" + outputFile + "\"";

            return arguments;

        }


        public string Capture(string inputFile, int durationInSeconds, AudioEncoder audioEncoder, Bitrate audioBitrate, string outputFile)
        {

            var arguments = "-i " + "\"" + inputFile + "\"" +
                            " -c copy" +
                            " -t " + durationInSeconds +
                            _arguments.GetValue(audioEncoder.ToString()) +
                            _arguments.GetValue(audioBitrate.ToString()) +
                            " -y " + "\"" + outputFile + "\"";

            return arguments;

        }








    }
}

