using System;

namespace The_Most_Powerful_Word
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = "";
            string strongest = "";
            string vowels = "aeiouyAEIОUY";
            double points = 0;
            double best = 0;
            bool isVowel = false;

            word = Console.ReadLine();
            while (word != "End of words")
            {
                for (int i = 0; i < word.Length; i++)
                {
                    char currentLetter = word[i];
                    points += currentLetter;
                    if (i == 0)
                    {

                        if (vowels.Contains(currentLetter.ToString()))
                        {
                            isVowel = true;
                        }
                    }
                }

                if (isVowel)
                {
                    points *= word.Length;
                }
                else
                {
                    points = Math.Floor(points / word.Length);
                }
                if (points >= best)
                {
                    best = points;
                    strongest = word;
                }
                points = 0;
                isVowel = false;
                word = Console.ReadLine();
            }
            Console.WriteLine($"The most powerful word is {strongest} - {best}");
        }
    }
}
