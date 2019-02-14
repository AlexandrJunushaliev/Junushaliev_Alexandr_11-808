namespace Mazes
{
	public static class PyramidMazeTask
	{
		public static void MoveOut(Robot robot, int width, int height)
		{
            var k = 0;
            while (!robot.Finished)
            {
                for (var i = k; i < width - 3; i++)
                {
                    robot.MoveTo(Direction.Right);
                }
                k = k + 2;
                robot.MoveTo(Direction.Up);
                robot.MoveTo(Direction.Up);
                for (var i = k; i < width - 3; i++)
                {
                    robot.MoveTo(Direction.Left);
                }
                k = k + 2;
                if(!robot.Finished)
                {
                    robot.MoveTo(Direction.Up);
                    robot.MoveTo(Direction.Up);
                }
            }  
		}
	}
}