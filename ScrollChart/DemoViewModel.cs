using GalaSoft.MvvmLight;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Linq;
using System.Windows.Media;
using System.Windows.Threading;

namespace ScrollChart
{
    class DemoViewModel : ViewModelBase
    {
        private double _from;
        private double _to;

        public SeriesCollection Series { get; private set; }
        public SeriesCollection ScrollerSeries { get; private set; }

        public double From
        {
            get { return _from;  }
            set
            {
                _from = value;
                RaisePropertyChanged(nameof(From));
            }
        }

        public double To
        {
            get { return _to; }
            set
            {
                _to = value;
                RaisePropertyChanged(nameof(To));
            }
        }

        public DemoViewModel()
        {
            Series = new SeriesCollection()
            {
                new LineSeries() { Title = "cos(x)", Values = new ChartValues<double>() }
            };
            ScrollerSeries = new SeriesCollection() // "shadow" series for the scrollable graph
            {
                new LineSeries() { Values = Series.First().Values, Stroke = Brushes.DarkGray, Fill = Brushes.Transparent, PointGeometry = null }
            };

            From = 0; To = 1;

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
