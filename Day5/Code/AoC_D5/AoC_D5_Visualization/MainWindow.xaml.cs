using AoC_D5;
using AoC_D5.MathUtil;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Span = AoC_D5.MathUtil.Span;
using Path = System.Windows.Shapes.Path;

namespace AoC_D5_Visualization
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string[] full_example_input =
        {
            "seeds: 79 14 55 13",
            "",
            "seed-to-soil map:",
            "50 98 2",
            "52 50 48",
            "",
            "soil-to-fertilizer map:",
            "0 15 37",
            "37 52 2",
            "39 0 15",
            "",
            "fertilizer-to-water map:",
            "49 53 8",
            "0 11 42",
            "42 0 7",
            "57 7 4",
            "",
            "water-to-light map:",
            "88 18 7",
            "18 25 70",
            "",
            "light-to-temperature map:",
            "45 77 23",
            "81 45 19",
            "68 64 13",
            "",
            "temperature-to-humidity map:",
            "0 69 1",
            "1 0 69",
            "",
            "humidity-to-location map:",
            "60 56 37",
            "56 93 4",
        };


        //readonly double scale = 1200.0 / 100;
        readonly double scale = 1200.0 / 4500000000;
        readonly int lineHeight = 1000/8;
        readonly int global_y = 10;
        readonly int global_x = 10;

        public MainWindow()
        {
            InitializeComponent();

            //var input = full_example_input;
            var input = File.ReadAllLines("input.txt");

            RangeAlmanac almanac = (RangeAlmanac)(new AlmanacFactory().LoadAlamanac(input, useSeedRanges: true));
            almanac.MapSeeds();

            DrawGrid(almanac.Maps.Count);
            BuildAllSeedPaths(almanac);
            Console.WriteLine(almanac.SeedRanges[0].ToString());
        }

        void DrawGrid(int count)
        {
            var lineWidth = 1200;
            PathGeometry myPathGeometry = new PathGeometry();
            for (int lineNo = 0; lineNo < (count+1); lineNo++)
            {
                PathFigure myPathFigure = new PathFigure();
                myPathFigure.StartPoint = new Point(global_x, global_y + lineHeight * lineNo);
                myPathFigure.Segments.Add(
                new LineSegment(
                    new Point(global_x + lineWidth, global_y + lineHeight * lineNo),
                    true /* IsStroked */ ));
                myPathGeometry.Figures.Add(myPathFigure);
            }
            gridPath.Stroke = Brushes.Black;
            gridPath.StrokeThickness = 1;
            //gridPath.Fill = Brushes.LightBlue;
            gridPath.Data = myPathGeometry;
        }

        PathFigure GetMappedSpanFigure(IMappedSpan mapped, int lineNo)
        {
            var from_x0 = global_x + scale * ((mapped.MappedBy?.GetUnmappedValue(mapped.Span.Start) ?? mapped.Span.Start)-1);
            var from_x1 = global_x + scale * (mapped.MappedBy?.GetUnmappedValue(mapped.Span.End) ?? mapped.Span.End);
            var to_x0 = global_x + scale * (mapped.Span.Start-1);
            var to_x1 = global_x + scale * mapped.Span.End;


            // Create a figure.
            PathFigure myPathFigure = new PathFigure();
            myPathFigure.StartPoint = new Point(from_x0, global_y + lineHeight * lineNo);
            //myPathFigure.Segments.Add(
            //    new LineSegment(
            //        new Point(to_x0, y0 + lineHeight),
            //        true /* IsStroked */ ));
            myPathFigure.Segments.Add(
                new BezierSegment(
                    new Point(from_x0, global_y + lineHeight/2 + lineHeight * lineNo),
                    new Point(to_x0, global_y + lineHeight / 2 + lineHeight * lineNo),
                    new Point(to_x0, global_y + lineHeight + lineHeight * lineNo),
                    true /* IsStroked */));
            myPathFigure.Segments.Add(
                new LineSegment(
                    new Point(to_x1, global_y + lineHeight + lineHeight * lineNo),
                    false /* IsStroked */ ));
            //myPathFigure.Segments.Add(
            //    new LineSegment(
            //        new Point(from_x1, y0),
            //        true /* IsStroked */ ));
            myPathFigure.Segments.Add(
                new BezierSegment(
                    new Point(to_x1, global_y + lineHeight / 2 + lineHeight * lineNo),
                    new Point(from_x1, global_y + lineHeight / 2 + lineHeight * lineNo),
                    new Point(from_x1, global_y + lineHeight * lineNo),
                    true /* IsStroked */));




            return myPathFigure;
        }
        Geometry BuildSeedPathGeometry(SeedRange seedRange)
        {
            /// Create a PathGeometry to contain the figure.
            GeometryGroup combinedGeometry = new GeometryGroup();
            for (int lineNo = 0; lineNo < seedRange.mappedValues.Count; lineNo++)
            {
                foreach(var mapped in seedRange.mappedValues[lineNo])
                {
                    PathGeometry myPathGeometry = new PathGeometry();
                    myPathGeometry.Figures.Add(GetMappedSpanFigure(mapped,lineNo));
                    combinedGeometry.Children.Add(myPathGeometry);
                }
            }
            combinedGeometry.FillRule = FillRule.Nonzero;
            return combinedGeometry;
        }

        // https://stackoverflow.com/questions/1335426/is-there-a-built-in-c-net-system-api-for-hsv-to-rgb
        private Color hsv2rgb(float h, float s, float v)
        {
            Func<float, int> f = delegate (float n)
            {
                float k = (n + h * 6) % 6;
                return (int)((v - (v * s * (Math.Max(0, Math.Min(Math.Min(k, 4 - k), 1))))) * 255);
            };
            return Color.FromScRgb (1, f(5), f(3), f(1));
        }
        public static Color ColorFromHSV(double hue, double saturation, double value)
        {
            int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
            double f = hue / 60 - Math.Floor(hue / 60);

            value = value * 255;
            int v = Convert.ToInt32(value);
            int p = Convert.ToInt32(value * (1 - saturation));
            int q = Convert.ToInt32(value * (1 - f * saturation));
            int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));

            if (hi == 0)
                return Color.FromArgb(255, (byte)v, (byte)t, (byte)p);
            else if (hi == 1)
                return Color.FromArgb(255, (byte)q, (byte)v, (byte)p);
            else if (hi == 2)
                return Color.FromArgb(255, (byte)p, (byte)v, (byte)t);
            else if (hi == 3)
                return Color.FromArgb(255, (byte)p, (byte)q, (byte)v);
            else if (hi == 4)
                return Color.FromArgb(255, (byte)t, (byte)p, (byte)v);
            else
                return Color.FromArgb(255, (byte)v, (byte)p, (byte)q);
        }
        void BuildAllSeedPaths(RangeAlmanac almanac)
        {
            // Display the PathGeometry.
            for(int i = 0; i < almanac.SeedRanges.Count; i++)
            {
                var myPath = new Path();
                myPath.Stroke = Brushes.Black;
                myPath.StrokeThickness = 1;
                //myPath.Fill = Brushes.LightBlue;
                myPath.Fill = new SolidColorBrush(ColorFromHSV((((double)i)/(almanac.SeedRanges.Count+1))*360, 1, 0.8f));
                myPath.Opacity = 0.2;
                myPath.Data = BuildSeedPathGeometry((SeedRange)almanac.SeedRanges[i]);
                //pathItems.Items.Add(myPath);
                pathItems.Children.Add(myPath);

                myPath.MouseDown += OnMouseDown;
                myPath.MouseEnter += OnMouseEnter;
                myPath.MouseLeave += OnMouseLeave;
            }
        }

        private void OnMouseLeave(object sender, MouseEventArgs e)
        {
            (sender as Path).Opacity = 0.2;
        }

        private void OnMouseEnter(object sender, MouseEventArgs e)
        {
            (sender as Path).Opacity = 1;
        }

        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Clicked!");
        }
    }
}
