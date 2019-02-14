// Вставьте сюда финальное содержимое файла SnakeMazeTask.cs
namespace Mazes
{
    public static class SnakeMazeTask
    {
        //каждый раз робот смещается на width-3 влево или вправо ; каждый раз робот смещается на 2 вниз
        //Создаем цикл движения робота до тех пор, пока он не закончит выполнение задачи. 
        //Робот начинает в крайней левой верхней точке => должен двинуться на widith-3 клеток вправо. 
        //Затем должен опуститься на 2 клетки вниз и вернуться в крайнюю левую точку 
        //=> сдвинуться на widith-3 клеток влево. 
        //Если эта точка не является конечной точкой, 
        //то робот опускается на 2 клетки вниз и повторяет все предыдущие действия.
        public static void MoveRight(Robot robot, int width, Direction direction)
        {
            for (int i = 0; i < width - 3; i++) { robot.MoveTo(Direction.Right); }
        }

        public static void MoveDown(Robot robot, Direction direction)
        {
            for (int i = 0; i < 2; i++) { robot.MoveTo(Direction.Down); }
        }

        public static void MoveLeftAndDown(Robot robot, int width, Direction direction)
        {
            for (int i = 0; i < width - 3; i++) { robot.MoveTo(Direction.Left); }
            if (robot.Finished == false) MoveDown(robot, Direction.Down); //проверка на окончание задания. 
                                                                          //Если задание не закончено, то надо опуситься на 2 клетки вниз 
                                                                          //и повторить предыдущие действия
        }

        public static void MoveOut(Robot robot, int width, int height)
        {
            while (robot.Finished == false)
            {
                MoveRight(robot, width, Direction.Right); //сдвиг на widith - 3 клеток вправо
                MoveDown(robot, Direction.Down);  //сдвиг на 2 клетки вниз
                MoveLeftAndDown(robot, width, Direction.Left); //сдвиг на widith - 3 клеток вправо  
            }
        }
    }
}