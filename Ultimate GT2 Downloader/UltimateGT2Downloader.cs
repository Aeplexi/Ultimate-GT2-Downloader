// I need to rewrite this someday.
using System.Diagnostics;

namespace Ultimate_GT2_Downloader
{
    public partial class UltimateGT2Downloader : Form
    {
        private bool isDownloading = false;
        public string WinUrl = "http://setup.gametest2.robloxlabs.com/";
        public string MacUrl = "http://setup.gametest2.robloxlabs.com/mac/";
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
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://setup.gametest2.robloxlabs.com/DeployHistory.txt") { UseShellExecute = true });
        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://setup.gametest2.robloxlabs.com/Mac/DeployHistory.txt") { UseShellExecute = true });
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        // Important stuff now, not just visual stuff.

        // These are the main functions to download files.
        // Depending on your client, not every file will be there.
        private async void DownloadClient(string hash)
        {
            isDownloading = true;
            string[] clientItems = { "Roblox.exe", "RobloxApp.zip", "rbxManifest.txt", "Libraries.zip", "shaders.zip", "content-avatar.zip", "content-fonts.zip", "content-sky.zip", "content-sounds.zip", "content-textures2.zip", "content-translations.zip", "content-textures3.zip", "content-terrain.zip", "content-models.zip", "content-luapackages.zip", "content-platform-fonts.zip", "RobloxVersion.txt", "ssl.zip" };            // Make sure everything exists!
            bool directoryExists = System.IO.Directory.Exists(execPath + "Downloads");
            if (!directoryExists)
            {
                System.IO.Directory.CreateDirectory(execPath + "Downloads\\");
                System.IO.Directory.CreateDirectory(execPath + "Downloads\\Client\\");
                System.IO.Directory.CreateDirectory(execPath + "Downloads\\Studio\\");
                System.IO.Directory.CreateDirectory(execPath + "Downloads\\MacClient\\");
                System.IO.Directory.CreateDirectory(execPath + "Downloads\\MacStudio\\");
            }
            bool versionDirectoryExists = System.IO.Directory.Exists(execPath + "Downloads" + "\\Client\\" + hash);
            if (!versionDirectoryExists)
            {
                System.IO.Directory.CreateDirectory(execPath + "Downloads" + "\\Client\\" + hash);
            }
            string downloadPath = execPath + $"\\Downloads\\Client\\{hash}\\";
            foreach (string item in clientItems)
            {
                Uri uri = new Uri(WinUrl + hash + "-" + item);
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
                //InfoLabel.Text = "Success!";
            }
            isDownloading = false;
            InfoLabel.Text = "Success!";
        }



        private async void DownloadStudio(string hash)
        {
            isDownloading = true;
            string[] studioItems = { "RobloxStudioLauncherBeta.exe", "RobloxStudio.zip", "rbxManifest.txt", "Libraries.zip", "shaders.zip", "content-avatar.zip", "content-scripts.zip", "content-fonts.zip", "content-sky.zip", "content-sounds.zip", "content-textures2.zip", "content-translations.zip", "content-textures3.zip", "content-terrain.zip", "content-platform-fonts.zip", "BuiltInPlugins.zip", "Qml.zip", "Plugins.zip", "LibrariesQt5.zip", "redist.zip", "BootstrapperQTStudioVersion.txt" };
            bool directoryExists = System.IO.Directory.Exists(execPath + "Downloads");
            if (!directoryExists)
            {
                System.IO.Directory.CreateDirectory(execPath + "Downloads\\");
                System.IO.Directory.CreateDirectory(execPath + "Downloads\\Client\\");
                System.IO.Directory.CreateDirectory(execPath + "Downloads\\Studio\\");
                System.IO.Directory.CreateDirectory(execPath + "Downloads\\MacClient\\");
                System.IO.Directory.CreateDirectory(execPath + "Downloads\\MacStudio\\");
            }
            bool versionDirectoryExists = System.IO.Directory.Exists(execPath + "Downloads" + "\\Studio\\" + hash);
            if (!versionDirectoryExists)
            {
                System.IO.Directory.CreateDirectory(execPath + "Downloads" + "\\Studio\\" + hash);
            }
            string downloadPath = execPath + $"\\Downloads\\Studio\\{hash}\\";
            foreach (string item in studioItems)
            {
                Uri uri = new Uri(WinUrl + hash + "-" + item);
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
                //InfoLabel.Text = "Success!";
            }
            InfoLabel.Text = "Success!";
            isDownloading = false;
        }
        private async void DownloadMacClient(string hash)
        {
            isDownloading = true;
            string[] clientItems = { "Roblox.dmg", "RobloxPlayer.zip" };
            bool directoryExists = System.IO.Directory.Exists(execPath + "Downloads");
            if (!directoryExists)
            {
                System.IO.Directory.CreateDirectory(execPath + "Downloads\\");
                System.IO.Directory.CreateDirectory(execPath + "Downloads\\Client\\");
                System.IO.Directory.CreateDirectory(execPath + "Downloads\\Studio\\");
                System.IO.Directory.CreateDirectory(execPath + "Downloads\\MacClient\\");
                System.IO.Directory.CreateDirectory(execPath + "Downloads\\MacStudio\\");
            }
            bool versionDirectoryExists = System.IO.Directory.Exists(execPath + "Downloads" + "\\MacClient\\" + hash);
            if (!versionDirectoryExists)
            {
                System.IO.Directory.CreateDirectory(execPath + "Downloads" + "\\MacClient\\" + hash);
            }
            string downloadPath = execPath + $"\\Downloads\\MacClient\\{hash}\\";
            foreach (string item in clientItems)
            {
                Uri uri = new Uri(MacUrl + hash + "-" + item);
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
            InfoLabel.Text = "Success!";
        }
        private async void DownloadMacStudio(string hash)
        {
            isDownloading = true;
            string[] studioItems = { "RobloxStudio.dmg", "RobloxStudioApp.zip" };
            bool directoryExists = System.IO.Directory.Exists(execPath + "Downloads");
            if (!directoryExists)
            {
                System.IO.Directory.CreateDirectory(execPath + "Downloads\\");
                System.IO.Directory.CreateDirectory(execPath + "Downloads\\Client\\");
                System.IO.Directory.CreateDirectory(execPath + "Downloads\\Studio\\");
                System.IO.Directory.CreateDirectory(execPath + "Downloads\\MacClient\\");
                System.IO.Directory.CreateDirectory(execPath + "Downloads\\MacStudio\\");
            }
            bool versionDirectoryExists = System.IO.Directory.Exists(execPath + "Downloads" + "\\MacStudio\\" + hash);
            if (!versionDirectoryExists)
            {
                System.IO.Directory.CreateDirectory(execPath + "Downloads" + "\\MacStudio\\" + hash);
            }
            string downloadPath = execPath + $"\\Downloads\\MacStudio\\{hash}\\";
            foreach (string item in studioItems)
            {
                Uri uri = new Uri(WinUrl + hash + "-" + item);
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
            InfoLabel.Text = "Success!";
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

                if (comboBox1.SelectedItem.ToString() == "Mac Client")
                {
                    DownloadMacClient(hash);
                }
                if (comboBox1.SelectedItem.ToString() == "Mac Studio")
                {
                    DownloadMacStudio(hash);
                }


            }
        }

        private void InfoLabel_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}