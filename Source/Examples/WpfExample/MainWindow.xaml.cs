using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace WpfExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {


        public MainWindow()
        {
            InitializeComponent();

        }

        private void element_MouseEnter(object sender, MouseEventArgs e)
        {
            ((Button)sender).Background =
              new SolidColorBrush(Colors.LightGoldenrodYellow);
        }

        private void element_MouseLeave(object sender, MouseEventArgs e)
        {
            ((Button)sender).Background = null;
        }

        private void btnShowChartControlDemo_Click(object sender, RoutedEventArgs e)
        {
            new HGChartControlDemo().ShowDialog();
        }

        private void btnShowSortDemo_Click(object sender, RoutedEventArgs e)
        {
            new VisualSortingDemo().ShowDialog();
        }

        private void btnShowGraph_Click(object sender, RoutedEventArgs e)
        {
            new GraphDemo().ShowDialog();
        }





    }
}
