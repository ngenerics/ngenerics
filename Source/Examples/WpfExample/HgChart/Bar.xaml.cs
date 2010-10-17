using System;
using System.Windows.Media;

namespace WpfExample.HgChart
{
    public class Bar
    {

        public Bar()
        {
        	ColorOnMouseOver = Colors.Yellow;
        	BarWidth = 5;
        	BarColor = Colors.Red;
        }

    	public Bar(double value, string argument)
        {
    		ColorOnMouseOver = Colors.Yellow;
    		BarWidth = 5;
    		BarColor = Colors.Red;
    		ID = string.Empty;
            BarValue = value;
            Argument = argument;
        }

    	public Color BarColor { get; set; }

    	public double BarWidth { get; set; }

    	public string BarLabel { get; set; }

    	public Color ColorOnMouseOver { get; set; }

    	public DateTime TimeStamp { get; set; }

        public string QueryParam { set; get; }

        public string ParamValue { set; get; }

        public double BarHeight { set; get; }

        public double Top { set; get; }

        public double Left { set; get; }

        public string ID { set; get; }

        public double BarValue { set; get; }

        public string Argument { get; set; }
    }
}