
using System;
using System.Collections.Generic;

namespace _03._Cards
{
    public class Card
    {
        private readonly List<string> _faces = new List<string>()
        {
            "2", "3", "4", "5", "6",
            "7", "8", "9", "10",
            "J", "Q", "K", "A"
        };

        private readonly List<string> _suits = new List<string>()
        {
            "S", "H", "D", "C"
        };

        private string _face;
        private char _suit;
        public Card(string face, string suit)
        {
            Face = face.Length > 2 
                ? throw new ArgumentException("Invalid card!") : face;
            Suit = char.Parse(suit.Length > 1 
                ? throw new ArgumentException("Invalid card!") : suit);
        }

        private string TakeChar(string attribute)
        {
            string ch = attribute.ToLower() switch
            {
                "jack" => "J",
                "queen" => "Q",
                "king" => "K",
                "ace" => "A",
                _ => throw new ArgumentException("Invalid card!")
            };
            return ch;
        }


        public string Face
        {
            get => _face;
            set
            {
                if (value.Length > 2)
                    value = TakeChar(value);
                if (!_faces.Contains(value))
                    throw new ArgumentException("Invalid card!");
                
                _face = value;
            }
        }

        public char Suit
        {
            get => _suit;
            private set
            {
                _suit = value switch
                {
                    'S' => '\u2660',
                    'H' => '\u2665',
                    'D' => '\u2666',
                    'C' => '\u2663',
                    _ => throw new ArgumentException("Invalid card!")
                };
            }
        }

        public override string ToString()
            => $"[{Face}{Suit}]";
    }
}

