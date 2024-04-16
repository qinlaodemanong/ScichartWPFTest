using SciChart.Charting.Model.DataSeries;
using SciChart.Charting.Visuals;
using SciChart.Charting.Visuals.RenderableSeries;
using SciChart.Data.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ScichartLineWPF
{
    /// <summary>
    /// LineChartExampleView.xaml 的交互逻辑
    /// </summary>
    public partial class LineChartExampleView : UserControl
    {
        private List<FastLineRenderableSeries> fastLineRenderableSeries;
        public LineChartExampleView()
        {
            // Enter scichart Key
            SciChartSurface.SetRuntimeLicenseKey("");
            InitializeComponent();
            fastLineRenderableSeries = new List<FastLineRenderableSeries>();
        }

        private void LineChartExampleView_OnLoaded(object sender, RoutedEventArgs e)
        {
            //CreateBugLine();
        }

        /// <summary>
        /// Create lines without anti-aliasing
        /// </summary>
        public void CreateBugLine()
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // 向上导航，直到找到包含项目文件的目录
            while (!Directory.Exists(Path.Combine(currentDirectory, "Resources")))
            {
                currentDirectory = Directory.GetParent(currentDirectory).FullName;
            }

            // 找到了包含项目文件的目录后，获取文件
            string filePath = Path.Combine(currentDirectory, "Resources");
            string xPath = Path.Combine(filePath, "bugX.txt");
            string yPath = Path.Combine(filePath, "bugY.txt");
            string y1Path = Path.Combine(filePath, "bugY1.txt");
            List<double> xData = GetChromData(xPath);
            List<double> yData = GetChromData(yPath);
            List<double> y1Data = GetChromData(y1Path);
            //List<double> y1Data = new List<double>();
            XyyDataSeries<double, double> splineBanDataSeries = new XyyDataSeries<double, double>();
            splineBanDataSeries.Append(xData, yData, y1Data);
            splineBanDataSeries.SeriesName = "BUG";
            var bandSeries = new FastBandRenderableSeries()
            {
                DataSeries = splineBanDataSeries,
                //Name = id,
                StrokeThickness = 1,
                Fill = Colors.Transparent,
                FillY1 = Colors.Transparent,
                StrokeY1 = Colors.LightGray,
                StrokeDashArrayY1 = new double[] { 5, 1 },
                AntiAliasing = true,
            };

            sciChart.RenderableSeries.Add(bandSeries);
            sciChart.ZoomExtents();
        }

        /// <summary>
        /// Create Ok Line
        /// </summary>
        public void CreateOkLine()
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // 向上导航，直到找到包含项目文件的目录
            while (!Directory.Exists(Path.Combine(currentDirectory, "Resources")))
            {
                currentDirectory = Directory.GetParent(currentDirectory).FullName;
            }

            // 找到了包含项目文件的目录后，获取文件
            string filePath = Path.Combine(currentDirectory, "Resources");
            string xPath = Path.Combine(filePath, "okDataX.txt");
            string yPath = Path.Combine(filePath, "okDataY.txt");
            string y1Path = Path.Combine(filePath, "okDataY1.txt");
            List<double> xData = GetChromData(xPath);
            List<double> yData = GetChromData(yPath);
            List<double> y1Data = GetChromData(y1Path);
            //List<double> y1Data = new List<double>();
            XyyDataSeries<double, double> splineBanDataSeries = new XyyDataSeries<double, double>();
            splineBanDataSeries.Append(xData, yData, y1Data);
            splineBanDataSeries.SeriesName = "OK";
            var bandSeries = new FastBandRenderableSeries()
            {
                DataSeries = splineBanDataSeries,
                //Name = id,
                StrokeThickness = 1,
                Fill = Colors.Transparent,
                FillY1 = Colors.Transparent,
                StrokeY1 = Colors.LightGray,
                StrokeDashArrayY1 = new double[] { 5, 1 },
                AntiAliasing = true,
            };

            sciChart.RenderableSeries.Add(bandSeries);
            sciChart.ZoomExtents();
        }

        /// <summary>
        /// 设置坐标轴颜色
        /// </summary>
        /// <param name="color">颜色值</param>
        public void SetAxisColor(Color color)
        {
            sciChart.BorderBrush = new SolidColorBrush(color);
        }

        /// <summary>
        /// 设置信号线颜色
        /// </summary>
        /// <param name="index">线的索引值</param>
        /// <param name="color">颜色值</param>
        public void SetSignalLineColor(int index, Color color)
        {
            fastLineRenderableSeries[index].Stroke = color;
        }

        /// <summary>
        /// 设置X轴的坐标范围
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public void SetXAxisRange(double min, double max)
        {
            XAxis.VisibleRange = new DoubleRange(min, max);
        }

        /// <summary>
        /// 设置Y轴的坐标范围
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public void SetYAxisRange(double min, double max)
        {
            YAxis.VisibleRange = new DoubleRange(min, max);
        }

        public void Create(double min, double max)
        {
            YAxis.VisibleRange = new DoubleRange(min, max);
        }

        private List<double> GetChromData(string filePath)
        {
            var reader = new StreamReader(filePath);
            string line;
            double result = 0;
            List<double> data = new List<double>();
            int i = 0;
            while ((line = reader.ReadLine()) != null)
            {
                if (double.TryParse(line, out result))
                {

                    double value = Convert.ToDouble(result);
                    if (i == 1619)
                    {
                        Console.WriteLine(value);
                    }
                    //if (i > 200)
                    //{
                    //    data.Add(value);
                    //}
                    data.Add(value);
                    i++;
                }
            }
            return data;
            // 读取文件内容
        }
    }
}
