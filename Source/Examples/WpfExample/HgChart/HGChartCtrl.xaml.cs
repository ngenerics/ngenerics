using System;
using System.Collections;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfExample.HgChart
{
    /// <summary>
    ///   High performant chart control optimised for display off many elements (>1000 points) and still remaining responsive
    /// </summary>
    public partial class HGChartCtrl
    {
        /// <summary>
        /// tekporary variable used for testing
        /// </summary>
        private int _testCounter = 0;
        private double _maxData;
        private double _leftMargin;
        private double _topMargin;
        private TextBlock _txtTopTitle;
        private readonly MyVisualHost visualHost = new MyVisualHost();


        #region Properties
        public bool ShowValueOnBar { get; set; }
        public bool ShowAxisLabel { get; set; }
        public bool SmartAxisLabel { get; set; }
        public string Title { get; set; }
        public string XAxisField { get; set; }
        public ICollection DataSource { get; set; }
        public double SpaceBetweenBars { get; set; }


        public Brush TextColor
        {
            get { return _txtTopTitle.Foreground; }
            set { _txtTopTitle.Foreground = value; }
        }

        public int ChartingMethod
        {
            set { visualHost.ChartingMethod(value); }
        }

        #endregion

        public HGChartCtrl()
        {
            InitializeComponent();
            InitChartControls();
        }

        /// <summary>
        ///   Initialize chart controls.
        /// </summary>
        private void InitChartControls()
        {
            _leftMargin = 5;
            _topMargin = 5;
            SpaceBetweenBars = 8;
            ChartingMethod = 5;
            _txtTopTitle = new TextBlock();
            ShowAxisLabel = true;
        }

        /// <summary>
        ///   Draws an empty chart.
        /// </summary>
        private void DrawEmptyChart()
        {
            txtNoData.Visibility = Visibility.Visible;
            Canvas.SetTop(txtNoData, _chartArea.Height / 2);
            Canvas.SetLeft(txtNoData, _chartArea.Width / 2);
        }


        /// <summary>
        ///   Prepares the chart for rendering.  Sets up control width and location.
        /// </summary>
        private void PrepareChartForRendering()
        {
            _txtTopTitle.Width = ActualWidth;
            _txtTopTitle.FontSize = 14;
            _txtTopTitle.TextAlignment = TextAlignment.Center;
            _chartArea.Height = ActualHeight;
            _chartArea.Width = ActualWidth;
            Canvas.SetTop(_txtTopTitle, _topMargin);
            Canvas.SetLeft(_txtTopTitle, _leftMargin);
            _chartArea.Children.Add(_txtTopTitle);
        }

        #region Rendering
        readonly object renderLock = new object();

        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            base.OnRenderSizeChanged(sizeInfo);
            Repaint();
        }

        /// <summary>
        /// Thread safe queueless Repainter
        /// </summary>
        public void Repaint()
        {
            Interlocked.Increment(ref _testCounter);
            if (Monitor.TryEnter(renderLock))
            {
                try
                {
                    Generate();
                }
                finally
                {
                    Monitor.Exit(renderLock);
                    Interlocked.Decrement(ref _testCounter);
                }
            }
        }

        /// <summary>
        ///   Creates the chart based on the datasource.
        /// </summary>
        protected void Generate()
        {

            // _stopWatch.Reset();
            // Reset / Clear
            _chartArea.Children.Clear();

            // Will be made more generic in the next versions.
            var dt = DataSource;

            if (dt != null && dt.Count > 0)
            {
                // Hide the nodata found text.
                txtNoData.Visibility = Visibility.Hidden;

                // Get the max y-value.
                // This is used to calculate the scale and y-axis.
                _maxData = GetMax(dt);

                // Prepare the chart for rendering.
                // Does some basic setup.
                PrepareChartForRendering();

                // Set the barwidth. This is required to adjust
                // the size based on available no. of bars.

                visualHost.CreateChart(dt, _maxData, _chartArea.Height - _topMargin, _chartArea.Width - _leftMargin);
                visualHost.CreateAxes(_chartArea.Width, _chartArea.Height);
                _chartArea.Children.Add(visualHost);
            }
            else
            {
                // if no data found draw empty chart.
                DrawEmptyChart();
            }
            //_stopWatch.Stop();
            _txtTopTitle.Text = String.Format("{0:N0}", _testCounter);
        }

        #endregion

        /// <summary>
        ///   Get max value data element.
        /// </summary>
        /// <param name = "dt"></param>
        /// <returns></returns>
        private static double GetMax(ICollection dt)
        {
            double max = 0;

            foreach (var el in dt)
            {
                var tmp = Convert.ToDouble(el);

                if (tmp > max)
                    max = tmp;
            }
            return max;
        }
    }
}