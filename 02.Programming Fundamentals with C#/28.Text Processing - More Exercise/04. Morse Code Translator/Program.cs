using System;
using System.Linq;
using System.Text;

namespace _04._Morse_Code_Translator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] morse = {
                ".-",   // A
                "-...", // B
                "-.-.", // C
                "-..",  // D
                ".",    // E
                "..-.", // F
                "--.",  // G
                "....", // H
                "..",   // I
                ".---", // J
                "-.-",  // K
                ".-..", // L
                "--",   // M
                "-.",   // N
                "---",  // O
                ".--.", // P
                "--.-", // Q
                ".-.",  // R
                "...",  // S
                "-",    // T
                "..-",  // U
                "...-", // V
                ".--",  // W
                "-..-", // X
                "-.--", // Y
                "--.."  // Z
            };
            char[] upper =
            {
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T',
                'U', 'V', 'W', 'X', 'Y', 'Z'
            };
            
            string[] hiddenMessage = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
            StringBuilder resultMessage = new StringBuilder();
            for (int i = 0; i < hiddenMessage.Length; i++)
            {
                if (morse.Contains(hiddenMessage[i]))
                {
                    var index = Array.IndexOf(morse,hiddenMessage[i]);
                    resultMessage.Append(upper[index]);
                }
                else
                {
                    resultMessage.Append(' ');
                }
            }

            Console.WriteLine(resultMessage);
        }
    }
}