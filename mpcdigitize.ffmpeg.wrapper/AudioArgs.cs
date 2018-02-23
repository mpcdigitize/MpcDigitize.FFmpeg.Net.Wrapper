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

        



     
    }
}

