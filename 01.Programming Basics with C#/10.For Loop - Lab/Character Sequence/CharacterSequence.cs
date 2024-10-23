using System;

namespace Character_Sequence
{
    class CharacterSequence
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            for (int i = 0; i < input.Length; i++)
            {
                Console.WriteLine(input[i]);
            }    
        }
    }
}
