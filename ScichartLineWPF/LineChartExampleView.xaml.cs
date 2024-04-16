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
            SciChartSurface.SetRuntimeLicenseKey("dhHMy3VOANfBbbpRfBSNXxFWsOZK7Sf8pjtvqy80GNg1Pk9A1/9ZQg15VOYMho+kT1YElOEiKz9aOUMjmuYW+5jObw7zl05MCJ6benZ4hlsVZxsOzsP/W6LEbb2gf4nEzAJlwwpdw7Ywsvm1Rxqplz85FsDf/DpnTWYIjGj/llM8aigEqBWnf2HOsQ1obmiMLc5+s/9ItKZTAIVep2ZAVYeB9+e2j+BQ2yYtUCENP4gXV8a70muAC5HaPmbKZWrtJfiAZBv1ef8fHBq7pqblgfDlKfHdkbOJPIqUJKSjN0DxPMAQ9Zu4NBPhZAmcEDy6hbobLBsY2CovvDWGXpFkywHBH6XvllakvmuinUcfY5NJ6pWgbQg40yOQSbytbDksWIuUmBYGKOVD2yCWT6b+oimX/biIBl2kE0zvTnFJ2EDAPLSH4VxIcg4lyKTG/5CHXmJhZ1IsejY6g6keqBdOj0BROySn9D6DIJ9A7wf9Sj/8Oj8E5TVkpfZdMLf5LmTp6WktlTNhG1IP5Xa2sjb4eLLILqWc5dDC7n7jaLHcutwpmAuKTBVfLFR4dfkq");
            InitializeComponent();
            fastLineRenderableSeries = new List<FastLineRenderableSeries>();
        }

        private void LineChartExampleView_OnLoaded(object sender, RoutedEventArgs e)
        {
            // Set some data
            var chromData = GetChromData();
            for (int i = 0; i < 10; i++)
            {
                var dataSeries2 = new XyDataSeries<double, double>();
                var lineSeries = new FastLineRenderableSeries()
                {
                    Stroke = Colors.OrangeRed,
                    StrokeThickness = 2,
                    AntiAliasing = true,
                };
                fastLineRenderableSeries.Add(lineSeries);
                sciChart.RenderableSeries.Add(lineSeries);
                foreach (var data in chromData)
                {
                    dataSeries2.Append(data.Key, data.Value);
                }
                lineSeries.DataSeries = dataSeries2;
            }
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
        public void SetSignalLineColor(int index,Color color)
        {
            fastLineRenderableSeries[index].Stroke = color;
        }

        /// <summary>
        /// 设置X轴的坐标范围
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public void SetXAxisRange(double min,double max)
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

        private Dictionary<double, double> GetChromData()
        {
            string filePath = "D:\\Work\\色谱网络\\反相标样1.csv";
            var reader = new StreamReader(filePath);
            string line;

            Dictionary<double, double> keyValuePairs = new Dictionary<double, double>();

            while ((line = reader.ReadLine()) != null)
            {
                string[] values = line.Split(',');

                if (values.Length == 2)
                {
                    double time = Convert.ToDouble(values[0]);
                    double signal = Convert.ToDouble(values[1]);
                    keyValuePairs.Add(time, signal);
                }
            }
            return keyValuePairs;
            // 读取文件内容
        }
    }
}
