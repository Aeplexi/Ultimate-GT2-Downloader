namespace Ultimate_GT2_Downloader
{
    partial class UltimateGT2Downloader
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            textBox1 = new TextBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            linkLabel1 = new LinkLabel();
            comboBox1 = new ComboBox();
            label1 = new Label();
            DownloadButton = new Button();
            InfoLabel = new Label();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.DarkGreen;
            textBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            textBox1.ForeColor = SystemColors.Window;
            textBox1.Location = new Point(12, 25);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(364, 23);
            textBox1.TabIndex = 0;
            textBox1.Text = "Enter the version hash here.";
            textBox1.TextAlign = HorizontalAlignment.Center;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            linkLabel1.LinkColor = SystemColors.MenuHighlight;
            linkLabel1.Location = new Point(28, 253);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(337, 17);
            linkLabel1.TabIndex = 1;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "http://setup.gametest2.robloxlabs.com/DeployHistory.txt\r\n";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Client", "Studio" });
            comboBox1.Location = new Point(129, 82);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 2;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(73, 85);
            label1.Name = "label1";
            label1.Size = new Size(34, 15);
            label1.TabIndex = 3;
            label1.Text = "Type:";
            label1.Click += label1_Click_1;
            // 
            // DownloadButton
            // 
            DownloadButton.BackColor = Color.Teal;
            DownloadButton.ForeColor = Color.White;
            DownloadButton.Location = new Point(97, 161);
            DownloadButton.Name = "DownloadButton";
            DownloadButton.Size = new Size(182, 30);
            DownloadButton.TabIndex = 4;
            DownloadButton.Text = "Download";
            DownloadButton.UseVisualStyleBackColor = false;
            DownloadButton.Click += DownloadButton_Click;
            // 
            // InfoLabel
            // 
            InfoLabel.AutoSize = true;
            InfoLabel.Location = new Point(117, 130);
            InfoLabel.Name = "InfoLabel";
            InfoLabel.Size = new Size(142, 15);
            InfoLabel.TabIndex = 5;
            InfoLabel.Text = "No info to show currently";
            InfoLabel.Click += InfoLabel_Click;
            // 
            // UltimateGT2Downloader
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(388, 289);
            Controls.Add(InfoLabel);
            Controls.Add(DownloadButton);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Controls.Add(linkLabel1);
            Controls.Add(textBox1);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "UltimateGT2Downloader";
            Text = "Ultimate GT2 Downloader";
            Load += UltimateGT2Downloader_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private ContextMenuStrip contextMenuStrip1;
        private LinkLabel linkLabel1;
        private ComboBox comboBox1;
        private Label label1;
        private Button DownloadButton;
        private Label InfoLabel;
    }
}