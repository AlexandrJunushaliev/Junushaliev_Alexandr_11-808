// �������� ���� ��������� ���������� ����� PathFinderTask.cs
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
            //���� ����������� �����-�� ������������ 
            //� ����� �� ����� �����, �� �� �������� ����������� �������� ����
            //�� �������� ���� ���� ������������ � ��������� � ������ 
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
                    permutation[position] = i;//�������� ������������
                                              //����� ��������� �� ������, �� ������� 
                                              //���� �� ���� ����� �� �������� ���������� ��� ��������� ������������
                                              //�� �� ��������� ��� ������������ 
                                              //��������, ���� ���������� ���� �� ������ ������ 0123, � ������������ 02..
                                              //��� �� ���� ����� ��������� ��� ����� ��������, �� ����������
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


