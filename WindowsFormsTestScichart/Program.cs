using System;
using System.Windows.Forms;

namespace WindowsFormsTestScichart
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            // Set this code once in App.xaml.cs or application startup
        }
    }
}
