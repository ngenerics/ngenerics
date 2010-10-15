using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using NGenerics.Sorting;
using WpfExample.HgChart;

namespace WpfExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PointCollection _data;
        //public int MyProperty { get; set; }
        private ObservableCollection<int> _mainData = new ObservableCollection<int> { 1, 12, 123, 53 };
        public ObservableCollection<int> MainData { get { return _mainData; } }
        private Random _rnd = new Random();
        public ObservableCollection<ISorter<int>> SorterList { get { return _sorterList; } }
        private ObservableCollection<ISorter<int>> _sorterList = new ObservableCollection<ISorter<int>>
                                                                    {
                                                                        new BubbleSorter<int>(),
                                                                        new BucketSorter(),
                                                                        new CocktailSorter<int>(),
                                                                        new CombSorter<int>(),
                                                                        new GnomeSorter<int>(),
                                                                        new  HeapSorter<int>(),
                                                                        new InsertionSorter<int>(),
                                                                        new MergeSorter<int>(),
                                                                        new OddEvenTransportSorter<int>(),
                                                                        new QuickSorter<int>(),
                                                                        new RadixSorter(),
                                                                        new SelectionSorter<int>(),
                                                                        new ShakerSorter<int>(),
                                                                        new ShellSorter<int>()
    };

        private List<HGChartCtrl> hgc=new List<HGChartCtrl>();
        public MainWindow()
        {
            InitializeComponent();

            MainData.Add(23);

            _data = LayoutRoot.Resources["CodeData"] as PointCollection;

            _data.Add(new Point(2, 100));
            _data.Add(new Point(22, 120));
            _data.Add(new Point(4, 80));
            for (int i = 5; i >0; i--)
            {
                var chrt = new HGChartCtrl()
                {
                    // Width = 50,
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

        private void btnAddData_Click(object sender, RoutedEventArgs e)
        {
            
             //int[]data=new int[_mainData.Count+100];
                 
            //_mainData.CopyTo(data,100);
            for (int i = 0; i < 100; i++)
            {
                _mainData.Add(_rnd.Next(250));
            }
            //_mainData = new ObservableCollection<int>(data);
        }

        private void btnSortData_Click(object sender, RoutedEventArgs e)
        {
            var sorter = comboSorter.SelectedItem as ISorter<int>;

            if (sorter == null)
            {
                MessageBox.Show("Pleas, choose sorting method");
                return;
            }

            var a = new ObservableCollection<int>(_mainData);
            //_mainData.Clear();
            sorter.Sort(a, SortOrder.Ascending);
            // OriginalData.ItemsSource = a;
            _mainData = a;
        }

        private void btnMagic_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                Rectangle rect = new Rectangle()
                                     {
                                         Height = 20,
                                         Width = 20
                                     };
                Button btn = new Button()
                                 {
                                     Content = "btn" + i,
                                 };

                stChartPanel.Children.Add(btn);


            }
            SortedData.ItemsSource = null;


        }
    }



    public class ObjectCollection : Collection<object>
    {
    }


}
