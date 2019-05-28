using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.Polly;
using Amazon.Polly.Model;
using System.IO;
using NAudio.Wave;
using System.Threading;
namespace PollyTTS
{
    class PollySpeech
    {
        public void getAudio(String text, String path)
        {
            AmazonPollyClient pc = new AmazonPollyClient(Amazon.RegionEndpoint.USEast1);

            SynthesizeSpeechRequest sreq = new SynthesizeSpeechRequest();
            sreq.Text = text;
            sreq.OutputFormat = OutputFormat.Mp3;
            sreq.VoiceId = VoiceId.Vitoria;
            sreq.SampleRate = "8000";
            SynthesizeSpeechResponse sres = pc.SynthesizeSpeech(sreq);

            using (FileStream fileStream = File.Create(path))
            {
                sres.AudioStream.CopyTo(fileStream);
                fileStream.Flush();
                fileStream.Close();
            }
            Thread.Sleep(1000);
        }
        public void convertAudio(string path)
        {
            
            using (var reader = new Mp3FileReader(path))
            {
                var newFormat = new WaveFormat(8000, 16, 1);
                using (var converter = new WaveFormatConversionStream(newFormat, reader)) {


                    WaveFileWriter.CreateWaveFile(@"c:\users\Aldiberg\mensagem.wav", converter);
                }
                   
                 
                
            }
            
           

        }
        public void SynthesizeSpeechMarks(String text, String path)
        {
            //var func = this.getAudio(text, path);   
            //Amazon.Runtime.AWSCredentials credential = new Amazon.Runtime.CredentialManagement.SharedCredentialsFile();
            //Amazon.Runtime.AWSCredentials cr = new Amazon.Runtime.StoredProfileAWSCredentials();
            // Thread t1 = new Thread(new ThreadStart(this.getAudio(text, path)));
            Thread audio = new Thread(() => this.getAudio(text,path));
            Thread convert = new Thread(() => this.convertAudio(@"c:\users\Aldiberg\mensagem.mp3"));
            audio.Start();
            audio.Join();
            convert.Start();





        }
    }
}
