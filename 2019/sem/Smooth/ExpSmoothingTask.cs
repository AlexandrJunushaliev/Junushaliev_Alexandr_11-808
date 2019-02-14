using System.Collections.Generic;

namespace yield
{
	public static class ExpSmoothingTask
	{
		public static IEnumerable<DataPoint> SmoothExponentialy(this IEnumerable<DataPoint> data, double alpha)
		{
            var i = 0;
            double previous=0.0;
            foreach (var elem in data)
            {
                
                if (i==0)
                {

                    previous = elem.OriginalY;
                    i++;
                    elem.ExpSmoothedY = elem.OriginalY;
                    yield return elem;

                }
                else
                {
                    elem.ExpSmoothedY = previous + alpha * (elem.OriginalY - previous);
                    previous = elem.ExpSmoothedY;
                    i++;
                    yield return elem;
                }

            }
		}
	}
}