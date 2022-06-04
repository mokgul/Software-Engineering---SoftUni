using System;

namespace Rage_Expenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int lost_games        = int.Parse(Console.ReadLine());
            double headset_price  = double.Parse(Console.ReadLine());
            double mouse_price    = double.Parse(Console.ReadLine());
            double keyboard_price = double.Parse(Console.ReadLine());
            double display_price  = double.Parse(Console.ReadLine());

            int trashed_headset  = 0;
            int trashed_mouse    = 0;
            int trashed_keyboard = 0;
            int trashed_display  = 0;

            for(int game = 1; game <= lost_games; game++)
            {
                if(game % 2 == 0) trashed_headset++;
                if(game % 3 == 0) trashed_mouse++;
                if(game % 6 == 0)
                {
                    trashed_keyboard++;
                    if (trashed_keyboard % 2 == 0 && trashed_keyboard != 0) trashed_display++;
                }
            }
            double expenses = trashed_headset * headset_price + trashed_mouse* mouse_price + trashed_keyboard* keyboard_price + trashed_display* display_price;
            Console.WriteLine($"Rage expenses: {expenses:f2} lv.");
        }
    }
}