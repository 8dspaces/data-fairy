using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using net.mkv25.writer;
using System.IO;
using Microsoft.Win32;
using Data_Fairy_Editor.Properties;
using System.Diagnostics;

namespace Data_Fairy_Editor
{
    public partial class CodeExportForm : Form
    {
        public DataSet SourceDataSet;

        protected StringBuilder reporterLog;
        protected Stopwatch exportTimer;

        public CodeExportForm()
        {
            InitializeComponent();

            outputDirectoryInput.Text = (string) Settings.Default["CodeExportOutputPath"];
            packageTextInput.Text = (string) Settings.Default["CodeExportPackage"];

            LoadTemplateList();
        }

        private void LoadTemplateList()
        {
            string templatesPath = null;

            // clear down warnings
            if (TemplateWriterConfig.Warnings != null)
                TemplateWriterConfig.Warnings.Clear();

            // find code templates directory
            if (Directory.Exists("./Code Templates"))
                templatesPath = "./Code Templates";
            else if (Directory.Exists("../../../../Code Templates"))
                templatesPath = "../../../../Code Templates";

            // tell the user if there's no path
            if (String.IsNullOrEmpty(templatesPath))
            {
                MessageBox.Show(String.Format("Could not find the Code Templates directory, unable to run the Code Exporter."),
                    "No templates found...",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                Close();
                return;
            }

            // scan the directory
            var directoryList = Directory.EnumerateDirectories(templatesPath);
            var options = new List<KeyValuePair<string, TemplateWriter>>();
            foreach (var item in directoryList)
            {
                TemplateWriter template = TemplateWriterConfig.LoadFromDirectory(item);
                if(template != null)
                    options.Add(new KeyValuePair<string, TemplateWriter>(template.name, template));
            }
            templateComboBox.DataSource = options;
            templateComboBox.DisplayMember = "Key";
            templateComboBox.ValueMember = "Value";

            // lock out the export option
            if (options.Count == 0)
            {
                exportButton.Enabled = false;
            }

            // report any warnings
            if (TemplateWriterConfig.Warnings != null)
            {
                var warnings = new StringBuilder();
                warnings.AppendLine("Errors occurred while loading templates:");
                foreach (var warning in TemplateWriterConfig.Warnings)
                {
                    warnings.AppendLine(warning);
                }
                reportBox.Text = warnings.ToString();
            }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            var template = (TemplateWriter)templateComboBox.SelectedValue;

            exportTimer = new Stopwatch();
            exportTimer.Start();

            reporterLog = new StringBuilder();
            reporterLog.AppendLine(String.Format("Started export  {0}", template.name));
            reportBox.Text = reporterLog.ToString();

            BackgroundWorker exporterThread = new BackgroundWorker();
            exporterThread.DoWork += new DoWorkEventHandler(exporterThread_DoWork);
            exporterThread.ProgressChanged += new ProgressChangedEventHandler(exporterThread_ProgressChanged);
            exporterThread.RunWorkerCompleted += new RunWorkerCompletedEventHandler(exporterThread_RunWorkerCompleted);
            exporterThread.RunWorkerAsync(template);
            exportButton.Enabled = false;
        }

        void exporterThread_DoWork(object sender, DoWorkEventArgs e)
        {
            TemplateWriter template = (TemplateWriter)e.Argument;
            if (template != null)
            {
                template.sourceDataSet = SourceDataSet;
                template.packageString = packageTextInput.Text;
                template.WriteTo(outputDirectoryInput.Text);

                foreach(var message in template.logMessages)
                {
                    reporterLog.AppendLine(String.Format("{0}: {1}", message.Key, message.Value));
                }
            }
        }

        void exporterThread_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // chill
        }

        void exporterThread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            exportTimer.Stop();
            reporterLog.AppendLine(String.Format("Code Export Completed, time taken: {0} ms", exportTimer.ElapsedMilliseconds));
            reportBox.Text = reporterLog.ToString();
            exportButton.Enabled = true;
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            var FolderBrowser = new FolderBrowserDialog();
            FolderBrowser.SelectedPath = outputDirectoryInput.Text;

            var result = FolderBrowser.ShowDialog(this);
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                outputDirectoryInput.Text = FolderBrowser.SelectedPath;
                Settings.Default["CodeExportOutputPath"] = outputDirectoryInput.Text;
                Settings.Default["CodeExportPackage"] = packageTextInput.Text;
                Settings.Default.Save();
            }
        }
    }
}
