using mpcdigitize.ffmpeg;
using mpcdigitize.ffmpeg.wrapper;
using Mpcdigitize.Ffmpeg.Wrapper;
using Mpcdigitize.Ffmpeg.Wrapper.Enums;
using System;

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    public class Program
    {
        static void Main(string[] args)
        {
            var arguments = new FfmpegArgumentsDictionary();
            //  var ffmpeg = new Ffmpeg(@"C:\ffmpeg\ffmpeg.exe");
            //  string inputFile = @"C:\input\testmp4.mp4";
            //string outputFile = @"C:\output\testmp3_2.mp3";

            // ffmpeg.Audio.Convert();
            //ffmpeg.Video.Convert();


            var job = new EncodingJob();
            var argsSelector = new ArgsSelector();


            job.InputFile = @"C:\input\testWTVShort.wtv";
            job.OutputFile = @"C:\videos\testConvert_2.mkv";
            job.ConversionArguments = argsSelector.Video.Convert3(VideoEncoder.Libx264, VideoResize.TV720p, VideoPreset.VeryFast, VideoConstantRateFactor.CrfNormal, AudioCodec.Ac3);

            var ffmpeg = new FfmpegEncoder(@"C:\ffmpeg\ffmpeg.exe");
            var dipl = new DisplayInfo();

            ffmpeg.VideoEncoding += dipl.DisplayProgress;

            ffmpeg.DoWork(job);




            //   string vid_input = @"C:\input\testWTV.wtv";
            //   string vid_output = @"C:\frames\frame_14.jpg";
            //    int seconds = 100;


            //string vinput = @"C:\input\testWTVShort.wtv";
            //         string voutput = @"C:\videos\testConvert_2.mkv";

            //    string metadataFile = @"C:\output\metadata2.txt";


            //    string streamMP3 = @"http://stream3.polskieradio.pl:8904/;stream";
            //    string streamLBC = @"http://media-sov.musicradio.com/LBCLondon?type=.flv&awsparams=kxsegs:||;&amsparams=playerid:UKRP;skey:1484626109;&kuid=LBH7UpJ-&amsparams%3Dplayerid%3AUKRP%3Bskey%3A1484712106&listenerid=6c8483299a871c0dba4b6177f4ad49a3&awparams=companionAds%3Atrue&rpempv=3.1.101;";
            //    string streamPR3 = @"http://stream13.polskieradio.pl/pr3/pr3.sdp/playlist.m3u8";
            //    string streamYT = @"https://r5---sn-8xgp1vo-xfgee.googlevideo.com/videoplayback?mm=31&ip=100.2.105.63&mn=sn-8xgp1vo-xfgee&sparams=ctier%2Cdur%2Cei%2Chightc%2Cid%2Cinitcwndbps%2Cip%2Cipbits%2Citag%2Clmt%2Cmime%2Cmm%2Cmn%2Cms%2Cmv%2Cpfa%2Cpl%2Cratebypass%2Crequiressl%2Csource%2Cexpire&mt=1515274479&pl=24&mv=m&ms=au&requiressl=yes&mime=video%2Fmp4&id=o-ACQ6ov5ELiikC50hNfCUM4rzxmE4pL4_jKvuNmP-MLH0&dur=1043.690&ipbits=0&ctier=A&lmt=1515045204820098&source=youtube&signature=48068C0A59C34D200B9B8EB32BBB5D83438875B4.FE27028FAFAEC49DF49CF1B08383BA320B917A&ratebypass=yes&initcwndbps=913750&pfa=5&expire=1515296198&itag=22&ei=ZUFRWrD4LoGe8wSl4aLADA&hightc=yes&key=yt6&title=INSIDE%20a%20humongous%20Airbnb%20MULTI-MILLION%20%24%24%24%20house%20in%20Colorado";

            //    string streamLBC2 = @"http://media-the.musicradio.com/LBCUK?awsparams=kxsegs:||;&amsparams=playerid:UKRP;skey:1515264808;&kuid=&amsparams%3Dplayerid%3AUKRP%3Bskey%3A1515265107&listenerid=8a54dc7d4e271f8bf9b3542c704d4b106f8da2508e63194739ae2364b0ec72a1&awparams=companionAds%3Atrue";
            //    //http://media-the.musicradio.com/LBCUK?awsparams=kxsegs:||;&amsparams=playerid:UKRP;skey:1515264808;&kuid=&amsparams%3Dplayerid%3AUKRP%3Bskey%3A1515265107&listenerid=8a54dc7d4e271f8bf9b3542c704d4b106f8da2508e63194739ae2364b0ec72a1&awparams=companionAds%3Atrue
            //    string saveStream = @"C:\output\stream_10_lbc.mp4";

            //    Console.WriteLine("Starting");
            //    //ffmpeg.ConvertAudio(inputFile, AudioCodec.libfdk_aac, Bitrate.high, outputFile);
            //    //ffmpeg.ExtractVideoFrame(vid_input, seconds, FrameSize.thumbnail, vid_output);


            //->  ffmpeg.Video.Convert3(vinput,VideoEncoder.Libx264, VideoResize.TV720p, VideoPreset.VeryFast, VideoConstantRateFactor.CrfNormal,AudioCodec.Ac3,voutput);

            //  string path = @"C:\videos\test.txt";

            //System.IO.StreamReader file = new StreamReader( @"C:\videos\test.txt");
            //string line;

            //while ((line = file.ReadLine()) != null)
            //{
            //    Console.WriteLine(line);
            //}

            //file.Close();

            //Console.WriteLine(ffmpeg.Video.StringOutput);

            //    //ffmpeg.SaveStream(streamMP3, saveStream);
            //    // ffmpeg.ConvertAudio(streamPR3, AudioEncoder.Libmp3lame, Bitrate.BitrateNormal, saveStream);

            //    // ffmpeg.SaveStreamCopy(streamLBC2, saveStream);

            //   // ffmpeg.SaveMetadata(streamLBC2, metadataFile);

            //// ffmpeg.GetInfo(vid_input);



            //  Console.WriteLine(ffmpeg.Video.mconsole);
            Console.WriteLine("Completed");
            Console.ReadLine();


        }


       
    }
}
