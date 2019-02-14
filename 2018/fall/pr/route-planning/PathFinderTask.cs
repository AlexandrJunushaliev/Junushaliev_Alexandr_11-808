// Вставьте сюда финальное содержимое файла PathFinderTask.cs
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace RoutePlanning
{
    public static class PathFinderTask
    {
        public static int[] FindBestCheckpointsOrder(Point[] checkpoints)
        {
            var result = new List<int[]>();
            double minValue = int.MaxValue;
            MakePermutations(new int[checkpoints.Length],
                             1,
                             result,
                             checkpoints,
                             minValue);
            return result[result.Count - 1];
        }

        static double MakePermutations(int[] permutation,
                                     int position,
                                     List<int[]> result,
                                     Point[] checkpoints,
                                     double minValue)
        {
            //если закончилась какая-то перестановка 
            //и дошла до этого этапа, то мы заменяем минимальное значение пути
            //на значение пути этой перестановки и добавляем в список 
            if (position == permutation.Length)
            {
                
                result.Add(permutation.ToArray());
                return PointExtensions.GetPathLength(checkpoints, permutation);
            }
            else
            {
                for (int i = 1; i < permutation.Length; i++)
                {
                    var index = Array.IndexOf(permutation, i, 0, position);
                    if (index != -1)
                    {
                        continue;
                    }
                    permutation[position] = i;//получаем перестановку
                                              //берем подмассив от начала, до позиции 
                                              //если на этом этапе мы получаем превышение или равенство минимальному
                                              //то мы пропускем эту перестановку 
                                              //например, если наименьший путь на данный момент 0123, а перестановка 02..
                                              //уже на этом этапе превышает или равен минимуму, то пропускаем
                    if (PointExtensions.GetPathLength(checkpoints,
                                                      permutation.Take(position + 1).ToArray()) >= minValue)
                    {
                        continue;
                    }
                    minValue = MakePermutations(permutation, position + 1, result, checkpoints, minValue);
                }
                return minValue;
            }
        }
    }
}


