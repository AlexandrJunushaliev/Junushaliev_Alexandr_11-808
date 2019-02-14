using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOf15
{
    public partial class GameOf15 : Form
    {
        private Dictionary<int, int[,]> ButtonPositions = new Dictionary<int, int[,]>();
        private int countSteps=0;
        private Timer timer1;
        private DateTime dateTime;
        private Dictionary<int, int[,]> reRoll()//метод расставляющий пятнашки
        {
            var buttonsLocations = Filler();//заполнение словаря с позициями кнопок
            buttonsLocations = MixPos(buttonsLocations);//получение случайной перестановки
            button1.Location = new System.Drawing.Point(buttonsLocations[1][0, 0], buttonsLocations[1][0, 1]);
            button2.Location = new System.Drawing.Point(buttonsLocations[2][0, 0], buttonsLocations[2][0, 1]);
            button3.Location = new System.Drawing.Point(buttonsLocations[3][0, 0], buttonsLocations[3][0, 1]);
            button4.Location = new System.Drawing.Point(buttonsLocations[4][0, 0], buttonsLocations[4][0, 1]);
            button5.Location = new System.Drawing.Point(buttonsLocations[5][0, 0], buttonsLocations[5][0, 1]);
            button6.Location = new System.Drawing.Point(buttonsLocations[6][0, 0], buttonsLocations[6][0, 1]);
            button7.Location = new System.Drawing.Point(buttonsLocations[7][0, 0], buttonsLocations[7][0, 1]);
            button8.Location = new System.Drawing.Point(buttonsLocations[8][0, 0], buttonsLocations[8][0, 1]);
            button9.Location = new System.Drawing.Point(buttonsLocations[9][0, 0], buttonsLocations[9][0, 1]);
            button10.Location = new System.Drawing.Point(buttonsLocations[10][0, 0], buttonsLocations[10][0, 1]);
            button11.Location = new System.Drawing.Point(buttonsLocations[11][0, 0], buttonsLocations[11][0, 1]);
            button12.Location = new System.Drawing.Point(buttonsLocations[12][0, 0], buttonsLocations[12][0, 1]);
            button13.Location = new System.Drawing.Point(buttonsLocations[13][0, 0], buttonsLocations[13][0, 1]);
            button14.Location = new System.Drawing.Point(buttonsLocations[14][0, 0], buttonsLocations[14][0, 1]);
            button15.Location = new System.Drawing.Point(buttonsLocations[15][0, 0], buttonsLocations[15][0, 1]);
            button16.Location = new System.Drawing.Point(buttonsLocations[16][0, 0], buttonsLocations[16][0, 1]);
            return buttonsLocations;
        }
        private static Dictionary<int, int[,]> Filler()
        {
            Dictionary<int, int[,]> ArrayOfLocations = new Dictionary<int, int[,]>();
            var k = 1;
            for (var i = 0; i < 148; i += 49)
            {
                for (var j = 0; j < 148; j += 49)
                {
                    if (!ArrayOfLocations.ContainsKey(k)) ArrayOfLocations.Add(k, new int[,] { { i, j } });
                    else ArrayOfLocations[k] = new int[,] { { i, j } };
                    k++;
                }
            }
            return ArrayOfLocations;
        }
        private static Dictionary<int, int[,]> MixPos(Dictionary<int, int[,]> buttonsLocations)
        {
            var solved = false;
            var mixLocations = new Dictionary<int, int[,]>(buttonsLocations);
            while (!solved)
            {

                var usedKeys = new int[16];
                var rand = new Random();
                foreach (var location in buttonsLocations.Keys)
                {
                    bool exit = true;
                    var key = 0;
                    while (exit)
                    {
                        bool repeat = false;
                        key = rand.Next(1, 17);
                        for (var i = 0; i < 16; i++)
                        {
                            if (usedKeys[i] == key) repeat = true;
                        }
                        if (repeat == false)
                        {
                            usedKeys[location - 1] = key;
                            mixLocations[key] = buttonsLocations[location];
                            exit = false;
                        }
                    }
                }

                var linedKeysArray = new int[16];
                var k = 0;
                for (var i = 0; i < 4; i++)
                {
                    for (var j = 0; j < 16; j += 4)
                    {
                        linedKeysArray[k] = usedKeys[j + i];
                        k++;
                    }
                }
                solved = IsSolved(linedKeysArray);
            }



            return mixLocations;
        }
        private static bool IsSolved(int[] linedkeysArray)
        {
            var nIArray = new int[16];
            var summ = 0;
            var numberOfLineOfEmpty = -1;
            for (var i = 0; i < 16; i++)
            {
                if (linedkeysArray[i] == 16)
                {
                    numberOfLineOfEmpty = i / 4 + 1;
                    continue;
                }
                for (var j = i + 1; j < 16; j++)
                {
                    if (linedkeysArray[j] == 16) { continue; }
                    if (linedkeysArray[i] > linedkeysArray[j])
                        nIArray[i]++;
                }
            }
            foreach (var e in nIArray)
            {
                summ += e;
            }
            return (summ + numberOfLineOfEmpty) % 2 == 1 ? false : true;
        }
        public GameOf15()
        {
            
            MessageBox.Show(this, "После нажатия кнопки ОК игра начнется и включится секундомер.",
                                   "Предупреждение.", MessageBoxButtons.OK,
                                   MessageBoxIcon.Warning,
                                   MessageBoxDefaultButton.Button1);
            InitializeComponent();         
            ButtonPositions = reRoll();//перемешиваем
            label2.Text="Time:";
            label4.Text = "Steps:";
            label3.Text = "0";
            timer1 = new Timer();
            dateTime = DateTime.Now;
            timer1.Enabled = true;//запуск таймера
            timer1.Interval = 20;//20 мс между тиками
            timer1.Tick += new EventHandler(Time); //подсчет на каждый тик     
        }
        private void Time(object sender, EventArgs e)//подсчет прошедшего с начала времени
        {
            var totalTime = (DateTime.Now - dateTime).TotalSeconds;
            label1.Text = $"{(int)totalTime/60}:{(totalTime%60):0.###}";
        }
        private void EndChecker()//Метод, проверяющий, собраны ли пятнашки
        {
            var end = true;
            foreach (var button in ButtonPositions.Keys)
            {
                var x = ButtonPositions[button][0, 0];
                var y = ButtonPositions[button][0, 1];
                if ((x!= 49 * ((button - 1) % 4)) || (y!= ((button - 1) / 4) * 49))//проверяет, что все кнопки на своих местах
                {
                    end = false;
                    break;
                }
            }
            if (end)//если все на местах, то пятнашки собраны
            {
                DialogResult dialogResult = MessageBox.Show("Сыграем ещё?", "Поздравляю!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    ButtonPositions = reRoll();
                    dateTime = DateTime.Now;
                    countSteps = 0;
                    label3.Text = "0";
                }
                else if (dialogResult == DialogResult.No)
                {
                    Application.Exit();
                }
            }
        }
        private void IncreaseSteps()//увеличвает счетчик шагов
        {
            countSteps++;
            label3.Text = countSteps.ToString();
        }
        //Аналогично для всех нажатий на кнопки
        private void button1_Click(object sender, EventArgs e)
        {   //если находятся на одной вертикали или горизонтали и стоят по соседству пустая клетка и кнопка, на которую нажимаем
            if (Math.Abs(button1.Location.X - button16.Location.X) == 0 && Math.Abs(button1.Location.Y - button16.Location.Y) == 49 || Math.Abs(button1.Location.X - button16.Location.X) == 49 && Math.Abs(button1.Location.Y - button16.Location.Y) == 0)
            {
                var locationOfFirstButton = button1.Location;
                button1.Location = button16.Location;
                button16.Location = locationOfFirstButton;//меняем кнопки местами и изменяем позиции в словаре с позициями кнопок
                ButtonPositions[1][0, 0] = button1.Location.X;
                ButtonPositions[1][0, 1] = button1.Location.Y;
                ButtonPositions[16][0, 0] = button16.Location.X;
                ButtonPositions[16][0, 1] = button16.Location.Y;
                IncreaseSteps();
                EndChecker();//запускаем проверку на окончание
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {

            if (Math.Abs(button2.Location.X - button16.Location.X) == 0 && Math.Abs(button2.Location.Y - button16.Location.Y) == 49 || Math.Abs(button2.Location.X - button16.Location.X) == 49 && Math.Abs(button2.Location.Y - button16.Location.Y) == 0)
            {
                var locationOfFirstButton = button2.Location;
                button2.Location = button16.Location;
                button16.Location = locationOfFirstButton;
                ButtonPositions[2][0, 0] = button2.Location.X;
                ButtonPositions[2][0, 1] = button2.Location.Y;
                ButtonPositions[16][0, 0] = button16.Location.X;
                ButtonPositions[16][0, 1] = button16.Location.Y;
                IncreaseSteps();
                EndChecker();
            }

        }
        private void button3_Click(object sender, EventArgs e)
        {

            if (Math.Abs(button3.Location.X - button16.Location.X) == 0 && Math.Abs(button3.Location.Y - button16.Location.Y) == 49 || Math.Abs(button3.Location.X - button16.Location.X) == 49 && Math.Abs(button3.Location.Y - button16.Location.Y) == 0)
            {
                var locationOfFirstButton = button3.Location;
                button3.Location = button16.Location;
                button16.Location = locationOfFirstButton;
                ButtonPositions[3][0, 0] = button3.Location.X;
                ButtonPositions[3][0, 1] = button3.Location.Y;
                ButtonPositions[16][0, 0] = button16.Location.X;
                ButtonPositions[16][0, 1] = button16.Location.Y;
                IncreaseSteps();
                EndChecker();
            }

        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (Math.Abs(button4.Location.X - button16.Location.X) == 0 && Math.Abs(button4.Location.Y - button16.Location.Y) == 49 || Math.Abs(button4.Location.X - button16.Location.X) == 49 && Math.Abs(button4.Location.Y - button16.Location.Y) == 0)
            {
                var locationOfFirstButton = button4.Location;
                button4.Location = button16.Location;
                button16.Location = locationOfFirstButton;
                ButtonPositions[4][0, 0] = button4.Location.X;
                ButtonPositions[4][0, 1] = button4.Location.Y;
                ButtonPositions[16][0, 0] = button16.Location.X;
                ButtonPositions[16][0, 1] = button16.Location.Y;
                IncreaseSteps();
                EndChecker();
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {

            if (Math.Abs(button5.Location.X - button16.Location.X) == 0 && Math.Abs(button5.Location.Y - button16.Location.Y) == 49 || Math.Abs(button5.Location.X - button16.Location.X) == 49 && Math.Abs(button5.Location.Y - button16.Location.Y) == 0)
            {
                var locationOfFirstButton = button5.Location;
                button5.Location = button16.Location;
                button16.Location = locationOfFirstButton;
                ButtonPositions[5][0, 0] = button5.Location.X;
                ButtonPositions[5][0, 1] = button5.Location.Y;
                ButtonPositions[16][0, 0] = button16.Location.X;
                ButtonPositions[16][0, 1] = button16.Location.Y;
                IncreaseSteps();
                EndChecker();
            }

        }
        private void button6_Click(object sender, EventArgs e)
        {

            if (Math.Abs(button6.Location.X - button16.Location.X) == 0 && Math.Abs(button6.Location.Y - button16.Location.Y) == 49 || Math.Abs(button6.Location.X - button16.Location.X) == 49 && Math.Abs(button6.Location.Y - button16.Location.Y) == 0)
            {
                var locationOfFirstButton = button6.Location;
                button6.Location = button16.Location;
                button16.Location = locationOfFirstButton;
                ButtonPositions[6][0, 0] = button6.Location.X;
                ButtonPositions[6][0, 1] = button6.Location.Y;
                ButtonPositions[16][0, 0] = button16.Location.X;
                ButtonPositions[16][0, 1] = button16.Location.Y;
                IncreaseSteps();
                EndChecker();
            }

        }
        private void button7_Click(object sender, EventArgs e)
        {

            if (Math.Abs(button7.Location.X - button16.Location.X) == 0 && Math.Abs(button7.Location.Y - button16.Location.Y) == 49 || Math.Abs(button7.Location.X - button16.Location.X) == 49 && Math.Abs(button7.Location.Y - button16.Location.Y) == 0)
            {
                var locationOfFirstButton = button7.Location;
                button7.Location = button16.Location;
                button16.Location = locationOfFirstButton;
                ButtonPositions[7][0, 0] = button7.Location.X;
                ButtonPositions[7][0, 1] = button7.Location.Y;
                ButtonPositions[16][0, 0] = button16.Location.X;
                ButtonPositions[16][0, 1] = button16.Location.Y;
                IncreaseSteps();
                EndChecker();
            }

        }
        private void button8_Click(object sender, EventArgs e)
        {

            if (Math.Abs(button8.Location.X - button16.Location.X) == 0 && Math.Abs(button8.Location.Y - button16.Location.Y) == 49 || Math.Abs(button8.Location.X - button16.Location.X) == 49 && Math.Abs(button8.Location.Y - button16.Location.Y) == 0)
            {
                var locationOfFirstButton = button8.Location;
                button8.Location = button16.Location;
                button16.Location = locationOfFirstButton;
                ButtonPositions[8][0, 0] = button8.Location.X;
                ButtonPositions[8][0, 1] = button8.Location.Y;
                ButtonPositions[16][0, 0] = button16.Location.X;
                ButtonPositions[16][0, 1] = button16.Location.Y;
                IncreaseSteps();
                EndChecker();
            }

        }
        private void button9_Click(object sender, EventArgs e)
        {

            if (Math.Abs(button9.Location.X - button16.Location.X) == 0 && Math.Abs(button9.Location.Y - button16.Location.Y) == 49 || Math.Abs(button9.Location.X - button16.Location.X) == 49 && Math.Abs(button9.Location.Y - button16.Location.Y) == 0)
            {
                var locationOfFirstButton = button9.Location;
                button9.Location = button16.Location;
                button16.Location = locationOfFirstButton;
                ButtonPositions[9][0, 0] = button9.Location.X;
                ButtonPositions[9][0, 1] = button9.Location.Y;
                ButtonPositions[16][0, 0] = button16.Location.X;
                ButtonPositions[16][0, 1] = button16.Location.Y;
                IncreaseSteps();
                EndChecker();
            }

        }
        private void button10_Click(object sender, EventArgs e)
        {

            if (Math.Abs(button10.Location.X - button16.Location.X) == 0 && Math.Abs(button10.Location.Y - button16.Location.Y) == 49 || Math.Abs(button10.Location.X - button16.Location.X) == 49 && Math.Abs(button10.Location.Y - button16.Location.Y) == 0)
            {
                var locationOfFirstButton = button10.Location;
                button10.Location = button16.Location;
                button16.Location = locationOfFirstButton;
                ButtonPositions[10][0, 0] = button10.Location.X;
                ButtonPositions[10][0, 1] = button10.Location.Y;
                ButtonPositions[16][0, 0] = button16.Location.X;
                ButtonPositions[16][0, 1] = button16.Location.Y;
                IncreaseSteps();
                EndChecker();
            }

        }
        private void button11_Click(object sender, EventArgs e)
        {

            if (Math.Abs(button11.Location.X - button16.Location.X) == 0 && Math.Abs(button11.Location.Y - button16.Location.Y) == 49 || Math.Abs(button11.Location.X - button16.Location.X) == 49 && Math.Abs(button11.Location.Y - button16.Location.Y) == 0)
            {
                var locationOfFirstButton = button11.Location;
                button11.Location = button16.Location;
                button16.Location = locationOfFirstButton;
                ButtonPositions[11][0, 0] = button11.Location.X;
                ButtonPositions[11][0, 1] = button11.Location.Y;
                ButtonPositions[16][0, 0] = button16.Location.X;
                ButtonPositions[16][0, 1] = button16.Location.Y;
                IncreaseSteps();
                EndChecker();
            }

        }
        private void button12_Click(object sender, EventArgs e)
        {

            if (Math.Abs(button12.Location.X - button16.Location.X) == 0 && Math.Abs(button12.Location.Y - button16.Location.Y) == 49 || Math.Abs(button12.Location.X - button16.Location.X) == 49 && Math.Abs(button12.Location.Y - button16.Location.Y) == 0)
            {
                var locationOfFirstButton = button12.Location;
                button12.Location = button16.Location;
                button16.Location = locationOfFirstButton;
                ButtonPositions[12][0, 0] = button12.Location.X;
                ButtonPositions[12][0, 1] = button12.Location.Y;
                ButtonPositions[16][0, 0] = button16.Location.X;
                ButtonPositions[16][0, 1] = button16.Location.Y;
                IncreaseSteps();
                EndChecker();
            }

        }
        private void button13_Click(object sender, EventArgs e)
        {

            if (Math.Abs(button13.Location.X - button16.Location.X) == 0 && Math.Abs(button13.Location.Y - button16.Location.Y) == 49 || Math.Abs(button13.Location.X - button16.Location.X) == 49 && Math.Abs(button13.Location.Y - button16.Location.Y) == 0)
            {
                var locationOfFirstButton = button13.Location;
                button13.Location = button16.Location;
                button16.Location = locationOfFirstButton;
                ButtonPositions[13][0, 0] = button13.Location.X;
                ButtonPositions[13][0, 1] = button13.Location.Y;
                ButtonPositions[16][0, 0] = button16.Location.X;
                ButtonPositions[16][0, 1] = button16.Location.Y;
                IncreaseSteps();
                EndChecker();
            }

        }
        private void button14_Click(object sender, EventArgs e)
        {

            if (Math.Abs(button14.Location.X - button16.Location.X) == 0 && Math.Abs(button14.Location.Y - button16.Location.Y) == 49 || Math.Abs(button14.Location.X - button16.Location.X) == 49 && Math.Abs(button14.Location.Y - button16.Location.Y) == 0)
            {
                var locationOfFirstButton = button14.Location;
                button14.Location = button16.Location;
                button16.Location = locationOfFirstButton;
                ButtonPositions[14][0, 0] = button14.Location.X;
                ButtonPositions[14][0, 1] = button14.Location.Y;
                ButtonPositions[16][0, 0] = button16.Location.X;
                ButtonPositions[16][0, 1] = button16.Location.Y;
                IncreaseSteps();
                EndChecker();
            }

        }
        private void button15_Click(object sender, EventArgs e)
        {

            if (Math.Abs(button15.Location.X - button16.Location.X) == 0 && Math.Abs(button15.Location.Y - button16.Location.Y) == 49 || Math.Abs(button15.Location.X - button16.Location.X) == 49 && Math.Abs(button15.Location.Y - button16.Location.Y) == 0)
            {
                var locationOfFirstButton = button15.Location;
                button15.Location = button16.Location;
                button16.Location = locationOfFirstButton;
                ButtonPositions[15][0, 0] = button15.Location.X;
                ButtonPositions[15][0, 1] = button15.Location.Y;
                ButtonPositions[16][0, 0] = button16.Location.X;
                ButtonPositions[16][0, 1] = button16.Location.Y;
                IncreaseSteps();
                EndChecker();
            }

        }
        private void button17_Click(object sender, EventArgs e)//кнопка рестарта
        {
            ButtonPositions = reRoll();
            dateTime = DateTime.Now;
            countSteps = 0;
            label3.Text = "0";
        }
    }
}
