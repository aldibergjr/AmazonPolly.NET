using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.Polly;
using Amazon.Polly.Model;
using System.IO;
using NAudio.Wave;
namespace PollyTTS
{
    class PollySpeech
    {
        async public void getAudio(String text, String path)
        {
            AmazonPollyClient pc = new AmazonPollyClient(Amazon.RegionEndpoint.USEast1);

            SynthesizeSpeechRequest sreq = new SynthesizeSpeechRequest();
            sreq.Text = text;
            sreq.OutputFormat = OutputFormat.Mp3;
            sreq.VoiceId = VoiceId.Vitoria;
            sreq.SampleRate = "8000";
            SynthesizeSpeechResponse sres = pc.SynthesizeSpeech(sreq);


            FileStream fileStream =  File.Create(path);

            sres.AudioStream.CopyTo(fileStream);
            fileStream.Flush();
            fileStream.Close();
            FileStream fs = File.OpenRead(path);
            using (Mp3FileReader reader = new Mp3FileReader(fs))
            {
                var newFormat = new WaveFormat(8000, 16, 1);
                using (var converter = new WaveFormatConversionStream(newFormat,reader))
                {
                    var pathw = path + ".wav";
                    WaveFileWriter.CreateWaveFile(pathw, converter);
                     
                }
            }
            fs.Dispose();
            File.Delete(path);


        }
     
        public void SynthesizeSpeechMarks(String text, String path)
        {

            getAudio(text,path);
            
            //convert.Start();





        }
    }
}
