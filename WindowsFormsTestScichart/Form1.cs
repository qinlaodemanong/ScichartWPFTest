using ScichartLineWPF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Windows.Media;

namespace WindowsFormsTestScichart
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeWpfControl();
        }

        private void InitializeWpfControl()
        {
            Create2DChart();
        }

        private void Create2DChart()
        {
            ElementHost elementHost = new ElementHost();
            elementHost.Dock = DockStyle.Fill;

            LineChartExampleView lineChartExampleView = new LineChartExampleView();
            elementHost.Child = lineChartExampleView;
            tableLayoutPanel1.Controls.Add(elementHost);
            lineChartExampleView.CreateBugLine();

            ElementHost elementHost2 = new ElementHost();
            elementHost2.Dock = DockStyle.Fill;

            LineChartExampleView lineChartExampleView2 = new LineChartExampleView();
            elementHost2.Child = lineChartExampleView2;
            tableLayoutPanel1.Controls.Add(elementHost2);
            lineChartExampleView2.CreateOkLine();
        }
    }

        

        //private void Create3DChart()
        //{
        //    ElementHost elementHost = new ElementHost();
        //    elementHost.Dock = DockStyle.Fill;

        //    PDA3DChart pDA3DChart = new PDA3DChart();
        //    int xSize = 25;
        //    int zSize = 25;
        //    List<List<double>> data = new List<List<double>>();
        //    for (int z = 0; z < zSize; z++)
        //    {
        //        data.Add(new List<double>());
        //        for (int x = 0; x < xSize; x++)
        //        {
        //            double xVal = (double)x / (double)xSize * 25.0;
        //            double zVal = (double)z / (double)zSize * 25.0;
        //            double y = Math.Sin(xVal * 0.2) / ((zVal + 1) * 2);
        //            data[z].Add(y);
        //        }
        //    }
        //    pDA3DChart.AddData(data);
        //    elementHost.Child = pDA3DChart;
        //    Controls.Add(elementHost);

        //}

        //private void CreateContourLineChart()
        //{
        //    ElementHost elementHost = new ElementHost();
        //    elementHost.Dock = DockStyle.Fill;

        //    PDAContourLineChart contourLineChart = new PDAContourLineChart();
        //    var seed = SeriesAnimationBase.GlobalEnableAnimations ? (Environment.TickCount << 0) : 0;
        //    var random = new Random(seed);
        //    double angle = Math.Round(Math.PI * 2 * 0, 3) / 100;

        //    int w = 300, h = 200;
        //    var data = new double[h, w];
        //    for (int x = 0; x < w; x++)
        //    {
        //        for (int y = 0; y < h; y++)
        //        {
        //            var v = (1 + Math.Round(Math.Sin(x * 0.04 + angle), 3)) * 50 + (1 + Math.Round(Math.Sin(y * 0.1 + angle), 3)) * 50 * (1 + Math.Round(Math.Sin(angle * 2), 3));
        //            var cx = w / 2; var cy = h / 2;
        //            var r = Math.Sqrt((x - cx) * (x - cx) + (y - cy) * (y - cy));
        //            var exp = Math.Max(0, 1 - r * 0.008);
        //            var zValue = (v * exp + random.NextDouble() * 10);
        //            data[y, x] = (zValue > 200) ? 200 : zValue;
        //        }
        //    }

        //    contourLineChart.CreateSeries(data,0,1,0,1);
        //    elementHost.Child = contourLineChart;
        //    Controls.Add(elementHost);
        //}

}
