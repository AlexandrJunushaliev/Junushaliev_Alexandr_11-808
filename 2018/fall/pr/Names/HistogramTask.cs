using System;
using System.Linq;

namespace Names
{
    internal static class HistogramTask
    {
        public static HistogramData GetBirthsPerDayHistogram(NameData[] names, string name)
        {
            var x = new string[31];
            for (var i=1;i<32; i++)
            {
                x[i-1] = (i).ToString();
            }

            var y = new double[31];
            


            for (var i =0; i<names.Length; i++)
            {
                var data = names[i].ToString().Split();
                if (data[4]==name)
                {
                    y[int.Parse(data[0][0].ToString() + data[0][1].ToString())-1]++;
                    
                }
                
            }
            y[0] = 0;
            
           
            return new HistogramData(string.Format("Рождаемость людей с именем '{0}'", name), x, y);
        }
    }
}