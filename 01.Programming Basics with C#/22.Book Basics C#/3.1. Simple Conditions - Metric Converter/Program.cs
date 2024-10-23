using System;

namespace _3._1._Simple_Conditions___Metric_Converter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1 mm = 1/1000 m, 5 mm = 5* 1/1000 >> 5 /1000 >> size / millimeters...
            var millimeters = 1000; // = 1m, 1000 mm = 1m / 1000 >> 1 mm = 1/1000m >> 1 mm = 0.001m
            var centimeters = 100; // = 1m, 1 cm = 1 / 100m >> 1 cm = 0.01m
            var miles = 0.000621371192; // = 1m, 1 mile = 1 / 0.000621371192m
            var inches = 39.3700787; // = 1m, 1 inch = 1 / 39.3700787m
            var kilometers = 0.001; // = 1m, 1 km = 1 / 0.001m
            var feet = 3.2808399; // = 1m, 1 ft = 1 / 3.2508399
            var yards = 1.0936133; // = 1m,  1 yd = 1 / 1.0936133

            var size = double.Parse(Console.ReadLine());
            var sourceMetric = Console.ReadLine().ToLower();
            var destMetric = Console.ReadLine().ToLower();

            if (sourceMetric == "mm") size /= millimeters; // >> mm to meter
            else if (sourceMetric == "cm") size /= centimeters; // cm to meter
            else if (sourceMetric == "mi") size /= miles; // miles to meter
            else if (sourceMetric == "in") size /= inches; // inches to meter
            else if (sourceMetric == "km") size /= kilometers; // km to meter
            else if (sourceMetric == "ft") size /= feet; // ft to meter
            else if (sourceMetric == "yd") size /= yards; // yd to meter

            if (destMetric == "mm") size *= millimeters; // meter to mm
            else if (destMetric == "cm") size *= centimeters; //meter to cm
            else if (destMetric == "mi") size *= miles; // meter to mile
            else if (destMetric == "in") size *= inches; // meter to inch
            else if (destMetric == "km") size *= kilometers; // meter to km
            else if (destMetric == "ft") size *= feet; // meter to feet
            else if (destMetric == "yd") size *= yards; // meter to yard

            Console.WriteLine(size + " " + destMetric);
        }
    }
}
