using System;
using System.Windows.Forms;

namespace Ultimate_GT2_Downloader
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new UltimateGT2Downloader());
        }
    }
}
