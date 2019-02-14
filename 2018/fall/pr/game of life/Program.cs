using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Program
    {
        public static void Paint(bool[,] field)
        {
            Console.SetCursorPosition(0, 0);
            for (int y = 0; y < field.GetLength(1); y++)
            {
                for (int x = 0; x < field.GetLength(0); x++)
                {
                    var symbol = field[x, y] ? '#' : ' ';
                    Console.Write(symbol);
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            var field = new bool[20, 20];
            var rand = new Random();
            for (var i=0;i<field.GetLength(0);i++)
            {
                for (var j = 0; j < field.GetLength(1); j++)
                {
                    var num = rand.Next(10);
                    if (num == 1 ) field[i, j] = true;
                    else field[i, j] = false;

                }
            }

            while (true)
            {
                Paint(field);
                Thread.Sleep(500);
                field = Game.NextStep(field);
                var order = new int[3];
                var bestorder = new int[3];
                bestorder = order.ToArray();
            }
        }
    }
}
