namespace Mazes
{
    public static class EmptyMazeTask
    {
        public static void MoveOut(Robot robot, int width, int height)
        {
            Move(robot, width - 3,Direction.Right);//смещение из крайней левой верхней точки в крайнюю верхнюю правую 
            Move(robot, height - 3, Direction.Down);//смещение из крайней правой верхней точки в крайнюю нижнюю правую 
        }
        public static void Move(Robot robot, int a, Direction direction) //метод, отвечающий за смещение робота
        {
            if (!robot.Finished) for (var i = 0; i < a; i++) robot.MoveTo(direction); //смещение на переданное кол-во клеток в заданном направлении, если робот не закончил выполнение своей задачи
        }
    }
}