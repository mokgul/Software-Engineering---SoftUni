using System;

namespace _10._Poke_Mon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // poke power - N
            // distance between targets  - M
            // exhaustion factor - Y

            uint pokePower = uint.Parse(Console.ReadLine());
            uint distance = uint.Parse(Console.ReadLine());
            byte exhaustFactor = byte.Parse(Console.ReadLine());

            uint halfValue = pokePower / 2;
            int pokedTargets = 0;

            while (pokePower >= distance)
            {
                pokePower -= distance;
                pokedTargets++;
                if (pokePower == halfValue)
                {
                    if (exhaustFactor != 0)
                        pokePower /= exhaustFactor;
                }
            }
            Console.WriteLine(pokePower);
            Console.WriteLine(pokedTargets);
        }
    }
}