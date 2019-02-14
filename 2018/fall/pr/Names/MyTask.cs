using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Names
{
    public class MyTask
    {
        public static int DaysOfZodiacFromStartOfTheYear(string data)
        {
            int daysInMonthes = 0;
            int month = int.Parse(data[3].ToString() + data[4].ToString());
            //Расчет количества дней, которое прошло от начала года начала данного месяца, если прошел хотя бы 1 месяц
            for (int j = 1; j <= month - 1; j++)
            {
                if (j == 2) daysInMonthes = daysInMonthes + 27;//если месяц февраль, то +27 дней
                else
                if ((j % 2 == 1) || (j == 8)) daysInMonthes = daysInMonthes + 31;//если месяц нечетный или август, то +31 день
                else daysInMonthes = daysInMonthes + 30; //иначе +30
            }
            int days = int.Parse(data[0].ToString() + data[1].ToString());
            if (days == 28 && month == 2) days = 27;//Если дата 28 февраля, то считаем ее как 27, так как это не является важным из-за того, что нет периодов знаков зодиака, как-либо меняющихся от високосныъ лет, нет
            return daysInMonthes + days;
        }

        public static HistogramData GetZodiaсRatingByData(NameData[] names)
        {
            //ввод знаков зодиака для оси Х
            string[] x = new string[]{
                "Aries♈",
                "Taurus♉",
                "Gemini♊",
                "Cancer♋",
                "Leo♌",
                "Virgo♍",
                "Libra♎",
                "Scorpio♏",
                "Sagittarius♐",
                "Capricorn♑",
                "Aquarius♒",
                "Pisces♓"
            };

            //Массив дат окончаний каждого из периодов знаков зодиака
            string[] datasOfEndingOfZodiac = new string[] { "20.04", "21.05", "21.06", "22.07", "21.08", "23.09", "23.10", "22.11", "22.12", "20.01", "19.02", "20.03" };
            //Лист с количествами дней, прошедших с начала года до дат окончаний 
            List<int> zodiac = new List<int>();
            for (int i = 0; i < 12; i++)
            {
                zodiac.Add(DaysOfZodiacFromStartOfTheYear(datasOfEndingOfZodiac[i]));
            }
            //Отсортированный в порядке возрастания лист zodiac
            List<int> sortedList = zodiac;
            sortedList.Sort();

            double[] y = new double[12];

            //проходка от 1 до последней строки
            for (int i = 0; i < names.Length; i++)
            {
                //выделение из строки даты
                string[] data = names[i].ToString().Split(' ');
                string dayAndMonth = "";
                for (int j = 0; j < 5; j++)
                {
                    dayAndMonth = dayAndMonth + data[0][j].ToString();
                }
                //получение кол-ва дней от начала года до дня рождения
                int daysFromStartOfTheYear = DaysOfZodiacFromStartOfTheYear(dayAndMonth);
                //день окончания периода знака зодиака человека
                int needEndByDateOfBorn = 20;
                //Сравнивается кол-во дней от начала года до конца одного периода, до конца следующего и до дня рождения человека
                //Если кол-во дней до дня рождения находится между кол-вами дней до окончаний одного и следующих периодов,
                //То этот человек рожден в следующем знаке зодиака
                if (daysFromStartOfTheYear < 357)
                    for (int j = 0; j < 11; j++)
                    {
                        if (sortedList[j] < daysFromStartOfTheYear && daysFromStartOfTheYear <= sortedList[j + 1]) needEndByDateOfBorn = sortedList[j + 1];
                    }
                //Восстановления соответствия с правильным порядком и увеличение числа людей с данным знаком
                for (int j = 0; j < 12; j++)
                    if (needEndByDateOfBorn == zodiac[j]) y[j]++;
            }
            return new HistogramData(string.Format("Распределение людей по знакам зодиака"), x, y);
        }
    }
}