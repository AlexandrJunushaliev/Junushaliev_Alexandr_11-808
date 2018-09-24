/*Задача Cond3 
 *Автор Александр Джунушалиев 11-808
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cond3
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = int.Parse(Console.ReadLine());
            int s1 = s + 1;
            int s2 = s - 1;
            string s11 = s1.ToString();
            string s22 = s2.ToString();
            int[] mass = new int[6];
            var f = 0;
            var j = 0;
            for (var i = 6 - s11.Length; i < 6; i++)
            {
                mass[i] = int.Parse(s11[j].ToString());
                j++;
            }
            j = 0;    
            if (mass[0] + mass[1] + mass[2] == mass[3] + mass[4] + mass[5]) f = 1;
            for (var i = 6 - s22.Length; i < 6; i++)
            {
                mass[i] = int.Parse(s22[j].ToString());
                j++;
            }               
            if (mass[0] + mass[1] + mass[2] == mass[3] + mass[4] + mass[5]) f = 1;
            if (f == 1) Console.WriteLine("Yes");
            else Console.WriteLine("No");
        }
    }
}
