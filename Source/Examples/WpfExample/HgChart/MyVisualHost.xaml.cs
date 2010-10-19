using System;
using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace WpfExample
{
    public class MyVisualHost : FrameworkElement
    {
        private const int _tick_width = 3;
        private const int _tick_step = 5;
        private const int _axis_start = 5;
        // Create a collection of child visual objects.
        private VisualCollection _children;


        public MyVisualHost()
        {
            _children = new VisualCollection(this);
            // _children.Add(CreateDrawingVisualRectangle());
            //_children.Add(CreateDrawingVisualText());
            //_children.Add(CreateDrawingVisualEllipses());

            // Add the event handler for MouseLeftButtonUp.
            MouseLeftButtonUp += new MouseButtonEventHandler(MyVisualHost_MouseLeftButtonUp);
            CreateChart = CreateDotChart;

        }

        public void ChartingMethod(int i)
        {
            switch (i)
            {
                case 5: CreateChart = CreateDotChartGeometry; break;
                case 4: CreateChart = CreateBarChart; break;
                case 3: CreateChart = CreateDotChartGeometryAlt; break;
                case 2: CreateChart = CreateBarChart; break;
                case 1: CreateChart = CreateDotChartAlt; break;
                default:
                    CreateChart = CreateDotChart;
                    break;
            }
        }

        // Capture the mouse event and hit test the coordinate point value against
        // the child visual objects.
        void MyVisualHost_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //// Retreive the coordinates of the mouse button event.
            //System.Windows.Point pt = e.GetPosition((UIElement)sender);

            //// Initiate the hit test by setting up a hit test result callback method.
            //VisualTreeHelper.HitTest(this, null, new HitTestResultCallback(myCallback), new PointHitTestParameters(pt));
        }

        // If a child visual object is hit, toggle its opacity to visually indicate a hit.
        public HitTestResultBehavior myCallback(HitTestResult result)
        {
            //if (result.VisualHit.GetType() == typeof(DrawingVisual))
            //{
            //    if (((DrawingVisual)result.VisualHit).Opacity == 1.0)
            //    {
            //        ((DrawingVisual)result.VisualHit).Opacity = 0.4;
            //    }
            //    else
            //    {
            //        ((DrawingVisual)result.VisualHit).Opacity = 1.0;
            //    }
            //}

            // Stop the hit test enumeration of objects in the visual tree.
            return HitTestResultBehavior.Stop;
        }


        Pen _chartPen = new Pen(Brushes.Red, 3);
        Pen _axisPen = new Pen(Brushes.White, 2);
        Pen _tickPen = new Pen(Brushes.White, 1);

        private double SetBarWidth(int barCount, double chartWidth)
        {
            var barWidth = (chartWidth - (_axis_start * 3)) / (barCount);

            if (barWidth <= 0)
                barWidth = 1;
            return barWidth;
        }

        // Create a DrawingVisual that contains a rectangle.
        public void CreateBarChart(ICollection dt, double _maxData, double chartHeight, double chartWidth)
        {
            _children.Clear();
            stopWatch.Restart();

            var barWidth = SetBarWidth(dt.Count, chartWidth);
            var visual = new DrawingVisual();
            using (var dc = visual.RenderOpen())
            {
                // For each row in the datasource
                double left, right = _axis_start;
                foreach (var el in dt)
                {
                    // Calculate bar value.
                    var height = Convert.ToDouble(el) * (chartHeight - _axis_start) / _maxData;
                    left = right;
                    right = barWidth + left;

                    dc.DrawRectangle(null, _chartPen, new Rect(left, chartHeight - height - _axis_start, barWidth, height));
                }
                stopWatch.Stop();
                // Get the elapsed time as a TimeSpan value.

                // Format and display the TimeSpan value.

                var elapsedTime = String.Format("{0} - {1} - {2}", MethodBase.GetCurrentMethod().Name, dt.Count, stopWatch.ElapsedTicks);

                dc.DrawText(new FormattedText(elapsedTime, CultureInfo.InvariantCulture, FlowDirection.LeftToRight, new Typeface("Verdana"), 12, Brushes.LightGreen), new Point(10, 10));

            }
            _children.Add(visual);
        }

        public delegate void CreateChartDelegate(ICollection dt, double _maxData, double chartHeight, double chartWidth);

        public CreateChartDelegate CreateChart;
        Stopwatch stopWatch = new Stopwatch();

        public void CreateDotChartGeometryAlt(ICollection dt, double _maxData, double chartHeight, double chartWidth)
        {
            _children.Clear();
            stopWatch.Restart();

            var barWidth = SetBarWidth(dt.Count, chartWidth);

            var geo = new StreamGeometry();
            using (var geoContext = geo.Open())
            {

                // For each row in the datasource
                double centerX = _axis_start;
                foreach (var el in dt)
                {
                    // Calculate bar value.
                    var height = Convert.ToDouble(el) * (chartHeight - _axis_start) / _maxData;
                    centerX += barWidth;

                    geoContext.BeginFigure(new Point(centerX, chartHeight - height - _axis_start), false, false);
                    geoContext.LineTo(new Point(centerX + 2, chartHeight - height - _axis_start), true, false);
                }
            }


            geo.Freeze();
            var visual = new DrawingVisual();
            using (var dc = visual.RenderOpen())
            {
                dc.DrawGeometry(null, _chartPen, geo);
                stopWatch.Stop();

                var elapsedTime = String.Format("{0} - {1} - {2}", MethodBase.GetCurrentMethod().Name, dt.Count, stopWatch.ElapsedTicks);

                dc.DrawText(
                    new FormattedText(elapsedTime, CultureInfo.InvariantCulture, FlowDirection.LeftToRight, new Typeface("Verdana"),
                                      12, Brushes.LightGreen), new Point(10, 10));

            }

            _children.Add(visual);
        }

        public void CreateDotChartGeometry(ICollection dt, double _maxData, double chartHeight, double chartWidth)
        {
            _children.Clear();
            stopWatch.Restart();

            var barWidth = SetBarWidth(dt.Count, chartWidth);
            var ellipses = new GeometryGroup();


            // For each row in the datasource
            double centerX = _axis_start;
            foreach (var el in dt)
            {
                // Calculate bar value.
                var height = Convert.ToDouble(el) * (chartHeight - _axis_start) / _maxData;
                centerX += barWidth;
                ellipses.Children.Add(
                    new EllipseGeometry(new Point(centerX, chartHeight - height - _axis_start), 1, 1)
                    );
            }
            ellipses.Freeze();

            var visual = new DrawingVisual();
            using (var dc = visual.RenderOpen())
            {
                dc.DrawGeometry(null, _chartPen, ellipses);
                stopWatch.Stop();

                var elapsedTime = String.Format("{0} - {1} - {2}", MethodBase.GetCurrentMethod().Name, dt.Count, stopWatch.ElapsedTicks);

                dc.DrawText(
                    new FormattedText(elapsedTime, CultureInfo.InvariantCulture, FlowDirection.LeftToRight, new Typeface("Verdana"),
                                      12, Brushes.LightGreen), new Point(10, 10));

            }
            _children.Add(visual);
        }


        public void CreateDotChartAlt(ICollection dt, double _maxData, double chartHeight, double chartWidth)
        {
            _children.Clear();
            stopWatch.Restart();

            var barWidth = SetBarWidth(dt.Count, chartWidth);
            var visual = new DrawingVisual();
            using (var dc = visual.RenderOpen())
            {
                // For each row in the datasource
                double centerX = _axis_start;
                foreach (var el in dt)
                {
                    // Calculate bar value.
                    var height = Convert.ToDouble(el) * (chartHeight - _axis_start) / _maxData;
                    centerX += barWidth;
                    dc.DrawRectangle(null, _chartPen, new Rect(centerX, chartHeight - height - _axis_start, 1, 1));
                }
                stopWatch.Stop();

                var elapsedTime = String.Format("{0} - {1} - {2}", MethodBase.GetCurrentMethod().Name, dt.Count, stopWatch.ElapsedTicks);

                dc.DrawText(new FormattedText(elapsedTime, CultureInfo.InvariantCulture, FlowDirection.LeftToRight, new Typeface("Verdana"), 12, Brushes.LightGreen), new Point(10, 10));

            }
            _children.Add(visual);
        }

        public void CreateDotChart(ICollection dt, double _maxData, double chartHeight, double chartWidth)
        {
            _children.Clear();
            stopWatch.Restart();

            var barWidth = SetBarWidth(dt.Count, chartWidth);
            var visual = new DrawingVisual();
            using (var dc = visual.RenderOpen())
            {
                // For each row in the datasource
                double centerX = _axis_start;
                foreach (var el in dt)
                {
                    // Calculate bar value.
                    var height = Convert.ToDouble(el) * (chartHeight - _axis_start) / _maxData;
                    centerX += barWidth;
                    dc.DrawEllipse(null, _chartPen, new Point(centerX, chartHeight - height - _axis_start), 1, 1);

                    //dc.DrawRectangle(null, _chartPen, new Rect(centerX, _height - height - _axis_start ,1, 1));
                }
                stopWatch.Stop();

                var elapsedTime = String.Format("{0} - {1} - {2}", MethodBase.GetCurrentMethod().Name, dt.Count, stopWatch.ElapsedTicks);

                dc.DrawText(
                    new FormattedText(elapsedTime, CultureInfo.InvariantCulture, FlowDirection.LeftToRight, new Typeface("Verdana"),
                                      12, Brushes.LightGreen), new Point(10, 10));

            }
            _children.Add(visual);
        }

        public void CreateAxes(double chartWidth, double chartHeight)
        {
            var visual = new DrawingVisual();
            using (var dc = visual.RenderOpen())
            {
                double x = _axis_start;

                var y = chartHeight - _axis_start;
                dc.DrawLine(_axisPen, new Point(x, y), new Point(x, 0));
                dc.DrawLine(_axisPen, new Point(x, y), new Point(chartWidth, y));

                for (var i = _tick_step; i < y; i += _tick_step)
                {
                    dc.DrawLine(_tickPen, new Point(x - _tick_width, i), new Point(x + _tick_width, i));
                }
                for (var i = _tick_step; i < chartWidth; i += _tick_step)
                {
                    dc.DrawLine(_tickPen, new Point(i, y - _tick_width), new Point(i, y + _tick_width));
                }


            }
            _children.Add(visual);
        }


        // Provide a required override for the VisualChildrenCount property.
        protected override int VisualChildrenCount
        {
            get { return _children.Count; }
        }

        //public VisualCollection Children
        //{
        //    get { return _children; }
        //    set { _children = value; }
        //}

        // Provide a required override for the GetVisualChild method.
        protected override Visual GetVisualChild(int index)
        {
            if (index < 0 || index >= _children.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            return _children[index];
        }
    }
}