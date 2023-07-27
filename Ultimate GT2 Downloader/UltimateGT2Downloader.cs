// I need to rewrite this someday.
using System.Diagnostics;
using System;
using System.Net;
using System.IO;

namespace Ultimate_GT2_Downloader
{
    public partial class UltimateGT2Downloader : Form
    {
        private bool isDownloading = false;
        public string baseUrl = "https://setup.gametest2.robloxlabs.com/";
        public static string strExeFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location; // exe path
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

        private void DownloadFile(string downloadUrl)
        {
            WebClient client = new WebClient();
            client.DownloadFile(downloadUrl, "Test.exe");
        }

        private void DownloadButton_Click(object sender, EventArgs e)
        {
            string downloadLink = baseUrl + textBox1.Text;
            DownloadFile(downloadLink);
            MessageBox.Show(downloadLink);
        }

        private void InfoLabel_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}