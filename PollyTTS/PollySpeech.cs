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
        public static void SynthesizeSpeechMarks(String text, String path)
        {
            //Amazon.Runtime.AWSCredentials credential = new Amazon.Runtime.CredentialManagement.SharedCredentialsFile();
            //Amazon.Runtime.AWSCredentials cr = new Amazon.Runtime.StoredProfileAWSCredentials();
            
          
            
            
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

            /*using (var reader = new Mp3FileReader(path))
                using(var converter = WaveFormatConversionStream.CreatePcmStream(reader))
            {
                WaveFileWriter.CreateWaveFile(path, converter);
            }*/

        }
    }
}
