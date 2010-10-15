using System;
using System.Windows.Media;

namespace WpfExample.HgChart
{
    public class Bar
    {
        #region "Private Variables"

        private Color barColor = Colors.Red;
        private double barWidth = 5;
        private Color colorOnMouseOver = Colors.Yellow;

        #endregion

        #region "Properties"

        public Bar()
        {
        }
        
        public Bar(double value, string argument)
        {
            ID = string.Empty;
            BarValue = value;
            Argument = argument;
        }

        public Color BarColor
        {
            get { return barColor; }
            set { barColor = value; }
        }

        public double BarWidth
        {
            get { return barWidth; }
            set { barWidth = value; }
        }

        public string BarLabel { get; set; }

        public Color ColorOnMouseOver
        {
            get { return colorOnMouseOver; }
            set { colorOnMouseOver = value; }
        }

        public DateTime TimeStamp { get; set; }

        public string QueryParam { set; get; }

        public string ParamValue { set; get; }

        public double BarHeight { set; get; }

        public double Top { set; get; }

        public double Left { set; get; }

        public string ID { set; get; }

        public double BarValue { set; get; }

        public string Argument { get; set; }

        #endregion
    }
}