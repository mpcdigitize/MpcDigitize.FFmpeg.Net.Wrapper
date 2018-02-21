using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mpcdigitize.Ffmpeg.Wrapper
{
    public class EncodingArgs
    {

        private Dictionary<string, string> _arguments;
        
        public Dictionary<string,string> Arguments
        {
            get
            {
                return _arguments;
            }
        
        }

        public EncodingArgs()
        {
            _arguments = new Dictionary<string, string>();

            //Formats
            _arguments.Add("FormatMp3", " -f mp3 ");
            _arguments.Add("FormatFlac", " -f flac ");
            _arguments.Add("FormatMatroska", " -f matroska ");
            _arguments.Add("FormatMp4", " -f mp4 ");

            //Audio codec
            _arguments.Add("Libmp3lame", " -c:a libmp3lame ");
            _arguments.Add("Libvorbis", " -c:a libvorbis ");
            _arguments.Add("Libfaac", " -c:a libfaac ");
            _arguments.Add("Libfdk_aac", " -c:a Libfdk_aac ");
            _arguments.Add("Ac3", " -c:a ac3 ");
            _arguments.Add("Aac", " -c:a aac ");
            _arguments.Add("Mp3", " -c:a mp3 ");
            
            //Bitrate
            _arguments.Add("BitrateLow", " -ab 64k ");
            _arguments.Add("BitrateMedium", " -ab 112k ");
            _arguments.Add("BitrateNormal", " -ab 128k ");
            _arguments.Add("BitrateHigh", " -ab 160k ");
            _arguments.Add("BitrateVeryHigh", " -ab 192k ");

            //Frames
            _arguments.Add("singleFrame", " -frames:v 1 ");

            //Frame Size
            _arguments.Add("SizeThumbnail", " -s 400x225 ");
            _arguments.Add("SizeFanart720", " -s 1280x720 ");
            _arguments.Add("SizeFanart1080", " -s 1920x1080 ");

            //CRF
            _arguments.Add("CrfNormal", " -crf 23 ");
            _arguments.Add("CrfLow", " -crf 18 ");
            _arguments.Add("CrfHigh", " -crf 26 ");

            //Resize
            _arguments.Add("Mobile960", " -vf scale=960:-1 ");
            _arguments.Add("TV720p", " -vf scale=-1:720 ");
            _arguments.Add("FullHD1080p", " -vf scale=-1:1080 ");

            //Video Encoder
            _arguments.Add("Libx264", " -c:v libx264 ");
            _arguments.Add("Libxvid", " -c:v libxvid ");
            _arguments.Add("Libx265", " -c:v libx265 ");
            _arguments.Add("H264_nvenc", " -c:v h264_nvenc ");
            _arguments.Add("H264_qsv", " -c:v h264_qsv ");
            _arguments.Add("Hevc_qsv", " -c:v hevc_qsv ");
            _arguments.Add("Mpeg2video", " -c:v Mpeg2video ");

            //Presets
            _arguments.Add("UltraFast", " -preset ultrafast ");
            _arguments.Add("SuperFast", " -preset superfast ");
            _arguments.Add("VeryFast", " -preset veryfast ");
            _arguments.Add("Faster", " -preset faster ");
            _arguments.Add("Fast", " -preset fast ");
            _arguments.Add("Medium", " -preset medium ");
            _arguments.Add("Slow", " -preset slow ");
            _arguments.Add("Slower", " -preset slower ");
            _arguments.Add("VerySlow", " -preset veryslow ");

            //Banner
            _arguments.Add("HideBanner", " -v quiet -stats ");
            _arguments.Add("ShowBanner", "");
            
            //Streams
             _arguments.Add("AudioStream", " -vn -c copy ");
            _arguments.Add("VideoStream", " -ac -c copy ");
            _arguments.Add("AllStreams", " -c copy ");

        }





        public string GetValue(string argument)
        {

            string value = "";

            _arguments.TryGetValue(argument, out value);

            return value;
        }

    }
}
