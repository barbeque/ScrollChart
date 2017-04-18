using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace ScrollChart
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CartesianChart_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // See everything
            _scrollchart.ScrollHorizontalFrom = 0;
            _scrollchart.ScrollHorizontalTo = _scrollchart.Series.First().Values.Count;
        }
    }
}
