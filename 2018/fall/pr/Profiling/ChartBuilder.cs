using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ZedGraph;

namespace Profiling
{
    struct ChartData
    {
        public double[] ClassValues;
        public double[] StructValues;
        public double[] XValues;
        public string[] XLabels;

        public ChartData(List<ExperimentResult> results)
        {
            ClassValues = new double[results.Count];
            StructValues = new double[results.Count];
            XValues = new double[results.Count];
            XLabels = new string[results.Count];

            //перебираем список результатов, вытаскиваем значения для классов и структур, их подписи
            for (int i = 0; i < results.Count; i++)
            {
                ClassValues[i] = results[i].ClassResult;
                StructValues[i] = results[i].StructResult;
                XValues[i] = i;
                XLabels[i] = results[i].Size.ToString();
            }
        }
    }

    class ChartBuilder : IChartBuilder
    {
        public Control Build(List<ExperimentResult> results)
        {
            ZedGraphControl control = new ZedGraphControl();
            GraphPane pane = new GraphPane();

            ChartData chartData = new ChartData(results);
            //Создаем столбцы для структур и классов, структуры и классы одного размера объединяются в кластер
            //благодаря тому, что у них совпадают значения по x
            pane.XAxis.Type = AxisType.Text;
            pane.XAxis.Scale.TextLabels = chartData.XLabels;
            pane.BarSettings.MinBarGap = 0.0f;
            pane.AddBar("class", chartData.XValues, chartData.ClassValues, Color.Blue);
            pane.AddBar("struct", chartData.XValues, chartData.StructValues, Color.Red);

            control.GraphPane = pane;
            control.AxisChange();
            control.Invalidate();
            return control;
        }
    }
}