namespace Data_Fairy_Editor
{
    partial class SplashForm
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
            this.openFileButton = new System.Windows.Forms.Button();
            this.reopenFileButton = new System.Windows.Forms.Button();
            this.newFileButton = new System.Windows.Forms.Button();
            this.splashButtonsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.exitButton = new System.Windows.Forms.Button();
            this.splashLabel = new System.Windows.Forms.Label();
            this.versionLabel = new System.Windows.Forms.Label();
            this.authorLabel = new System.Windows.Forms.Label();
            this.latestUpdatesTitle = new System.Windows.Forms.Label();
            this.releaseInfoLabel = new System.Windows.Forms.Label();
            this.commandButtonsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.splashPicture = new System.Windows.Forms.PictureBox();
            this.splashButtonsPanel.SuspendLayout();
            this.commandButtonsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splashPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileButton
            // 
            this.openFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openFileButton.Location = new System.Drawing.Point(5, 55);
            this.openFileButton.Margin = new System.Windows.Forms.Padding(5);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(150, 40);
            this.openFileButton.TabIndex = 1;
            this.openFileButton.Text = "Open File";
            this.openFileButton.UseVisualStyleBackColor = true;
            this.openFileButton.Click += new System.EventHandler(this.onOpenFileClick);
            // 
            // reopenFileButton
            // 
            this.reopenFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reopenFileButton.Location = new System.Drawing.Point(5, 105);
            this.reopenFileButton.Margin = new System.Windows.Forms.Padding(5);
            this.reopenFileButton.Name = "reopenFileButton";
            this.reopenFileButton.Size = new System.Drawing.Size(150, 40);
            this.reopenFileButton.TabIndex = 2;
            this.reopenFileButton.Text = "Reopen File";
            this.reopenFileButton.UseVisualStyleBackColor = true;
            this.reopenFileButton.Click += new System.EventHandler(this.onReopenFileClick);
            // 
            // newFileButton
            // 
            this.newFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newFileButton.Location = new System.Drawing.Point(5, 5);
            this.newFileButton.Margin = new System.Windows.Forms.Padding(5);
            this.newFileButton.Name = "newFileButton";
            this.newFileButton.Size = new System.Drawing.Size(150, 40);
            this.newFileButton.TabIndex = 0;
            this.newFileButton.Text = "New File";
            this.newFileButton.UseVisualStyleBackColor = true;
            this.newFileButton.Click += new System.EventHandler(this.onNewFileClick);
            // 
            // splashButtonsPanel
            // 
            this.splashButtonsPanel.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.splashButtonsPanel.Controls.Add(this.newFileButton);
            this.splashButtonsPanel.Controls.Add(this.openFileButton);
            this.splashButtonsPanel.Controls.Add(this.reopenFileButton);
            this.splashButtonsPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.splashButtonsPanel.Location = new System.Drawing.Point(0, 0);
            this.splashButtonsPanel.Margin = new System.Windows.Forms.Padding(9);
            this.splashButtonsPanel.Name = "splashButtonsPanel";
            this.splashButtonsPanel.Size = new System.Drawing.Size(163, 531);
            this.splashButtonsPanel.TabIndex = 3;
            // 
            // exitButton
            // 
            this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.Location = new System.Drawing.Point(386, 5);
            this.exitButton.Margin = new System.Windows.Forms.Padding(5);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(150, 40);
            this.exitButton.TabIndex = 3;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.onExitClicked);
            // 
            // splashLabel
            // 
            this.splashLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.splashLabel.AutoSize = true;
            this.splashLabel.BackColor = System.Drawing.Color.Transparent;
            this.splashLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 52F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splashLabel.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.splashLabel.Location = new System.Drawing.Point(335, 15);
            this.splashLabel.Name = "splashLabel";
            this.splashLabel.Size = new System.Drawing.Size(357, 79);
            this.splashLabel.TabIndex = 4;
            this.splashLabel.Text = "Data Fairy";
            this.splashLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // versionLabel
            // 
            this.versionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.versionLabel.BackColor = System.Drawing.Color.Transparent;
            this.versionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.versionLabel.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.versionLabel.Location = new System.Drawing.Point(349, 94);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(343, 33);
            this.versionLabel.TabIndex = 5;
            this.versionLabel.Text = "Version 1.0";
            this.versionLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // authorLabel
            // 
            this.authorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.authorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.authorLabel.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.authorLabel.Location = new System.Drawing.Point(299, 127);
            this.authorLabel.Name = "authorLabel";
            this.authorLabel.Size = new System.Drawing.Size(393, 33);
            this.authorLabel.TabIndex = 6;
            this.authorLabel.Text = "Contact data.fairy@mkv25.net";
            this.authorLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // latestUpdatesTitle
            // 
            this.latestUpdatesTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.latestUpdatesTitle.BackColor = System.Drawing.Color.Transparent;
            this.latestUpdatesTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.latestUpdatesTitle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.latestUpdatesTitle.Location = new System.Drawing.Point(175, 160);
            this.latestUpdatesTitle.Name = "latestUpdatesTitle";
            this.latestUpdatesTitle.Size = new System.Drawing.Size(198, 33);
            this.latestUpdatesTitle.TabIndex = 7;
            this.latestUpdatesTitle.Text = "Latest updates:";
            // 
            // releaseInfoLabel
            // 
            this.releaseInfoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.releaseInfoLabel.BackColor = System.Drawing.Color.Transparent;
            this.releaseInfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.releaseInfoLabel.ForeColor = System.Drawing.SystemColors.WindowText;
            this.releaseInfoLabel.Location = new System.Drawing.Point(175, 193);
            this.releaseInfoLabel.Name = "releaseInfoLabel";
            this.releaseInfoLabel.Size = new System.Drawing.Size(198, 282);
            this.releaseInfoLabel.TabIndex = 8;
            this.releaseInfoLabel.Text = "Release Info";
            // 
            // commandButtonsPanel
            // 
            this.commandButtonsPanel.Controls.Add(this.exitButton);
            this.commandButtonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.commandButtonsPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.commandButtonsPanel.Location = new System.Drawing.Point(163, 479);
            this.commandButtonsPanel.Name = "commandButtonsPanel";
            this.commandButtonsPanel.Size = new System.Drawing.Size(541, 52);
            this.commandButtonsPanel.TabIndex = 9;
            // 
            // splashPicture
            // 
            this.splashPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.splashPicture.BackgroundImage = global::Data_Fairy_Editor.Icons.daisy_the_data_fairy;
            this.splashPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.splashPicture.Location = new System.Drawing.Point(379, 163);
            this.splashPicture.Name = "splashPicture";
            this.splashPicture.Size = new System.Drawing.Size(320, 316);
            this.splashPicture.TabIndex = 10;
            this.splashPicture.TabStop = false;
            // 
            // SplashForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 531);
            this.Controls.Add(this.commandButtonsPanel);
            this.Controls.Add(this.splashButtonsPanel);
            this.Controls.Add(this.releaseInfoLabel);
            this.Controls.Add(this.latestUpdatesTitle);
            this.Controls.Add(this.authorLabel);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.splashLabel);
            this.Controls.Add(this.splashPicture);
            this.MinimumSize = new System.Drawing.Size(720, 570);
            this.Name = "SplashForm";
            this.Text = "Data Fairy";
            this.splashButtonsPanel.ResumeLayout(false);
            this.commandButtonsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splashPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openFileButton;
        private System.Windows.Forms.Button reopenFileButton;
        private System.Windows.Forms.Button newFileButton;
        private System.Windows.Forms.FlowLayoutPanel splashButtonsPanel;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label splashLabel;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Label authorLabel;
        private System.Windows.Forms.Label latestUpdatesTitle;
        private System.Windows.Forms.Label releaseInfoLabel;
        private System.Windows.Forms.FlowLayoutPanel commandButtonsPanel;
        private System.Windows.Forms.PictureBox splashPicture;
    }
}

