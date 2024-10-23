using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Deck_of_Cards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> cards = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            int nLines = int.Parse(Console.ReadLine());

            cards = Commands(cards, nLines);
            PrintList(cards);
        }

        private static void PrintList(List<string> cards)
        {
            Console.WriteLine(string.Join(", ", cards));
        }
        private static List<string> Commands(List<string> cards, int nLines)
        {
            string input = String.Empty;

            for (int i = 0; i < nLines; i++)
            {
                input = Console.ReadLine();
                string[] command = input.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                switch (command[0])
                {
                    case "Add":
                        cards = AddCard(cards, command);
                        break;
                    case "Remove":
                        cards = RemoveCard(cards, command);
                        break;
                    case "Remove At":
                        cards = RemoveCardAtIndex(cards, command);
                        break;
                    case "Insert":
                        cards = InsertCard(cards, command);
                        break;
                }
            }
            return cards;
        }

        private static List<string> AddCard(List<string> cards, string[] command)
        {
            string cardName = command[1];
            if (!CheckInList(cards, cardName))
            {
                cards.Add(cardName);
                Console.WriteLine("Card successfully added");
            }
            else
            {
                Console.WriteLine("Card is already in the deck");
            }

            return cards;
        }

        private static List<string> RemoveCard(List<string> cards, string[] command)
        {
            string cardName = command[1];
            if (CheckInList(cards, cardName))
            {
                cards.Remove(cardName);
                Console.WriteLine("Card successfully removed");
            }
            else
            {
                Console.WriteLine("Card not found");
            }

            return cards;
        }

        private static List<string> RemoveCardAtIndex(List<string> cards, string[] command)
        {
            int index = int.Parse(command[1]);
            if (index < 0 || index > cards.Count - 1)
            {
                Console.WriteLine("Index out of range");
                return cards;
            }
            else
            {
                cards.RemoveAt(index);
                Console.WriteLine("Card successfully removed");
            }

            return cards;
        }

        private static List<string> InsertCard(List<string> cards, string[] command)
        {
            int index = int.Parse(command[1]);
            string cardName = command[2];
            if (index < 0 || index > cards.Count - 1)
            {
                Console.WriteLine("Index out of range");
                return cards;
            }
            else if (CheckInList(cards, cardName))
            {
                Console.WriteLine("Card is already added");
            }
            else
            {
                cards.Insert(index, cardName);
                Console.WriteLine("Card successfully added");
            }

            return cards;
        }

        private static bool CheckInList(List<string> cards, string card)
        {
            if (cards.Contains(card))
                return true;
            return false;
        }
    }
}
