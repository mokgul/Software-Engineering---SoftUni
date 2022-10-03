#pragma warning disable CS8604 // Possible null reference argument.
double rent = double.Parse(Console.ReadLine());
#pragma warning restore CS8604 // Possible null reference argument.
double statues = 0.70 * rent;
double catering = 0.85 * statues;
double sounding = 0.50 * catering;
double total = rent + statues + catering + sounding;
Console.WriteLine("{0:0.00}", total);
