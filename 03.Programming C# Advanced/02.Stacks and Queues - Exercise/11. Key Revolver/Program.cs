using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;

namespace _11._Key_Revolver
{
    internal class Mission
    {
        private static int _bulletPrice;
        private static int _gunCapacity;
        private static Stack<int> _bullets;
        private static Queue<int> _locks;
        private static int _money;
        private static int _bulletsShot;
        static void Main(string[] args)
        {
            Inputs();
            Shooting();
        }

        private static void Shooting()
        {
            int bulletCount = 0;
            while (true)
            {
                if (Mission._locks.Count == 0)
                {
                    Success();
                    break;
                } 
                if(Mission._bullets.Count == 0)
                {
                    Failed();
                    break;
                }
                int bullet = Mission._bullets.Peek();
                int currentLock = Mission._locks.Peek();
                if (bullet <= currentLock)
                {
                    Bang();
                    bulletCount++;
                }
                else
                {
                    FailedToUnlock();
                    bulletCount++;
                }
                if (bulletCount == Mission._gunCapacity && Mission._bullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                    bulletCount = 0;
                }
            }
        }

        private static void Failed()
        {
            Console.WriteLine($"Couldn't get through. Locks left: {Mission._locks.Count}");
        }

        private static void Success()
        {
            int earned = Mission._money - Mission._bulletsShot * Mission._bulletPrice;
            Console.WriteLine($"{Mission._bullets.Count} bullets left. Earned ${earned}");
        }

        private static void FailedToUnlock()
        {
            Console.WriteLine("Ping!");
            Mission._bullets.Pop();
            Mission._bulletsShot++;
        }

        private static void Bang()
        {
            Console.WriteLine("Bang!");
            Mission._bullets.Pop();
            Mission._locks.Dequeue();
            Mission._bulletsShot++;
        }

        private static void Inputs()
        {
            Mission._bulletPrice = int.Parse(Console.ReadLine());
            Mission._gunCapacity = int.Parse(Console.ReadLine());
            Mission._bullets = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            Mission._locks = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Mission._money = int.Parse(Console.ReadLine());
        }
    }
}
