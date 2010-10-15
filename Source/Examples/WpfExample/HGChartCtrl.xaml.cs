using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace WpfExample.HgChart
{
    /// <summary>
    /// Interaction logic for HGChart.xaml
    /// </summary>
    public partial class HGChartCtrl : UserControl
    {
        private double _maxData;
        private double _leftMargin = 3;
        private double _spaceBetweenBars = 8;

        private Stopwatch _stopWatch = new Stopwatch();
        private TextBlock _txtTopTitle;
        private bool _showAxisLabel;
        private DispatcherTimer _resizeTimer = new DispatcherTimer { Interval = new TimeSpan(0, 0, 0, 0, 100), IsEnabled = false };
        private MyVisualHost visualHost = new MyVisualHost();

        public bool ShowValueOnBar { get; set; }
        public bool SmartAxisLabel { get; set; }
        public string Title { get; set; }
        public string XAxisField { get; set; }
        public ICollection DataSource { get; set; }


        public HGChartCtrl()
        {
            InitializeComponent();
            InitChartControls();


            /* 
              GradientStopCollection gsc = new GradientStopCollection(2)
                                              {
                                                  new GradientStop(Colors.Black, 1),
                                                  new GradientStop(Colors.Gray, 0)
                                              };}

             _chartArea.Background = new LinearGradientBrush(gsc, 90);
             */
            _resizeTimer.Tick += _resizeTimer_Tick;
        }


        /// <summary>
        /// Initialize chart controls.
        /// </summary>
        private void InitChartControls()
        {
            _txtTopTitle = new TextBlock();
            ShowAxisLabel = true;
        }



        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            base.OnRenderSizeChanged(sizeInfo);

            _resizeTimer.Stop();
            _resizeTimer.Start();
        }

        void _resizeTimer_Tick(object sender, EventArgs e)
        {
            _resizeTimer.Stop();

            //you can get rid of this, it just helps you see that this event isn't getting fired all the time
            //Console.WriteLine("TICK" + tickCount++);

            //Do important one-time resizing work here
            //...

            Generate();
        }

        /// <summary>
        /// Draws an empty chart.
        /// </summary>
        private void DrawEmptyChart()
        {
            txtNoData.Visibility = Visibility.Visible;
            Canvas.SetTop(txtNoData, _chartArea.Height / 2);
            Canvas.SetLeft(txtNoData, _chartArea.Width / 2);
        }

        /// <summary>
        /// Get max value data element.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        double GetMax(ICollection dt)
        {
            double max = 0;

            foreach (var el in dt)
            {
                double tmp = Convert.ToDouble(el);

                if (tmp > max)
                    max = tmp;
            }
            return max;
        }

        /// <summary>
        /// Sets up the chart area with default values
        /// </summary>
        private bool SetUpChartArea()
        {
            _chartArea.Height = ActualHeight;
            _chartArea.Width = ActualWidth;
            _chartArea.Children.Add(_txtTopTitle);
            return true;
        }

        /// <summary>
        /// Prepares the chart for rendering.  Sets up control width and location.
        /// </summary>
        private void PrepareChartForRendering()
        {
            _txtTopTitle.Width = ActualWidth;
            _txtTopTitle.FontSize = 14;
            _txtTopTitle.TextAlignment = TextAlignment.Center;
            Canvas.SetTop(_txtTopTitle, 10);
            Canvas.SetLeft(_txtTopTitle, _leftMargin);
        }

        /// <summary>
        /// Creates the chart based on the datasource.
        /// </summary>
        public void Generate()
        {
            _stopWatch.Restart();
            // Reset / Clear
            _chartArea.Children.Clear();

            // Setup chart area.
            if (!SetUpChartArea())
                return;

            // Will be made more generic in the next versions.
            ICollection dt = DataSource;

            if (null != dt)
            {
                // if no data found draw empty chart.
                if (dt.Count == 0)
                {
                    DrawEmptyChart();
                    return;
                }

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
                
                visualHost.CreateChart(dt, _maxData, _chartArea.Height, _chartArea.Width);
                visualHost.CreateAxes(_chartArea.Width, _chartArea.Height);
                _chartArea.Children.Add(visualHost);
            }

            _stopWatch.Stop();
            _txtTopTitle.Text = String.Format("{0:N0}", _stopWatch.ElapsedTicks);
        }



        #region Properties

        public Brush TextColor
        {
            get
            {
                return _txtTopTitle.Foreground;
            }
            set
            {
                _txtTopTitle.Foreground = value;
            }
        }

        public double SpaceBetweenBars
        {
            get { return _spaceBetweenBars; }
            set { _spaceBetweenBars = value; }
        }

        public bool ShowAxisLabel
        {
            get { return _showAxisLabel; }
            set { _showAxisLabel = value; }
        }

        public int ChartingMethod
        {
            set { visualHost.ChartingMethod( value); }
        }
        #endregion


    }
}
