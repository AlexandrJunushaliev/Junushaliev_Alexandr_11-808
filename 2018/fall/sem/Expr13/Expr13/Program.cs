using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expr13
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = Console.ReadLine();
            var data1 = data.Split(' ');
            var lengthOfTheSide = int.Parse(data1[0]);
            var lengthOfTheRope = int.Parse(data1[1]);
            if (lengthOfTheRope >= lengthOfTheSide * Math.Sqrt(2) / 2)
            {
                Console.WriteLine(lengthOfTheSide * lengthOfTheSide);
            }
            else if (lengthOfTheRope <= lengthOfTheSide / 2.0)
            {
                Console.WriteLine(lengthOfTheRope * lengthOfTheRope * Math.PI);
            }
            else
            {
                var uncoveredArea = 0.5 * lengthOfTheRope * lengthOfTheRope * (2 * Math.Acos(lengthOfTheSide / (2.0 * lengthOfTheRope)) - Math.Sin(2 * Math.Acos(lengthOfTheSide / (2.0 * lengthOfTheRope))));
                Console.WriteLine("{0:00.###}", Math.PI * lengthOfTheRope * lengthOfTheRope - 4 * uncoveredArea);
            }
        }
    }
}
