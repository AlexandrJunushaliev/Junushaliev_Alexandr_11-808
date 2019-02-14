using System;

namespace Recognizer
{
    internal static class SobelFilterTask
    {
        public static double GetSobel(double[,] nearX,double[,] sx)
        {
            var sumX = 0.0;
            var sumY = 0.0;
            var count = sx.GetLength(0);
            for (var i = 0; i < count; i++)
            {
                for (var j = 0; j < count; j++)
                {
                    sumX += sx[i,j]*nearX[i,j];
                    sumY += sx[j, i] * nearX[i, j];
                }
            }
            return Math.Sqrt(sumX * sumX + sumY * sumY);
        }
        public static double[,] SobelFilter(double[,] g, double[,] sx)
        {
            var width = g.GetLength(0);
            var height = g.GetLength(1);
            var count = sx.GetLength(0);
            var nearX = new double[count, count];
            var result = new double[width, height];
            for (var i = count/2; i < width-count / 2; i++)
            {
                for (var j = count / 2; j < height-count / 2; j++)
                {
                    for (var i1=0;i1<count;i1++)
                    {
                        for (var j1=0;j1<count;j1++)
                        {
                            nearX[i1, j1] = g[i - count / 2 + i1, j - count / 2 + j1];
                        }
                    }
                    result[i, j] = GetSobel(nearX, sx);
                }
            }
            var h = new int[5];
            Array.IndexOf()
            return result;
        }
    }
}