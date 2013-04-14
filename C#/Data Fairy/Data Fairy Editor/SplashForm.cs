using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Data_Fairy_Editor
{
    public delegate void UIEventHandler();

    public partial class SplashForm : Form
    {
        public SplashForm()
        {
            InitializeComponent();

            this.Icon = Icons.data_fairy;

            var releaseChanges = new List<string>();
            releaseChanges.Add("R4 - PHP Code Templates");
            releaseChanges.Add("R3 - Haxe Code Templates, ClickOnce deployment");
            releaseChanges.Add("R2 - C# Code Templates");
            releaseChanges.Add("R1 - Schema Editing Tool and Code Generation");

            StringBuilder builder = new StringBuilder();
            foreach (var line in releaseChanges)
                builder.AppendLine(line);
            releaseInfoLabel.Text = builder.ToString();
            
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        public event UIEventHandler RequestNewFile;
        public event UIEventHandler RequestOpenFile;
        public event UIEventHandler RequestReopenFile;
        public event UIEventHandler RequestExit;

        private void onNewFileClick(object sender, EventArgs e)
        {
            if (RequestNewFile != null)
                RequestNewFile();
        }

        private void onOpenFileClick(object sender, EventArgs e)
        {
            if (RequestOpenFile != null)
                RequestOpenFile();
        }

        private void onReopenFileClick(object sender, EventArgs e)
        {
            if (RequestReopenFile != null)
                RequestReopenFile();
        }

        private void onExitClicked(object sender, EventArgs e)
        {
            if (RequestExit != null)
                RequestExit();
        }
    }
}
