using System.Collections.Generic;
namespace Recognizer
{
    public static class ThresholdFilterTask
    {
        public static double[,] ThresholdFilter(double[,] original, double whitePixelsFraction)
        {
            var numberOfWhitePixels = (int)(whitePixelsFraction * original.Length);
            var list = new List<double>();
            for (var i = 0; i < original.GetLength(0); i++)
            {
                for (var j = 0; j < original.GetLength(1); j++)
                {
                    list.Add(original[i, j]);
                }
            }
            list.Sort();
            var t = 0.0;
            if (numberOfWhitePixels < 1)
                t = int.MaxValue;
            else t = list[list.Count - 1 - numberOfWhitePixels];
            
            for (var i = 0; i < original.GetLength(0); i++)
            {
                for (var j = 0; j < original.GetLength(1); j++)
                {
                    if (original[i, j] < t)
                        original[i, j] = 0.0;
                    else original[i, j] = 1.0;
                }
            }
            return original;



        }
    }
}