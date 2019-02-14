using System;

namespace GravityBalls
{
	public class WorldModel
	{
		public double BallX;
		public double BallY;
		public double BallRadius;
		public double WorldWidth;
		public double WorldHeight;

        const double G = 9.81;
        private double speedY = 100;

        public void SimulateTimeframe(double dt)
        {
            speedY += G * dt;
            BallY = Math.Min(BallY + speedY, WorldHeight - BallRadius);
            if (BallY + BallRadius == WorldHeight)
            {
                speedY = 0;
            }
        }
	}
}