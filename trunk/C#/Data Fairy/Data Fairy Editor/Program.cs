using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using net.mkv25.DataFairy.VO;
using net.mkv25.DataFairy.IO;
using System.IO;
using Data_Fairy_Editor.Properties;

namespace Data_Fairy_Editor
{
    class Program
    {
        public SplashForm Splash;
        public EditorForm Editor;
        public SchemaForm Schema;
        public CodeExportForm CodeExport;

        public string FileFilterString = "XML Data Fairy File (*.xml)|*.xml";
        public string ErrorLogFile = "errors.log";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var program = new Program();
            Application.Run(program.Splash);
        }

        public Program()
        {
            Splash = new SplashForm();

            Splash.RequestExit += new UIEventHandler(Splash_RequestExit);
            Splash.RequestNewFile += new UIEventHandler(Splash_RequestNewFile);
            Splash.RequestOpenFile += new UIEventHandler(Splash_RequestOpenFile);
            Splash.RequestReopenFile += new UIEventHandler(Splash_RequestReopenFile);
        }

        void Splash_RequestReopenFile()
        {
            var fileName = (string)Settings.Default["EditorLastOpenedFile"];

            if (String.IsNullOrEmpty(fileName))
            {
                MessageBox.Show("No file has been opened yet",
                    "Reopen last file",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                OpenFile(fileName);
            }
        }

        void Splash_RequestOpenFile()
        {
            var openDialog = new OpenFileDialog();
            openDialog.Multiselect = false;
            openDialog.Filter = FileFilterString;

            var result = openDialog.ShowDialog(Splash);
            if (result == DialogResult.OK)
            {
                var fileName = openDialog.FileName;
                OpenFile(fileName);
            }
        }

        void OpenFile(string fileName)
        {
            var file = DataFairyRead.readFile(fileName);

            if (DataFairyRead.Warnings.Count > 0)
            {
                var log = new StreamWriter(ErrorLogFile);
                log.WriteLine(String.Format("Errors while reading {0}.", fileName));
                foreach (var warning in DataFairyRead.Warnings)
                    log.WriteLine(warning);
                log.Close();

                MessageBox.Show(String.Format("Warning! There were {0} error(s) reading the file. Errors have been logged to {1} in the application directory.", DataFairyRead.Warnings.Count, ErrorLogFile),
                    "Errors While Reading File",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            Editor = new EditorForm();
            Editor.CurrentFile = file;
            Settings.Default["EditorLastOpenedFile"] = fileName;
            Settings.Default.Save();

            ShowEditor();
        }

        void Splash_RequestNewFile()
        {
            Editor = new EditorForm();
            Editor.CurrentFile = new DataFairyFile();

            ShowEditor();
        }

        void ShowEditor()
        {
            Editor.FormClosed += new FormClosedEventHandler(Editor_FormClosed);
            Editor.RequestSaveFile += new UIEventHandler(Editor_RequestSaveFile);
            Editor.RequestNewTable += new UIEventHandler(Editor_RequestNewTable);
            Editor.RequestUpdate += new UIEventHandler(Editor_RequestUpdate);
            Editor.RequestEditTable += new UIEventHandler(Editor_RequestEditTable);
            Editor.RequestExportCode += new UIEventHandler(Editor_RequestExportCode);
            Editor.UpdateViews();
            Editor.Show(Splash);

            Splash.Hide();
        }

        void Editor_FormClosed(object sender, FormClosedEventArgs e)
        {
            Splash.Show();
        }

        void Editor_RequestNewTable()
        {
            // create and add the new table
            var newTable = new DataFairyTable();
            newTable.Schema.TableName = "Table#" + (1000 + Editor.CurrentFile.Tables.Count + 1);
            Editor.CurrentTable = newTable;

            // forward to edit table command
            Editor_RequestEditTable();
        }

        void Editor_RequestEditTable()
        {
            // make a new schema form
            Schema = new SchemaForm();
            Schema.CurrentFile = Editor.CurrentFile;
            Schema.CurrentTable = Editor.CurrentTable;
            Schema.RequestSaveTable += new UIEventHandler(schemaForm_RequestSaveTable);
            Schema.RequestDeleteTable += new UIEventHandler(schemaForm_RequestDeleteTable);

            // display the schema form
            Schema.UpdateView();
            Schema.ShowDialog(Editor);
        }

        void Editor_RequestUpdate()
        {
            MessageBox.Show("This feature has not been implemented.",
                "Open existing file",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        void Editor_RequestExportCode()
        {
            if (CodeExport == null)
            {
                CodeExport = new CodeExportForm();
                CodeExport.SourceDataSet = Editor.CurrentFile;
                CodeExport.Show();
                CodeExport.FormClosed += new FormClosedEventHandler(CodeExport_FormClosed);
            }
            else
            {
                CodeExport.Focus();
            }
        }

        void CodeExport_FormClosed(object sender, FormClosedEventArgs e)
        {
            CodeExport = null;
        }

        void schemaForm_RequestDeleteTable()
        {
            var result = MessageBox.Show(String.Format("Are you sure you want to delete the table {0}? All keys ({1}) and rows ({2}) will be removed.", Schema.CurrentTable.Schema.TableName, Schema.CurrentTable.Schema.Fields.Count, Schema.CurrentTable.Rows.Count),
                "Delete table... ",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation);

            if (result == DialogResult.Yes)
            {
                Schema.Close();
                Editor.CurrentFile.Tables.Remove(Schema.CurrentTable);
                Editor.UpdateViews();
            }
        }

        void schemaForm_RequestSaveTable()
        {
            // add table if it doesn't already exist
            if(!Editor.CurrentFile.Tables.Contains(Schema.CurrentTable.TableName))
            {
                Editor.CurrentFile.Tables.Add(Schema.CurrentTable);
            }

            Schema.Close();
            Editor.UpdateViews();
        }

        void Editor_RequestSaveFile()
        {
            var autoSaveFileName = "autosave.xml";
            DataFairyWrite.writeFile(Editor.CurrentFile, autoSaveFileName);

            var saveDialog = new SaveFileDialog();
            saveDialog.Title = "Save File...";
            saveDialog.Filter = FileFilterString;
            var result = saveDialog.ShowDialog(Editor);

            if (result == DialogResult.OK)
            {
                var fileName = saveDialog.FileName;
                net.mkv25.DataFairy.IO.DataFairyWrite.writeFile(Editor.CurrentFile, fileName);

                MessageBox.Show("File was saved to " + fileName,
                    "File saved...",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        void Splash_RequestExit()
        {
            Application.Exit();
        }
    }
}
