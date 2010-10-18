using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media;
using NGenerics.Sorting;
using WpfExample.HgChart;

namespace WpfExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private ObservableCollection<int> _mainData = new ObservableCollection<int>();
        private readonly Random _rnd = new Random();
        private readonly List<HGChartCtrl> hgc = new List<HGChartCtrl>();

        public ObservableCollection<ISorter<int>> SorterList
        {
            get { return _sorterList; }
        }

        public ObservableCollection<int> MainData
        {
            get { return _mainData; }
        }

        private readonly ObservableCollection<ISorter<int>> _sorterList = new ObservableCollection<ISorter<int>>
																	{
																		new BubbleSorter<int>(),
																		new BucketSorter(),
																		new CocktailSorter<int>(),
																		new CombSorter<int>(),
																		new GnomeSorter<int>(),
																		new HeapSorter<int>(),
																		new InsertionSorter<int>(),
																		new MergeSorter<int>(),
																		new OddEvenTransportSorter<int>(),
																		new QuickSorter<int>(),
																		new RadixSorter(),
																		new SelectionSorter<int>(),
																		new ShakerSorter<int>(),
																		new ShellSorter<int>()
	};


        public MainWindow()
        {
            InitializeComponent();

            for (var i = 5; i > 0; i--)
            {
                var chrt = new HGChartCtrl
                            {
                                Height = 50,
                                DataSource = _mainData,
                                SpaceBetweenBars = 1,
                                ShowAxisLabel = false,
                                ShowValueOnBar = false,
                                SmartAxisLabel = true,
                                TextColor = Brushes.Yellow,
                                ChartingMethod = i
                            };
                StPanelMain.Children.Add(chrt);
                hgc.Add(chrt);
            }
        }

        public void SetSource(ObservableCollection<int> src)
        {
            _mainData = src;
            foreach (var hgChartCtrl in hgc)
            {
                hgChartCtrl.DataSource = src;
                hgChartCtrl.Repaint();
            }

        }
        private void btnAddData_Click(object sender, RoutedEventArgs e)
        {
            AddRandomData();
        }

        private void AddRandomData()
        {
            for (var i = 0; i < 100; i++)
            {
                _mainData.Add(_rnd.Next(250));
            }
            SetSource(_mainData);
        }

        private void btnSortData_Click(object sender, RoutedEventArgs e)
        {
            SortChartData();
        }

        private void SortChartData()
        {
            var sorter = comboSorter.SelectedItem as ISorter<int>;

            if (sorter == null)
            {
                MessageBox.Show("Please, choose sorting method");
                return;
            }

            var sortedData = new ObservableCollection<int>(_mainData);
            sorter.Sort(sortedData, SortOrder.Ascending);
            SetSource(sortedData);
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
