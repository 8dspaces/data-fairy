using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel;

namespace net.mkv25.DataFairy.VO
{
    public class DataFairySchema
    {
        public String TableName;
        public BindingList <DataFairySchemaField> Fields;

        public DataFairySchema()
        {
            TableName = "";
            Fields = new BindingList <DataFairySchemaField>();
        }

        /** Returns a deep clone of the object */
        public DataFairySchema Clone()
        {
            var schema = new DataFairySchema();

            schema.TableName = TableName;
            foreach(var field in Fields)
            {
                schema.Fields.Add(field.Clone());
            }

            return schema;
        }
    }
}
