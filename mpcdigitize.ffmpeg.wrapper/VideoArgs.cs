using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mpcdigitize.Ffmpeg.Wrapper
{
    public class VideoArgs : EncodingArgs
    {
        
        private Dictionary<string, string> _arguments;
        
        public VideoArgs()
        {
          _arguments = this.Arguments
      
        }
    
        public string Convert(VideoEncoder videoEncoder, VideoResize videoResize, VideoPreset videoPreset, VideoConstantRateFactor videoConstantRateFactor, AudioCodec audioCodec, Bitrate audioBitrate)
        {
            //-vf scale=-1:720 -c:v libx264 -preset veryfast -crf 23 -c:a aac -b:a 160k

            var arguments = _arguments.GetValue(videoResize.ToString()) +
                            _arguments.GetValue(videoEncoder.ToString()) +
                            _arguments.GetValue(videoPreset.ToString()) +
                            _arguments.GetValue(videoConstantRateFactor.ToString()) +
                            _arguments.GetValue(audioCodec.ToString()) +
                            _arguments.GetValue(audioBitrate.ToString());


            return arguments;



        }




        public string Convert(VideoEncoder videoEncoder, VideoResize videoResize, VideoPreset videoPreset, VideoConstantRateFactor videoConstantRateFactor, AudioCodec audioCodec)
        {
            //-vf scale=-1:720 -c:v libx264 -preset veryfast -crf 23 -c:a aac

           
              var arguments = _arguments.GetValue(videoResize.ToString()) +
                            _arguments.GetValue(videoEncoder.ToString()) +
                            _arguments.GetValue(videoPreset.ToString()) +
                            _arguments.GetValue(videoConstantRateFactor.ToString()) +
                            _arguments.GetValue(audioCodec.ToString());

            


             return arguments;

         


        }
        
        public string Copy(Streams streams)
        {
           
              var arguments = _arguments.GetValue(streams.ToString());
             
             return arguments;

         


        }
        
        
        
        public string GetFrame(string inputFile, int timeInSeconds,FrameSize frameSize, string outputFile)
        {
            //ffmpeg -ss 01:23:45 -i input -vframes 1 -q:v 2 output.jpg

            var arguments = "-ss " + timeInSeconds + 
                            " -i " + inputFile +
                            " -frames:v 1" +
                            _arguments.GetValue(frameSize.ToString()) +
                            " -q:v 2" +
                             " " + outputFile;

            

         return arguments;

        }



    
        



     
    }
}
