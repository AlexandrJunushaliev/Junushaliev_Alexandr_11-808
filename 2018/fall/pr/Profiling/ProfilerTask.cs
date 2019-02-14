// Вставьте сюда финальное содержимое файла ProfilerTask.cs
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Profiling
{
    public class ProfilerTask : IProfiler
    {
        public Stopwatch HeatAndRun(IRunner runner, Stopwatch timer,bool isClass, int size, int repetitionsCount)
        {
            runner.Call(isClass, size, 1);//прогрев для класса
            timer.Start();
            runner.Call(isClass, size, repetitionsCount);//подсчет для класса
            timer.Stop();
            return timer;
        }
        public List<ExperimentResult> Measure(IRunner runner, int repetitionsCount)
        {
            var result = new List<ExperimentResult>();
            var timeOfClass = new Stopwatch();
            var timeOfStruct = new Stopwatch();
            foreach (var size in Constants.FieldCounts)
            {
                timeOfClass = HeatAndRun(runner, new Stopwatch(), true, size, repetitionsCount);


                timeOfStruct = HeatAndRun(runner, new Stopwatch(), true, size, repetitionsCount);
                result.Add(new ExperimentResult(size,
                (double)timeOfClass.ElapsedMilliseconds / repetitionsCount,
                (double)timeOfStruct.ElapsedMilliseconds / repetitionsCount));
            }
            return result;
        }
    }
}