using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using net.mkv25.DataFairy.VO;

namespace Data_Fairy_Editor
{
    public partial class EditorForm : Form
    {
        public event UIEventHandler RequestSaveFile;
        public event UIEventHandler RequestUpdate;
        public event UIEventHandler RequestNewTable;
        public event UIEventHandler RequestEditTable;
        public event UIEventHandler RequestExportCode;

        public DataFairyFile CurrentFile;
        public DataFairyTable CurrentTable;

        public EditorForm()
        {
            InitializeComponent();

            this.Icon = Icons.data_fairy_wand;

            dataGridView.DataError += new DataGridViewDataErrorEventHandler(dataGridView_DataError);

            UpdateViews();
        }

        void dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // chill
            var x = sender;
        }

        public void UpdateViews()
        {
            UpdateTableView();

            // bind tables to list view
            if (CurrentFile != null)
            {
                tablesListView.Items.Clear();
                foreach (DataFairyTable table in CurrentFile.Tables)
                {
                    var item = new ListViewItem(table.Schema.TableName);
                    item.Tag = table;
                    tablesListView.Items.Add(item);
                }
            }
        }

        protected void UpdateTableView()
        {
            DataGridViewColumn column;
            BindingSource bindingSource;

            // bind rows to data grid
            if (CurrentTable != null)
            {
                CurrentTable.UpdateFromSchema();
                selectedTableLabel.Text = CurrentTable.Schema.TableName;
                editTableButton.Enabled = true;
                dataGridView.AutoGenerateColumns = false;
                dataGridView.DataSource = CurrentTable;
                dataGridView.Columns.Clear();

                // add name column
                column = new DataGridViewTextBoxColumn();
                column.HeaderText = "name";
                column.DataPropertyName = "name";
                dataGridView.Columns.Add(column);

                // add column templates based on schema
                foreach(var field in CurrentTable.Schema.Fields)
                {
                    if (field.FieldType == "lookup" && !String.IsNullOrEmpty(field.FieldLookUp) && CurrentFile.GetTable(field.FieldLookUp) != null)
                    {
                        var comboBoxColumn = new DataGridViewComboBoxColumn();
                        comboBoxColumn.HeaderText = field.FieldName;
                        comboBoxColumn.DataPropertyName = field.FieldName;
                        comboBoxColumn.DisplayStyleForCurrentCellOnly = true;

                        // create binding source from lookup field
                        var lookupTable = CurrentFile.GetTable(field.FieldLookUp);
                        var lookupValues = new List<KeyValuePair<string, int>>();
                        foreach (DataRow row in lookupTable.Rows)
                        {
                            lookupValues.Add(new KeyValuePair<string, int>(row["name"].ToString(), int.Parse(row["id"].ToString())));
                        }
                        bindingSource = new BindingSource(lookupValues, null);

                        comboBoxColumn.DataSource = bindingSource;
                        comboBoxColumn.ValueMember = "Value";
                        comboBoxColumn.DisplayMember = "Key";
                        column = comboBoxColumn;
                    }
                    else if (field.FieldType == "int")
                    {
                        column = new DataGridViewTextBoxColumn();
                        column.HeaderText = field.FieldName;
                        column.DataPropertyName = field.FieldName;
                    }
                    else
                    {
                        column = new DataGridViewTextBoxColumn();
                        column.HeaderText = field.FieldName;
                        column.DataPropertyName = field.FieldName;
                    }
                    dataGridView.Columns.Add(column);
                }
            }
            else
            {
                editTableButton.Enabled = false;
            }
        }

        private void onSaveClicked(object sender, EventArgs e)
        {
            if (RequestSaveFile != null)
                RequestSaveFile();
        }

        private void onNewTableClick(object sender, EventArgs e)
        {
            if (RequestNewTable != null)
                RequestNewTable();
        }

        private void onEditSchemaClick(object sender, EventArgs e)
        {
            if (RequestEditTable != null)
                RequestEditTable();
        }

        private void onUpdateClick(object sender, EventArgs e)
        {
            if (RequestUpdate != null)
                RequestUpdate();
        }

        private void tablesListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (tablesListView.SelectedItems.Count > 0)
            {
                var item = tablesListView.SelectedItems[0];
                CurrentTable = (DataFairyTable) item.Tag;
                UpdateTableView();
            }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            if (RequestExportCode != null)
                RequestExportCode();
        }
    }
}
