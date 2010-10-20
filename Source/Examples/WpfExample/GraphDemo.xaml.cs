using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media;
using NGenerics.DataStructures.General;
using WpfExample.HgChart;

namespace WpfExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class GraphDemo
    {
        private ObservableCollection<int> _mainData = new ObservableCollection<int>();
        private Graph<int> gtr;
        public ObservableCollection<int> MainData
        {
            get { return _mainData; }
        }

        public GraphDemo()
        {
            InitializeComponent();

            gtr = new Graph<int>(false);

            var chart = new HGChartCtrl
             {
                 Height = 400,
                 DataSource = _mainData,
                 SpaceBetweenBars = 1,
                 ShowAxisLabel = false,
                 ShowValueOnBar = false,
                 SmartAxisLabel = true,
                 TextColor = Brushes.Yellow,
             };
            StPanelMain.Children.Add(chart);
        }



        private void btnAddData_Click(object sender, RoutedEventArgs e)
        {
            AddRandomData();
        }

        private void AddRandomData()
        {
            Random rnd = new Random();
            var k = gtr.Vertices.Count;
            int n;
            for (n = k; n < k + 5; n++)
            {
                gtr.AddVertex(n);
            }
            for (int i = 0; i < 10; i++)
            {
                var from = gtr.GetVertex(rnd.Next(n));
                var to = gtr.GetVertex(rnd.Next(n));
                if (!gtr.ContainsEdge(from, to))
                    gtr.AddEdge(from, to);
            }
        }

        private void btnSortData_Click(object sender, RoutedEventArgs e)
        {

        }




        private void btnMagic_Click(object sender, RoutedEventArgs e)
        {
        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AddRandomData();
        }
    }
}
