using System;
using System.Linq;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!"3ger!g".Any(char.IsDigit))
            {
                Console.WriteLine(1);
            }
            else
            {
                Console.WriteLine(2);
            }
        }
    }
}