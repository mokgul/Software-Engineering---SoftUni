using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Songs_Queue
{
    internal class Playlist
    {
        private static Queue<string> playlist;
       
        static void Main(string[] args)
        {
            Input();
            Commands();
            Console.WriteLine("No more songs!");
        }

        private static void Input() 
            => Playlist.playlist = new Queue<string>(Console.ReadLine()
                .Split(", ",StringSplitOptions.RemoveEmptyEntries));

        private static void Commands()
        {
            while(Playlist.playlist.Count > 0)
            {
                string[] commands = Console.ReadLine().Split();
                switch (commands[0])
                {
                    case "Play":
                        Play();
                        break;
                    case "Add":
                        string song = string.Join(" ",commands.Skip(1));
                        AddSong(song);
                        break;
                    case "Show":
                        ShowPlaylist();
                        break;

                }
            }
        }

        private static void ShowPlaylist() => Console.WriteLine(string.Join(", ",Playlist.playlist));

        private static void AddSong(string song)
        {
            if(Playlist.playlist.Contains(song))
            {
                Console.WriteLine($"{song} is already contained!");
                return;
            }
            Playlist.playlist.Enqueue(song);
        }

        private static void Play() => Playlist.playlist.Dequeue();
    }
}
