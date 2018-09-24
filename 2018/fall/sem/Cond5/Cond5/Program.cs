/*Задача Cond5
 *Автор Александр Джунушалиев 11-808
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cond5
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = Console.ReadLine();
            var data1 = data.Split(' ');
            var l = int.Parse(data1[0]);
            var k = int.Parse(data1[1]);
            var h = int.Parse(data1[2]);
            //количество отрезков длиной k в отрезке l умножается на h. остаток пути чукча проезжает моментально * 
            var min = (l / k) * h;
            //остаток пути чукча проезжает за h
            var max = min + h;
            //если l делится нацело на k, то min не может отличаться от max, так как есть условие постоянности проезда k за h
            if (l % k == 0) max = min;
            Console.WriteLine(min+" "+max);
        }
    }
}
