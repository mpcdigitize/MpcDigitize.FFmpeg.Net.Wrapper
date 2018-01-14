
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mpcdigitize.Ffmpeg.Wrapper
{

    /// <summary>
    ///     Contains Streaming methods
    /// </summary>
    public partial class Ffmpeg_old
    {

       

        public void SaveStream(string inputFile, string outputFile)
        {
            var encodingEngine = new EncodingEngine();


            var arguments = "-i " + inputFile +
                            " " + outputFile;

            Console.WriteLine(arguments);

          //  encodingEngine.StartEncoding(arguments, _programmPath);



        }


        public void SaveStreamCopy(string inputFile,string outputFile)
        {
            var encodingEngine = new EncodingEngine();


            var arguments = "-i " + inputFile +
                            " -vcodec copy" +
                            " -acodec copy -t 120 " +
                            outputFile;

            Console.WriteLine(arguments);

        //    encodingEngine.StartEncoding(arguments, _programmPath);



        }


    }
}
