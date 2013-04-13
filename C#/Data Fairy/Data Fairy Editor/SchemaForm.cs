using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using net.mkv25.DataFairy.IO.FieldTypes;
using net.mkv25.DataFairy.VO;

namespace Data_Fairy_Editor
{
    public partial class SchemaForm : Form
    {
        public event UIEventHandler RequestDeleteTable;
        public event UIEventHandler RequestSaveTable;

        public DataFairyFile CurrentFile;
        public DataFairyTable CurrentTable;
        public DataFairySchema SchemaCopy;

        public SchemaForm()
        {
            InitializeComponent();

            this.Icon = Icons.data_fairy;
        }

        public void UpdateView()
        {
            if (CurrentTable != null)
            {
                SchemaCopy = CurrentTable.Schema.Clone();

                tableNameInput.Text = SchemaCopy.TableName;
                tableNameInput.Focus();
                dataGridView.AutoGenerateColumns = false;

                // set field name text column
                var fieldNameColumn = new DataGridViewTextBoxColumn();
                fieldNameColumn.DataPropertyName = "FieldName";
                fieldNameColumn.HeaderText = "Field Name";
                dataGridView.Columns.Add(fieldNameColumn);

                // set field type combobox column
                var fieldTypeColumn = new DataGridViewComboBoxColumn();
                fieldTypeColumn.DataPropertyName = "FieldType";
                fieldTypeColumn.HeaderText = "Field Type";
                var typeValues = new List<string>() { "string", "int", "decimal", "lookup" };
                fieldTypeColumn.DataSource = typeValues;
                dataGridView.Columns.Add(fieldTypeColumn);

                // set field lookup combobox column
                var fieldLookUpColumn = new DataGridViewComboBoxColumn();
                fieldLookUpColumn.DataPropertyName = "FieldLookup";
                fieldLookUpColumn.HeaderText = "Field Lookup";
                var lookupValues = new List<string>();
                lookupValues.Add(String.Empty);
                foreach (DataFairyTable table in CurrentFile.Tables)
                {
                    lookupValues.Add(table.Schema.TableName);
                }
                fieldLookUpColumn.DataSource = lookupValues;
                dataGridView.Columns.Add(fieldLookUpColumn);

                // populate the data
                dataGridView.DataSource = SchemaCopy.Fields;
            }
            else
            {
                MessageBox.Show("No table passed through to Schema Form",
                    "Flow Issue",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SchemaCopy.TableName = tableNameInput.Text;
            CurrentTable.Schema = SchemaCopy;

            if (RequestSaveTable != null)
                RequestSaveTable();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (RequestDeleteTable != null)
                RequestDeleteTable();
        }

        private void dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // chill
        }
    }
}
