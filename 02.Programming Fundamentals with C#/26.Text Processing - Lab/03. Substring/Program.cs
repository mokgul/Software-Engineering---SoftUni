using System;

namespace _03._Substring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string strToRemove = Console.ReadLine();
            string strToEdit = Console.ReadLine();

            int index = strToEdit.IndexOf(strToRemove);
            while (index != -1)
            {
                strToEdit = strToEdit.Remove(index,strToRemove.Length);
                index = strToEdit.IndexOf(strToRemove);
            }

            Console.WriteLine(strToEdit);
        }
    }
}
