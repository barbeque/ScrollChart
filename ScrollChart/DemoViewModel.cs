using GalaSoft.MvvmLight;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Linq;
using System.Windows.Threading;

namespace ScrollChart
{
    class DemoViewModel : ViewModelBase
    {
        public SeriesCollection Series { get; private set; }

        public DemoViewModel()
        {
            Series = new SeriesCollection()
            {
                new LineSeries() { Title = "Age", Values = new ChartValues<double>() }
            };

            var timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            var lineSeries = Series.First();
            var values = lineSeries.Values as ChartValues<double>;
            values.Add(Math.Cos(Environment.TickCount / 1000.0));
        }
    }
}
