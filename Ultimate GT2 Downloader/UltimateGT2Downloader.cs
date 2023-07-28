// I need to rewrite this someday.
using System.Diagnostics;
using System;
using System.Net;
using System.IO;
using System.Reflection;
using System.Windows.Forms.VisualStyles;
using System.Net.Http;
using System.Security.Policy;

namespace Ultimate_GT2_Downloader
{
    public partial class UltimateGT2Downloader : Form
    {
        private bool isDownloading = false;
        public string baseUrl = "http://setup.gametest2.robloxlabs.com/";
        public static string execPath = AppDomain.CurrentDomain.BaseDirectory;
        private HttpClient client = new HttpClient();
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
        private async void DownloadClient(string hash)
        {
            isDownloading = true;
            string[] clientItems = { "Roblox.exe", "RobloxApp.zip", "rbxManifest.txt", "Libraries.zip", "shaders.zip", "content-avatar.zip", "content-fonts.zip", "content-sky.zip", "content-sounds.zip", "content-textures2.zip", "content-translations.zip", "content-textures3.zip", "content-terrain.zip", "content-platform-fonts.zip" };
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
                Uri uri = new Uri(baseUrl + hash + "-" + item);
                try
                {
                    byte[] fileBytes = await client.GetByteArrayAsync(uri);
                    File.WriteAllBytes(downloadPath + item, fileBytes);
                    InfoLabel.Text = "Downloading " + item + "...";
                }
                catch
                {
                    InfoLabel.Text = "Failed to download " + item + ", retrying...";
                }
            }
            isDownloading = false;
        }
        
        private async void DownloadStudio(string hash)
        {
            isDownloading = true;
            string[] studioItems = { "RobloxStudioLauncherBeta.exe", "RobloxStudio.zip", "rbxManifest.txt", "Libraries.zip", "shaders.zip", "content-avatar.zip", "content-scripts.zip", "content-fonts.zip", "content-sky.zip", "content-sounds.zip", "content-textures2.zip", "content-translations.zip", "content-textures3.zip", "content-terrain.zip", "content-platform-fonts.zip", "BuiltInPlugins.zip"};
            bool directoryExists = System.IO.Directory.Exists(execPath + "Downloads");
            if (!directoryExists)
            {
                System.IO.Directory.CreateDirectory(execPath + "Downloads\\");
                System.IO.Directory.CreateDirectory(execPath + "Downloads\\Client\\");
                System.IO.Directory.CreateDirectory(execPath + "Downloads\\Studio\\");
            }
            string downloadPath = execPath + "\\Downloads\\Studio\\";
            foreach (string item in studioItems)
            {
                Uri uri = new Uri(baseUrl + hash + "-" + item);
                try
                {
                    byte[] fileBytes = await client.GetByteArrayAsync(uri);
                    File.WriteAllBytes(downloadPath + item, fileBytes);
                    InfoLabel.Text = "Downloading " + item + "...";
                }
                catch
                {
                    InfoLabel.Text = "Failed to download " + item;
                }
            }
            isDownloading = false;
        }

        private void DownloadButton_Click(object sender, EventArgs e)
        {
            string hash = textBox1.Text;
            if (!isDownloading)
            {
                if (comboBox1.SelectedItem.ToString() == "Client")
                {
                    DownloadClient(hash);
                }

                if (comboBox1.SelectedItem.ToString() == "Studio")
                {
                    DownloadStudio(hash);
                };
            }
        }

        private void InfoLabel_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}