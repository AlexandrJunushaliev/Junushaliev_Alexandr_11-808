/*Задача Cond7 
 *Автор Александр Джунушалиев 11-808
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cond7
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] data = Console.ReadLine().Split(' ');
            double x = double.Parse(data[0]);
            double y = double.Parse(data[1]);
            double n = double.Parse(data[2]);
            int ans = 1;
            //если х<=y, то в голосовании нет необходимости, так как условие задачи достигнуто
            if (x <= y) Console.WriteLine('0');
            else
            {
                //Х - начальная сумма оценок
                int X;
                //Если х=10, то очевидно, что все оценки были 10
                if (x != 10.0)
                {
                    X = (int)((x + 0.04999999999) * n);
                    while (X / n >= x + 0.049999999999) X--;
                }
                else
                {
                    X = (int)(x * n);
                }
                ans = (int)((y * n - X) / (1 - y - 0.05));
                while (((ans + X) / (ans + n)) < y + 0.04999999999) ans--;
                Console.WriteLine(ans + 1); //First way, with cycles
            }
            //if (y >= x)
            //{
            //    Console.WriteLine(0);
            //    return;
            //}

            //Console.WriteLine(Math.Ceiling(n * ((x + 0.05 - double.Epsilon) - (y + 0.05 - double.Epsilon)) / (y + 0.05 - double.Epsilon - 1))); - Second way, without cycles and AC
        }
    }
}
