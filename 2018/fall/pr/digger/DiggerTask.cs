using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digger
{
    public class Terrain : ICreature
    {
        public string GetImageFileName()
        {
            return "Terrain.png";//название файла .png
        }

        public int GetDrawingPriority()
        {
            return 5; //низкий приоритет отрисовки
        }

        public CreatureCommand Act(int x, int y)
        {
            return new CreatureCommand();//возвращаем пустую команду
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            return true;//при конфликте земля исчезает
        }
    }

    public class Player : ICreature
    {
        public CreatureCommand Act(int x, int y)
        {//условие для каждой клавиши с невозможностью выхода за границу и отсутствия в стороне движения мешка
            if (Game.KeyPressed == Keys.Left && x > 0)
            {
                if (Game.Map.GetValue(x - 1, y) == null || Game.Map[x - 1, y].ToString() != "Digger.Sack")
                    return new CreatureCommand { DeltaX = -1 };
            }

            if (Game.KeyPressed == Keys.Right && x < Game.MapWidth - 1)
            {
                if (Game.Map.GetValue(x + 1, y) == null || Game.Map[x + 1, y].ToString() != "Digger.Sack")
                    return new CreatureCommand { DeltaX = 1 };
            }

            if (Game.KeyPressed == Keys.Up && y > 0)
            {
                if (Game.Map.GetValue(x, y - 1) == null || Game.Map[x, y - 1].ToString() != "Digger.Sack")
                    return new CreatureCommand { DeltaY = -1 };
            }

            if (Game.KeyPressed == Keys.Down && y < Game.MapHeight - 1)
            {
                if (Game.Map.GetValue(x, y + 1) == null || Game.Map[x, y + 1].ToString() != "Digger.Sack")
                    return new CreatureCommand { DeltaY = 1 };
            }
            return new CreatureCommand();//если движется в сторону границы или мешка, то ничего не происходит
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            if (conflictedObject.ToString() == "Digger.Monster" || conflictedObject.ToString() == "Digger.Sack")
                return true;
            return false;//в конфликте с мешком игрок исчезает


        }

        public int GetDrawingPriority()
        {
            return 1;//высокий приоритет отрисовки
        }

        public string GetImageFileName()
        {
            return "Digger.png";//название файла .png
        }
    }

    public class Sack : ICreature
    {
        public int CountStepFall;//переменная, считающая, сколько клеток пролетел мешок
        public CreatureCommand Act(int x, int y)
        {
            if (CountStepFall > 1)//если пролетел больше одной клетки, то может превратиться в золото
            {
                if (y == Game.MapHeight - 1) return new CreatureCommand { TransformTo = new Gold() };
                if (Game.Map.GetValue(x, y + 1) != null)//если падает на золото, мешок или землю
                {
                    if (Game.Map[x, y + 1].ToString() == "Digger.Gold" ||
                    Game.Map[x, y + 1].ToString() == "Digger.Sack" ||
                    Game.Map[x, y + 1].ToString() == "Digger.Terrain"
                    )
                        return new CreatureCommand { TransformTo = new Gold() };//или на границу
                }
            }
            if (y + 1 < Game.MapHeight)//если не граница
            {
                if (Game.Map.GetValue(x, y + 1) == null)//и клетка пустая, то падает
                {
                    CountStepFall++;
                    return new CreatureCommand { DeltaY = 1 };
                }//иначе, если под мешком игрок или монстр, то входит с ним в одну клетку
                else if ((Game.Map.GetValue(x, y + 1).ToString() == "Digger.Player" || Game.Map.GetValue(x, y + 1).ToString() == "Digger.Monster") && CountStepFall != 0)
                {
                    CountStepFall++;
                    return new CreatureCommand { DeltaY = 1 };
                }
            }
            CountStepFall = 0;//обнуляет количество пройденных шагов, если пролетел <=1 клетке или не встретил игрока
            return new CreatureCommand();
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            return false;//в конфликте не умирает
        }

        public int GetDrawingPriority()
        {
            return 3;
        }

        public string GetImageFileName()
        {
            return "Sack.png";//изображение в формате .png
        }
    }

    public class Gold : ICreature
    {
        public CreatureCommand Act(int x, int y)
        {
            return new CreatureCommand();//золото ничего не делает
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            if (conflictedObject.ToString() == "Digger.Player")//при конфликте c игроком добавляет очки и исчезает
            {
                Game.Scores += 10;
                return true;
            }
            if (conflictedObject.ToString() == "Digger.Monster")
            {
                return true;//при конфликте c монстром исчезает
            }
            return false;
        }

        public int GetDrawingPriority()
        {
            return 2;
        }

        public string GetImageFileName()
        {
            return "Gold.png";//изображение в формате .png
        }
    }

    public class Monster : ICreature
    {
        public static int[] FindPlayer()
        {//метод поиска координат игрока
            for (int i = 0; i < Game.MapWidth; i++)
                for (int j = 0; j < Game.MapHeight; j++)
                    if (Game.Map[i, j] != null && Game.Map[i, j].ToString() == "Digger.Player")
                        return new[] { i, j };
            return null;//если не найден, то null
        }

        public static bool CanMove(int x, int y, int x1, int y1)
        {//определяет, сможет ли монстр сдвинуться в новую координату
            //может, если там пустота, золото или игрок
            return Game.Map.GetValue(x + x1, y + y1) == null ||
            Game.Map[x + x1, y + y1].ToString() == "Digger.Gold" ||
            Game.Map[x + x1, y + y1].ToString() == "Digger.Player";
        }

        public static int Delta(int monsterCords, int playerCords)
        {
            //получает отличия в соответствующей координате игрока и монстра => и направление, в котором должен двигаться монстр 
            if (monsterCords > playerCords) return -1;
            if (monsterCords < playerCords) return 1;
            return 0;
        }
        
        public CreatureCommand Act(int x, int y)
        {
            var playerCordinates = FindPlayer();//координаты игрока
            if (playerCordinates == null) return new CreatureCommand();//если игрока нет, то монстр стоит
            if (CanMove(x, y, Delta(x, playerCordinates[0]), 0))//если может двигаться по х в направлении игрока, то смещается по х
                return new CreatureCommand { DeltaX = Delta(x, playerCordinates[0]) };
            if (CanMove(x, y, 0, Delta(y, playerCordinates[1])))//если может двигаться по у, но не по х, в направлении игрока, то смещается по у
                return new CreatureCommand { DeltaY = Delta(y, playerCordinates[1]) };
            return new CreatureCommand();//если не может двигаться, то стоит
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            if (conflictedObject.ToString() == "Digger.Monster" || conflictedObject.ToString() == "Digger.Sack")// при конфликте с другим монстром или мешком исчезает
            {
                return true;
            }
            return false;
        }

        public int GetDrawingPriority()
        {
            return 0;
        }

        public string GetImageFileName()
        {
            return "Monster.png"; //изображение в формате .png
        }
    }

}