using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollyTTS
{
	class Program
	{
        public static void Main(string[] args)
        {
            PollySpeech polly = new PollySpeech();
            polly.SynthesizeSpeechMarks(@"Seu texto de exemplo que será convertido para wav..
            ", @"c:\caminho\nome_do_audio_sem_ext");
        }        
    }
}
