/*Задача Cond2
 *Автор Александр Джунушалиев 11-808
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cond2
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            int z = int.Parse(Console.ReadLine());
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            if (a >= x && b >= y || a >= y && b >= x || a >= x && b >= z || a >= z && b >= x || a >= z && b >= y || a >= y && b >= z)
                Console.WriteLine(true);
            else Console.WriteLine(false);
        }
    }
}
