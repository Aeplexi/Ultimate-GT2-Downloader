using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Windows.Forms;

namespace Ultimate_GT2_Downloader
{
    public class UltimateGT2Downloader : Form
    {
        private bool isDownloading;

        public string WinUrl = "http://setup.gametest2.robloxlabs.com/";

        public string MacUrl = "http://setup.gametest2.robloxlabs.com/mac/";

        public static string execPath = AppDomain.CurrentDomain.BaseDirectory;

        private HttpClient client = new HttpClient();

        private IContainer components;

        private TextBox textBox1;

        private ContextMenuStrip contextMenuStrip1;

        private LinkLabel linkLabel1;

        private ComboBox comboBox1;

        private Label label1;

        private Button DownloadButton;

        private Label InfoLabel;

        private Label label2;

        private LinkLabel linkLabel2;

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
            Process.Start(new ProcessStartInfo("https://setup.gametest2.robloxlabs.com/DeployHistory.txt")
            {
                UseShellExecute = true
            });
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://setup.gametest2.robloxlabs.com/mac/DeployHistory.txt")
            {
                UseShellExecute = true
            });
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
        }

        private async void DownloadClient(string hash)
        {
            isDownloading = true;
            string[] array = new string[24]
		{
			"Roblox.exe", "RobloxApp.zip", "rbxManifest.txt", "Libraries.zip", "shaders.zip", "content-avatar.zip", "content-fonts.zip", "content-sky.zip", "content-sounds.zip", "content-textures2.zip",
			"content-translations.zip", "content-textures3.zip", "content-terrain.zip", "content-models.zip", "content-luapackages.zip", "content-platform-fonts.zip", "RobloxVersion.txt", "ssl.zip", "RobloxProxy.zip", 
            "NPRobloxProxy.zip", "redist.zip", "content-music.zip", "content-particles.zip", "content-textures.zip"
		};
            if (!Directory.Exists(execPath + "Downloads"))
            {
                Directory.CreateDirectory(execPath + "Downloads\\");
                Directory.CreateDirectory(execPath + "Downloads\\Client\\");
                Directory.CreateDirectory(execPath + "Downloads\\Studio\\");
                Directory.CreateDirectory(execPath + "Downloads\\MacClient\\");
                Directory.CreateDirectory(execPath + "Downloads\\MacStudio\\");
            }
            if (!Directory.Exists(execPath + "Downloads\\Client\\" + hash))
            {
                Directory.CreateDirectory(execPath + "Downloads\\Client\\" + hash);
            }
            string downloadPath = execPath + "\\Downloads\\Client\\" + hash + "\\";
            string[] array2 = array;
            foreach (string item in array2)
            {
                Uri requestUri = new Uri(WinUrl + hash + "-" + item);
                try
                {
                    byte[] bytes = await client.GetByteArrayAsync(requestUri);
                    string item1 = hash + "-" + item;
                    File.WriteAllBytes(downloadPath + item1, bytes);
                    InfoLabel.Text = "Downloading " + item1 + "...";
                }
                catch
                {
                    InfoLabel.Text = "Failed to download " + item + ", retrying...";
                }
            }
            isDownloading = false;
            InfoLabel.Text = "Success!";
        }

        private async void DownloadStudio(string hash)
        {
            isDownloading = true;
            string[] array = new string[25]
		{
			"RobloxStudioLauncherBeta.exe", "RobloxStudio.zip", "rbxManifest.txt", "Libraries.zip", "shaders.zip", "content-avatar.zip", "content-scripts.zip", "content-fonts.zip", "content-sky.zip", "content-sounds.zip",
			"content-textures2.zip", "content-translations.zip", "content-textures3.zip", "content-music.zip", "content-terrain.zip", "content-platform-fonts.zip", "BuiltInPlugins.zip", "Qml.zip", "Plugins.zip", "LibrariesQt5.zip", "redist.zip",
			"BootstrapperQTStudioVersion.txt", "content-particles.zip", "content-textures.zip", "imageformats.zip"
		};
            if (!Directory.Exists(execPath + "Downloads"))
            {
                Directory.CreateDirectory(execPath + "Downloads\\");
                Directory.CreateDirectory(execPath + "Downloads\\Client\\");
                Directory.CreateDirectory(execPath + "Downloads\\Studio\\");
                Directory.CreateDirectory(execPath + "Downloads\\MacClient\\");
                Directory.CreateDirectory(execPath + "Downloads\\MacStudio\\");
            }
            if (!Directory.Exists(execPath + "Downloads\\Studio\\" + hash))
            {
                Directory.CreateDirectory(execPath + "Downloads\\Studio\\" + hash);
            }
            string downloadPath = execPath + "\\Downloads\\Studio\\" + hash + "\\";
            string[] array2 = array;
            foreach (string item in array2)
            {
                Uri requestUri = new Uri(WinUrl + hash + "-" + item);
                try
                {
                    byte[] bytes = await client.GetByteArrayAsync(requestUri);
                    string item1 = hash + "-" + item;
                    File.WriteAllBytes(downloadPath + item1, bytes);
                    InfoLabel.Text = "Downloading " + item1 + "...";
                }
                catch
                {
                    InfoLabel.Text = "Failed to download " + item;
                }
            }
            InfoLabel.Text = "Success!";
            isDownloading = false;
        }

        private async void DownloadMacClient(string hash)
        {
            isDownloading = true;
            string[] array = new string[2] { "Roblox.dmg", "RobloxPlayer.zip" };
            if (!Directory.Exists(execPath + "Downloads"))
            {
                Directory.CreateDirectory(execPath + "Downloads\\");
                Directory.CreateDirectory(execPath + "Downloads\\Client\\");
                Directory.CreateDirectory(execPath + "Downloads\\Studio\\");
                Directory.CreateDirectory(execPath + "Downloads\\MacClient\\");
                Directory.CreateDirectory(execPath + "Downloads\\MacStudio\\");
            }
            if (!Directory.Exists(execPath + "Downloads\\MacClient\\" + hash))
            {
                Directory.CreateDirectory(execPath + "Downloads\\MacClient\\" + hash);
            }
            string downloadPath = execPath + "\\Downloads\\MacClient\\" + hash + "\\";
            string[] array2 = array;
            foreach (string item in array2)
            {
                Uri requestUri = new Uri(MacUrl + hash + "-" + item);
                try
                {
                    byte[] bytes = await client.GetByteArrayAsync(requestUri);
                    File.WriteAllBytes(downloadPath + item, bytes);
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
            string[] array = new string[2] { "RobloxStudio.dmg", "RobloxStudioApp.zip" };
            if (!Directory.Exists(execPath + "Downloads"))
            {
                Directory.CreateDirectory(execPath + "Downloads\\");
                Directory.CreateDirectory(execPath + "Downloads\\Client\\");
                Directory.CreateDirectory(execPath + "Downloads\\Studio\\");
                Directory.CreateDirectory(execPath + "Downloads\\MacClient\\");
                Directory.CreateDirectory(execPath + "Downloads\\MacStudio\\");
            }
            if (!Directory.Exists(execPath + "Downloads\\MacStudio\\" + hash))
            {
                Directory.CreateDirectory(execPath + "Downloads\\MacStudio\\" + hash);
            }
            string downloadPath = execPath + "\\Downloads\\MacStudio\\" + hash + "\\";
            string[] array2 = array;
            foreach (string item in array2)
            {
                Uri requestUri = new Uri(MacUrl + hash + "-" + item);
                try
                {
                    byte[] bytes = await client.GetByteArrayAsync(requestUri);
                    File.WriteAllBytes(downloadPath + item, bytes);
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
            string text = textBox1.Text;
            if (!isDownloading)
            {
                if (comboBox1.SelectedItem == null || string.IsNullOrEmpty(comboBox1.SelectedItem.ToString()))
                {
                    MessageBox.Show("Please Select a Client Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (text == null || string.IsNullOrEmpty(text))
                {
                    MessageBox.Show("Please Type a Version Hash", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (comboBox1.SelectedItem.ToString() == "Client")
                    {
                        DownloadClient(text);
                    }
                    if (comboBox1.SelectedItem.ToString() == "Studio")
                    {
                        DownloadStudio(text);
                    }
                    if (comboBox1.SelectedItem.ToString() == "Mac Client")
                    {
                        DownloadMacClient(text);
                    }
                    if (comboBox1.SelectedItem.ToString() == "Mac Studio")
                    {
                        DownloadMacStudio(text);
                    }
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

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UltimateGT2Downloader));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DownloadButton = new System.Windows.Forms.Button();
            this.InfoLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Snow;
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBox1.Name = "textBox1";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            // 
            // linkLabel1
            // 
            resources.ApplyResources(this.linkLabel1, "linkLabel1");
            this.linkLabel1.LinkColor = System.Drawing.SystemColors.MenuHighlight;
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.TabStop = true;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.SystemColors.Window;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.comboBox1, "comboBox1");
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            resources.GetString("comboBox1.Items"),
            resources.GetString("comboBox1.Items1"),
            resources.GetString("comboBox1.Items2"),
            resources.GetString("comboBox1.Items3")});
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // DownloadButton
            // 
            this.DownloadButton.BackColor = System.Drawing.Color.Gainsboro;
            resources.ApplyResources(this.DownloadButton, "DownloadButton");
            this.DownloadButton.ForeColor = System.Drawing.Color.Black;
            this.DownloadButton.Name = "DownloadButton";
            this.DownloadButton.UseVisualStyleBackColor = false;
            this.DownloadButton.Click += new System.EventHandler(this.DownloadButton_Click);
            // 
            // InfoLabel
            // 
            resources.ApplyResources(this.InfoLabel, "InfoLabel");
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.UseCompatibleTextRendering = true;
            this.InfoLabel.Click += new System.EventHandler(this.InfoLabel_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // linkLabel2
            // 
            resources.ApplyResources(this.linkLabel2, "linkLabel2");
            this.linkLabel2.LinkColor = System.Drawing.SystemColors.MenuHighlight;
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.TabStop = true;
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            this.label3.Click += new System.EventHandler(this.label3_Click_1);
            // 
            // UltimateGT2Downloader
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.InfoLabel);
            this.Controls.Add(this.DownloadButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "UltimateGT2Downloader";
            this.Load += new System.EventHandler(this.UltimateGT2Downloader_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private Label label3;

        private void label3_Click_1(object sender, EventArgs e)
        {

        }
    }
}