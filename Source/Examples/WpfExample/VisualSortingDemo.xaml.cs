using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media;
using NGenerics.Sorting;
using NGenerics.Threading;
using WpfExample.HgChart;

namespace WpfExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class VisualSortingDemo
    {
        private ObservableCollection<int> _mainData = new ObservableCollection<int>();
        private readonly Random _rnd = new Random();
        private readonly HGChartCtrl chart;

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


        public VisualSortingDemo()
        {
            InitializeComponent();
            backgroundWorker.DoWork += backgroundWorker_DoWork;
            backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
            backgroundWorker.ProgressChanged += backgroundWorker_ProgressChanged;

            chart = new HGChartCtrl
            {
                Height = 300,
                DataSource = _mainData,
                SpaceBetweenBars = 1,
                ShowAxisLabel = false,
                ShowValueOnBar = false,
                SmartAxisLabel = true,
                TextColor = Brushes.Yellow,
            };
            StPanelMain.Children.Add(chart);
        }

        public void SetSource(ObservableCollection<int> src)
        {
            _mainData = src;

            chart.DataSource = src;
            chart.Repaint();
        }

        private void btnAddData_Click(object sender, RoutedEventArgs e)
        {
            AddRandomData();
        }

        private void AddRandomData()
        {
            for (var i = 0; i < 10; i++)
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
            ISorter<int> sorter = GetSorter();
            if (sorter == null) return;

            var sortedData = new ObservableCollection<int>(_mainData);
            sorter.Sort(sortedData, SortOrder.Ascending);
            SetSource(sortedData);
        }

        private ISorter<int> GetSorter()
        {
            var sorter = comboSorter.SelectedItem as ISorter<int>;

            if (sorter == null)
            {
                MessageBox.Show("Please, choose sorting method");
            }
            return sorter;
        }

        private void btnMagic_Click(object sender, RoutedEventArgs e)
        {
            // backgroundworker is the most robust technique because it allows
            //   monitoring and cancellation of task
            //Status.Text = "Working using BackgroundWorker...";
            StartBackgroundWorker();
        }


        #region The Work
        // methods that do the time consuming work

        private BackgroundWorker<ISorter<int>, ObservableCollection<int>, ObservableCollection<int>> backgroundWorker
            = new BackgroundWorker<ISorter<int>, ObservableCollection<int>, ObservableCollection<int>>
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true,
            };

        private void StartBackgroundWorker()
        {
            if (backgroundWorker.IsBusy)
            {
                btnMagic.Content = "Start magic";
                backgroundWorker.CancelAsync();
            }
            else
            {
                ISorter<int> sorter = GetSorter();
                if (sorter == null) return;


                btnMagic.Content = "Stop magic";
                backgroundWorker.RunWorkerAsync(sorter);

            }

        }


        // This method performs work on a separate thread
        // (not UI thread). It does NOT update UI.
        // UI is updated directly by the Background Completed method
        // Used by: Background thread technique of executing work
        //         
        ObservableCollection<int> SortDataInDifferentThread(ISorter<int> sorter)
        {
            var sortedData = new DelayedObservableCollection<int>(_mainData) { Delay = 100, };
            sortedData.CollectionChanged += _sortData_CollectionChanged;
            sorter.Sort(sortedData, SortOrder.Ascending);
            return new ObservableCollection<int>(sortedData);
        }

        void _sortData_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            backgroundWorker.ReportProgress(1, sender as ObservableCollection<int>);
        }

        // Runs on Ui thread
        void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs<ObservableCollection<int>> e)
        {
            SetSource(e.UserState);
        }


        void backgroundWorker_DoWork(object sender, DoWorkEventArgs<ISorter<int>, ObservableCollection<int>> e)
        {
            // UI Update is done directly in Background completed method
            e.Result = SortDataInDifferentThread(e.Argument);

        }

        ///runs on Ui Thread
        void backgroundWorker_RunWorkerCompleted(object sender,
            RunWorkerCompletedEventArgs<ObservableCollection<int>> e)
        {
            btnMagic.Content = "Start Magic";
            SetSource(e.UserState);


        }


        #endregion
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AddRandomData();
        }

        private void btnResetData_Click(object sender, RoutedEventArgs e)
        {
            _mainData.Clear();
            AddRandomData();
        }
    }
}
