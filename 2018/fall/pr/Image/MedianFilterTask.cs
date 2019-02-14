using System.Linq;
using System.Collections.Generic;

namespace Recognizer
{
    internal static class MedianFilterTask
    {
        /* 
		 * Для борьбы с пиксельным шумом, подобным тому, что на изображении,
		 * обычно применяют медианный фильтр, в котором цвет каждого пикселя, 
		 * заменяется на медиану всех цветов в некоторой окрестности пикселя.
		 * https://en.wikipedia.org/wiki/Median_filter
		 * 
		 * Используйте окно размером 3х3 для не граничных пикселей,
		 * Окно размером 2х2 для угловых и 3х2 или 2х3 для граничных.
		 */
        public static List<double> AdditionInList(int i, int j, double[,] original,int length1,int length2)
        {
            var list = new List<double>();
            list.Add(original[i, j]);
            if (j > 0) list.Add(original[i, j - 1]);
            if (j < length2 - 1) list.Add(original[i, j + 1]);
            if (i > 0)
            {
                list.Add(original[i - 1, j]);
                if (j > 0) list.Add(original[i - 1, j - 1]);
                if (j < length2 - 1) list.Add(original[i - 1, j + 1]);
            }
            if (i < length1 - 1)
            {
                list.Add(original[i + 1, j]);
                if (j > 0) list.Add(original[i + 1, j - 1]);
                if (j < length2 - 1) list.Add(original[i + 1, j + 1]);
            }
            return list;
        }
        public static double[,] MedianFilter(double[,] original)
        {
            var length1 = original.GetLength(0);
            var length2 = original.GetLength(1);
            var list = new List<double>();
            var arr = new double[length1, length2];
            for (var i = 0; i < length1; i++)
            {
                for (var j = 0; j < length2; j++)
                {
                    list = AdditionInList(i, j, original,length1,length2);
                    list.Sort();
                    if (list.Count % 2 == 0) arr[i, j] = (list[list.Count / 2 - 1] + list[list.Count / 2]) / 2;
                    else arr[i, j] = list[list.Count / 2];
                }
            }
            return arr;
        }
    }
}