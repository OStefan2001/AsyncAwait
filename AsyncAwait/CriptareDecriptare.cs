using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class CriptareDecriptare
    {
        public static Task<string> CriptareAsync1(string text)
        {
            return Task.Run(async () =>
            {
                StringBuilder textCriptat = new StringBuilder();
                char randomChar;

                Random rand = new Random();

                for (int i = 0; i <= (text.Length - 1); i++)
                {
                    randomChar = (char)(rand.Next(128));
                    textCriptat.Append(((char)(text[i] ^ randomChar)).ToString());
                    textCriptat.Append(((char)(randomChar ^ (128 - i))).ToString());
                }

                // Așteaptă completarea imediată a task-ului fără să adaugi delay
                await Task.Delay(200);

                return textCriptat.ToString();
            });
        }


        public static Task<string> DecriptareAsync1(string textCriptat)
        {
            return Task.Run(async() =>
            {
                StringBuilder textDecript = new StringBuilder();

                for (int i = 0; i <= (textCriptat.Length - 1); i += 2)
                {
                    char criptChar = textCriptat[i];
                    char xorChar = textCriptat[i + 1];

                    textDecript.Append(((char)(criptChar ^ (128 - (i / 2)) ^ xorChar)).ToString());
                }
                await Task.Delay(200);
                return textDecript.ToString();
            });
        }

    }
}
