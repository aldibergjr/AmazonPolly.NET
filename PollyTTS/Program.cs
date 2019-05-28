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
            PollySpeech.SynthesizeSpeechMarks(@"Olá Maria José..
Para sua comodidade,, a Universidade Uninassau envia um lembrete no valor de 123 reais e 54 centavos,, que venceu no dia 12 de março de 2019.. Em caso de dúvidas entrar em contato com Universidade Uninassau..clique 1 para pagar.
clique 2 para contestar.", @"c:\users\Aldiberg\mensagem.mp3");
        }        
    }
}
