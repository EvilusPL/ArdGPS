namespace ArdGPS
{
    partial class About
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.infoLabel = new System.Windows.Forms.Label();
            this.progLogo = new System.Windows.Forms.PictureBox();
            this.emailLabel = new System.Windows.Forms.Label();
            this.emailLink = new System.Windows.Forms.LinkLabel();
            this.homepageLabel = new System.Windows.Forms.Label();
            this.homepageLink = new System.Windows.Forms.LinkLabel();
            this.okButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.progLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Location = new System.Drawing.Point(71, 43);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(248, 52);
            this.infoLabel.TabIndex = 0;
            this.infoLabel.Text = "ArdGPS v1.0 (ArdGPS Data Analyzer)\r\n©2017 Jarosław Rauza, University of Zielona G" +
    "óra\r\n\r\nLicensed under GNU General Public License";
            // 
            // progLogo
            // 
            this.progLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.progLogo.Image = ((System.Drawing.Image)(resources.GetObject("progLogo.Image")));
            this.progLogo.Location = new System.Drawing.Point(3, 30);
            this.progLogo.Name = "progLogo";
            this.progLogo.Size = new System.Drawing.Size(62, 65);
            this.progLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.progLogo.TabIndex = 1;
            this.progLogo.TabStop = false;
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(12, 108);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(38, 13);
            this.emailLabel.TabIndex = 2;
            this.emailLabel.Text = "E-mail:";
            // 
            // emailLink
            // 
            this.emailLink.AutoSize = true;
            this.emailLink.Location = new System.Drawing.Point(71, 108);
            this.emailLink.Name = "emailLink";
            this.emailLink.Size = new System.Drawing.Size(104, 13);
            this.emailLink.TabIndex = 3;
            this.emailLink.TabStop = true;
            this.emailLink.Text = "dynamio@gmail.com";
            this.emailLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.emailLink_LinkClicked);
            // 
            // homepageLabel
            // 
            this.homepageLabel.AutoSize = true;
            this.homepageLabel.Location = new System.Drawing.Point(12, 131);
            this.homepageLabel.Name = "homepageLabel";
            this.homepageLabel.Size = new System.Drawing.Size(62, 13);
            this.homepageLabel.TabIndex = 4;
            this.homepageLabel.Text = "Homepage:";
            // 
            // homepageLink
            // 
            this.homepageLink.AutoSize = true;
            this.homepageLink.Location = new System.Drawing.Point(71, 131);
            this.homepageLink.Name = "homepageLink";
            this.homepageLink.Size = new System.Drawing.Size(115, 13);
            this.homepageLink.TabIndex = 5;
            this.homepageLink.TabStop = true;
            this.homepageLink.Text = "http://evilus.sytes.net/";
            this.homepageLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.homepageLink_LinkClicked);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(111, 160);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 6;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 195);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.homepageLink);
            this.Controls.Add(this.homepageLabel);
            this.Controls.Add(this.emailLink);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.progLogo);
            this.Controls.Add(this.infoLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            this.Text = "About ArdGPS";
            ((System.ComponentModel.ISupportInitialize)(this.progLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.PictureBox progLogo;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.LinkLabel emailLink;
        private System.Windows.Forms.Label homepageLabel;
        private System.Windows.Forms.LinkLabel homepageLink;
        private System.Windows.Forms.Button okButton;
    }
}