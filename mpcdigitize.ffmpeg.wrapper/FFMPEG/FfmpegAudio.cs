
using Mpcdigitize.Ffmpeg.Wrapper.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mpcdigitize.Ffmpeg.Wrapper
{

    /// <summary>
    ///     Contains Audio conversion methods
    /// </summary>
    public partial class CliEncoder
    {



       


        public void ConvertAudio(string inputFile, AudioEncoder audioEncoder, Bitrate audioBitrate, string outputFile)
        {
            var encodingEngine = new EncodingEngine();

            var arguments = "-i " + inputFile +
                            _arguments.GetValue(audioEncoder.ToString()) +
                            _arguments.GetValue(audioBitrate.ToString()) + 
                            outputFile;

            Console.WriteLine(arguments);

            encodingEngine.StartEncoding(arguments, _programmPath);
        
            
        }


    

      


    }
}
