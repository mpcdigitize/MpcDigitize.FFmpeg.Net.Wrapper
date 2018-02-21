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
    
       public string Convert(AudioEncoder audioEncoder, Bitrate audioBitrate)
        {

            var arguments = _arguments.GetValue(audioEncoder.ToString()) +
                            _arguments.GetValue(audioBitrate.ToString());

            return arguments;


        }

        



     
    }
}

