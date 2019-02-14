// Вставьте сюда финальное содержимое файла SegmentExtensions.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryTasks;
using System.Drawing;

namespace GeometryPainting
{
    public static class SegmentExtention
    {
        public static Dictionary<Segment, Color> Colors = new Dictionary<Segment, Color>();
        //словарь с цветами по сегментам
        public static void SetColor(this Segment segment, Color color)
        {
            if (!Colors.ContainsKey(segment)) Colors[segment] = color;
            //если у этого сегмента нет заданного цвета, то добавляем в словарь пару сегмент-цвет
            Colors[segment] = color;
            //если в дальнейшем цвет сегмента нужно будет изменить, то меняем
        }

        public static Color GetColor(this Segment segment)
        {
            if (!Colors.ContainsKey(segment)) Colors[segment] = Color.Black;
            //если данному сегменту не был установлен цвет в методе SetColor, 
            //то красим его в цвет по умолчанию
            return Colors[segment];//возвращаем цвет
        }
    }
}
