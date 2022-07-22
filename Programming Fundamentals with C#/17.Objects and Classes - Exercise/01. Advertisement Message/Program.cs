using System;
using System.Collections.Generic;

namespace _01._Advertisement_Message
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Info info = new Info();
            List<Message> messages = new List<Message>();

            int amount = int.Parse(Console.ReadLine());

            for (int i = 0; i < amount; i++)
            {
                Random random = new Random();
                Message message = new Message()
                {
                    Phrase = info.Phrases[random.Next(0, info.Phrases.Count)],
                    Event = info.Events[random.Next(0, info.Events.Count)],
                    Author = info.Authors[random.Next(0, info.Authors.Count)],
                    City = info.Cities[random.Next(0, info.Cities.Count)],
                };
                messages.Add(message);
            }

            foreach (Message mesage in messages)
            {
                Console.WriteLine($"{mesage.Phrase} {mesage.Event} " +
                                  $"{mesage.Author} - {mesage.City}");
            }
        }

        class Message
        {
            public string Phrase { get; set; }

            public string Event { get; set; }

            public string Author { get; set; }

            public string City { get; set; }
        }

        class Info
        {
            public List<string> Phrases = new List<string>()
            {
                "Excellent product.",
                "Such a great product.",
                "I always use that product.",
                "Best product of its category.",
                "Exceptional product.",
                "I can’t live without this product."
            };

            public List<string> Events = new List<string>()
            {
                "Now I feel good.",
                "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.",
                "I feel great!"
            };

            public List<string> Authors = new List<string>()
                { 
                    "Diana",
                    "Petya",
                    "Stella",
                    "Elena",
                    "Katya",
                    "Iva", 
                    "Annie", 
                    "Eva"
                };

            public List<string> Cities = new List<string>()
            {
                "Burgas",
                "Sofia",
                "Plovdiv",
                "Varna",
                "Ruse"
            };
        }
    }
}
