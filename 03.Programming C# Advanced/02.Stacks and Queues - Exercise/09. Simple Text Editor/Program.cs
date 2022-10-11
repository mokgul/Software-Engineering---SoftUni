using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _09._Simple_Text_Editor
{
    internal class Editor
    {
        private static Stack<string> changes = new Stack<string>();
        private static string text = "";
        static void Main(string[] args)
        {
            Editor.changes.Push(Editor.text);
            Inputs();
        }

        private static void Inputs()
        {
            int commandsQty = int.Parse(Console.ReadLine());
            for (int i = 0; i < commandsQty; i++)
                Commands(Console.ReadLine());
        }

        private static void Commands(string input)
        {
            string[] tokens = input.Split();
            switch (tokens[0])
            {
                case "1": Append(tokens[1]); break;
                case "2": Erase(int.Parse(tokens[1])); break;
                case "3": CharAtIndex(int.Parse(tokens[1])); break;
                case "4": UndoChange(); break;
            }
        }

        private static void UndoChange()
        {
            Editor.changes.Pop();
            Editor.text = Editor.changes.Peek();
        }


        private static void CharAtIndex(int index)
        => Console.WriteLine(Editor.text[index - 1]);

        private static void Erase(int count)
        {
            Editor.text = Editor.text.Remove(text.Length - count);
            Editor.changes.Push(Editor.text);
        }

        private static void Append(string token)
        {
            Editor.text += token;
            Editor.changes.Push(Editor.text);
        }
    }
}
