using System.Collections.Generic;

namespace yield
{
    public class Averager
    {
        DataPoint elem;
        Queue<double> queue;
        int windowWidth;
        double sum;
        public Averager(DataPoint elem, int windowWidth)
        {
            this.windowWidth = windowWidth;
            this.elem = elem;
            queue = new Queue<double>();
        }

        public double Measure()
        {
            var value = elem.OriginalY;
            queue.Enqueue(value);
            sum += value;
            if (queue.Count > windowWidth)
            {
                sum -= queue.Dequeue();
            }
            return sum / queue.Count;
        }
    }
    public static class MovingAverageTask
	{
        
        
        public static IEnumerable<DataPoint> MovingAverage(this IEnumerable<DataPoint> data, int windowWidth)
		{
            var queue = new Queue<double>();
            var sum = 0.0;
            foreach (var elem in data)
            {
                queue.Enqueue(elem.OriginalY);
                sum += elem.OriginalY;
                if (queue.Count > windowWidth)
                {
                    sum -= queue.Dequeue();
                }
                
                elem.AvgSmoothedY = sum / queue.Count;
                yield return elem;
            }
		}
	}
}