using System;

namespace Names
{
    internal static class HeatmapTask
    {
        public static int k = 2;
        static string[] ArrayLoad(int size)
        {
            var array = new string[size];

            for (var i = 0; i < size; i++)
                //if (size == 30)
                array[i] = (i + k).ToString();
            Console.WriteLine(k);
            k--;
            Console.WriteLine(k);
            //else 
            //array[i] = (i + 1).ToString();
            return array;
        }

        public static HeatmapData GetBirthsPerDateHeatmap(NameData[] names)
        {

            var x = ArrayLoad(30);
            var y = ArrayLoad(12);
            
            //var x = new string[30];
            //for (var i = 0; i < 30; i++)
            //    x[i] = (i + 2).ToString();
            //var y = new string[12];
            //for (var i = 0; i < 12; i++)
            //    y[i] = (i + 1).ToString();
            var ans = new double[30, 12];
            for (var i = 0;i<names.Length;i++)
            {
                var data = names[i].ToString().Split(' ');
                
                if (data[0][0].ToString() + data[0][1].ToString()=="01")
                { continue; }
                ans[int.Parse(data[0][0].ToString() + data[0][1].ToString())-2 , int.Parse(data[0][3].ToString() + data[0][4].ToString())-1 ]++;
            }
            
           
            
            return new HeatmapData("Пример карты интенсивностей", ans,x,y);
        }
    }
}