using System;

namespace On_Time_for_the_Exam
{
    class OnTime
    {
        static void Main(string[] args)
        {
            int examHour = int.Parse(Console.ReadLine());
            int examMinutes = int.Parse(Console.ReadLine());
            int arrivalHour = int.Parse(Console.ReadLine());
            int arrivalMinutes = int.Parse(Console.ReadLine());

            int examTime = examHour * 60 + examMinutes;
            int arrivalTime = arrivalHour * 60 + arrivalMinutes;
            int differance = Math.Abs(examTime - arrivalTime);
            int hours = differance / 60;
            double minutes = differance % 60;

            if (arrivalTime == examTime || examTime - arrivalTime <= 30)
            {
                if (arrivalTime == examTime)
                    Console.WriteLine("On time");
                else
                {
                    Console.WriteLine("On time");
                    Console.WriteLine($"{minutes} minutes before the start");
                }
            }
            if (arrivalTime < (examTime - 30))
            {
                Console.WriteLine("Early");
                if (hours == 0)
                    Console.WriteLine($"{minutes} minutes before the start");
                else
                {
                    if (minutes < 10)
                        Console.WriteLine($"{hours}:0{minutes} hours before the start");
                    else
                        Console.WriteLine($"{hours}:{minutes} hours before the start");
                }
            }
            if (arrivalTime > examTime)
            {
                Console.WriteLine("Late");
                if (hours == 0)
                    Console.WriteLine($"{minutes} minutes after the start");
                else
                {
                    if (minutes < 10)
                        Console.WriteLine($"{hours}:0{minutes} hours after the start");
                    else
                        Console.WriteLine($"{hours}:{minutes} hours after the start");
                }
            }


        }
    }
}
