using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace net.mkv25.DataFairy.VO
{
    /**
     * Represents a table that holds rows of data
     */
    public class DataFairyTable : DataTable
    {
        public const string ID = "id";
        public const string NAME = "name";

        public DataFairySchema Schema { get; set; }

        public DataFairyTable()
        {
            Schema = new DataFairySchema();
        }
        
        public void UpdateFromSchema()
        {
            DataColumn column;

            TableName = Schema.TableName;

            // create identity column
            if (Columns.Count < 1)
            {
                column = new DataColumn(ID, typeof(Int32));
                column.AutoIncrement = true;
                column.ReadOnly = true;
                column.Unique = true;
                Columns.Add(column);
            }

            // create name column
            if (Columns.Count < 2)
            {
                column = new DataColumn(NAME, typeof(string));
                column.Unique = true;
                Columns.Add(column);
            }

            // create the rest of the columns from schema
            var i = 2;
            foreach(var field in Schema.Fields)
            {
                if (i >= Columns.Count)
                {
                    if (field.FieldType == "lookup")
                    {
                        column = Columns.Add(field.FieldName, typeof(int));
                    }
                    else
                    {
                        column = Columns.Add(field.FieldName, typeof(string));
                    }
                }
                else
                {
                    column = Columns[i];
                    if (field.FieldName != null)
                        column.ColumnName = field.FieldName;
                    else
                        column.ColumnName = "Empty " + i;
                }

                i++;
            }

            // remove spare columns - WARNING: Causes data loss
            while (Columns.Count > Schema.Fields.Count + 2)
            {
                Columns.RemoveAt(Columns.Count - 1);
            }
        }
    }
}
