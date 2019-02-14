// Вставьте сюда финальное содержимое файла GhostsTask.cs
using System;
using System.Text;

namespace hashes
{
    public class GhostsTask :
        IFactory<Document>, IFactory<Vector>, IFactory<Segment>, IFactory<Cat>, IFactory<Robot>,
        IMagic
    {
        public void DoMagic()
        {
            //уязвимость вектора в методе Add, через который мы можем
            //менять данный вектор, а не получая какой-то новый
            vector = vector.Add(new Vector(1, 1));
            //так как сегмент состоит из векторов, 
            //то и уязвимость он получает от векторов
            segment.Start.Add(new Vector(1, 1));
            //уязвимость кота в методе Rename, который он наследует от Animal
            //мы получаем доступ к одному из полей кота извне через этот метод
            cat.Rename("Roach");
            //уязвимость робота в том, что его поле BatteryCapacity
            //является публичным и изменяемым
            Robot.BatteryCapacity++;
            //уязвимость документа в том, что мы можем менять массив, 
            //который передали в документ при создании документа
            content[0] = 0;
        }
        //создаем элементы, которые в будущем будут возвращены методом Create
        Vector vector = new Vector((double)10, (double)10);
        Segment segment = new Segment(new Vector(10, 10), new Vector(10, 10));
        Cat cat = new Cat("Cat", "idk", new DateTime());
        Robot robot = new Robot("Robot");
        byte[] content = { 1, 1, 2 };
        Document document;

        Vector IFactory<Vector>.Create()
        {
            return vector;
        }

        Segment IFactory<Segment>.Create()
        {
            return segment;
        }

        Cat IFactory<Cat>.Create()
        {
            return cat;
        }

        Robot IFactory<Robot>.Create()
        {
            return robot;
        }

        Document IFactory<Document>.Create()
        {
            //инициализируем документ
            //важно, чтобы в качестве массива content передавался массив
            //к которому мы будем иметь доступ в дальнейшем
            document = new Document("Document", Encoding.Unicode, content);
            return document;
        }
    }
}
