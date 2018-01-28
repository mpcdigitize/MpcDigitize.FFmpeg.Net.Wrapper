using Mpcdigitize.Ffmpeg.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mpcdigitize.ffmpeg.wrapper
{
    public class ArgsSelector
    {

 
        private string _programPath;
 
        public Audio Audio = new Audio();
        public Video Video = new Video();
       // public JobStatus JobStatus = new JobStatus();
       

        public ArgsSelector()
        {
           // _programPath = programPath;
          //  Audio.Ffmpeg = this;
          //  Video.Ffmpeg = this;
        }

       


        public string GetPath()
        {
            return this._programPath;

        }

    }
}
