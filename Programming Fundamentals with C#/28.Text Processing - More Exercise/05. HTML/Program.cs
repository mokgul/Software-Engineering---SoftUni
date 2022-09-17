using System;
using System.Collections.Generic;

namespace _05._HTML
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Text> article = new List<Text>();

            string title = Console.ReadLine();
            article.Add(new Text("<h1>",title,"</h1>"));

            string content = Console.ReadLine();
            article.Add(new Text("<article>",content,"</article>"));

            string comment = Console.ReadLine();
            
            while (comment != "end of comments")
            {
                article.Add(new Text("<div>", comment, "</div>"));
                comment = Console.ReadLine();
            }

            foreach (Text text in article)
            {
                Console.WriteLine(text.LineOne);
                Console.WriteLine("    " + text.LineTwo);
                Console.WriteLine(text.LineThree);
            }
        }
    }

    class Text
    {
        public Text(string lineOne, string lineTwo, string lineThree)
        {
            this.LineOne = lineOne; this.LineTwo = lineTwo; this.LineThree = lineThree;
        }
        public string LineOne { get; set; }
        public string LineTwo { get; set; }
        public string LineThree { get; set; }
    }
}
