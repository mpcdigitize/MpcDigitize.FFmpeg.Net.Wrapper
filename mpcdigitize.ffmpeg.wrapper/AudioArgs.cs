using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mpcdigitize.Ffmpeg.Wrapper
{
    public class AudioArgs : EncodingArgs
    {
        
        private Dictionary<string, string> _arguments;
        
        public AudioArgs()
        {
          _arguments = this.Arguments
      
        }
    
       public string Convert(string inputFile, AudioEncoder audioEncoder, Bitrate audioBitrate, string outputFile)
        {

            var arguments = "-i " + inputFile +
                            " -v quiet -stats " +
                            _arguments.GetValue(audioEncoder.ToString()) +
                            _arguments.GetValue(audioBitrate.ToString())
                            " -y " + outputFile;

            return arguments;


        }
        
        
        public string Capture(string inputFile, string outputFile)
        {
            
            var arguments = "-i " + inputFile +
                            " -y " + outputFile;

            return arguments;
        }


        public string Capture(string inputFile,int durationInSeconds, string outputFile)
        {
            
            var arguments = "-i " + inputFile +
                            " -c copy" +
                            " -t " + durationInSeconds
                            outputFile;

            Console.WriteLine(arguments);

        //    encodingEngine.StartEncoding(arguments, _programmPath);



        }


        



     
    }
}

