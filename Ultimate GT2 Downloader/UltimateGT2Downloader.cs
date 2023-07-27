// I need to rewrite this someday.
using System.Diagnostics;
using System;
using System.Net;
using System.IO;
using System.Reflection;
using System.Windows.Forms.VisualStyles;

namespace Ultimate_GT2_Downloader
{
    public partial class UltimateGT2Downloader : Form
    {
        private bool isDownloading = false;
        public string baseUrl = "http://setup.gametest2.robloxlabs.com/";
        public static string execPath = AppDomain.CurrentDomain.BaseDirectory;
        private WebClient client = new WebClient();
        public UltimateGT2Downloader()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void UltimateGT2Downloader_Load(object sender, EventArgs e)
        {

        }

        private void VisitLink()
        {
            // Change the color of the link text by setting LinkVisited
            // to true.
            linkLabel1.LinkVisited = true;
            //Call the Process.Start method to open the default browser
            //with a URL:
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "cmd",
                Arguments = "/c start https://setup.gametest2.robloxlabs.com/DeployHistory.txt"
            };
            Process.Start(psi);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            VisitLink();
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        // Important stuff now, not just visual stuff.

        // These are the main functions to download files.
        private void DownloadClient(string hash)
        {
            string[] clientItems = { "Roblox.exe" };
            // Make sure everything exists!
            bool directoryExists = System.IO.Directory.Exists(execPath + "Downloads");
            if (!directoryExists)
            {
                System.IO.Directory.CreateDirectory(execPath + "Downloads\\");
                System.IO.Directory.CreateDirectory(execPath + "Downloads\\Client\\");
                System.IO.Directory.CreateDirectory(execPath + "Downloads\\Studio\\");
            }
            string downloadPath = execPath + "\\Downloads\\Client\\";
            foreach (string item in clientItems)
            {
                try
                {
                    client.DownloadFileTaskAsync(baseUrl + hash + "-" + item, downloadPath + item); // Works i guess? Not very efficient method
                }
                catch
                {
                    InfoLabel.Text = "Failed to download " + item;
                }
            }
        }

        private void DownloadButton_Click(object sender, EventArgs e)
        {
            string hash = textBox1.Text;
            DownloadClient(hash);
        }

        private void InfoLabel_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}