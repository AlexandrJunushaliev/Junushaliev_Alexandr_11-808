/*Задача Cond4 
 *Автор Александр Джунушалиев 11-808
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cond4
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int d = int.Parse(Console.ReadLine());
            if (b < c || a > d) Console.WriteLine(0);
            else
            if (b >= c && a >= c && a <= d && b <= d) Console.WriteLine(b - a);
            else
            if (c <= b && d <= b && c >= a && d >= a) Console.WriteLine(d - c);
            else Console.WriteLine(Math.Min(d, b) - Math.Max(a, c));           
        }
    }
}
