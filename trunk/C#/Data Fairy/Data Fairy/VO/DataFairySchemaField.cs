using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using net.mkv25.DataFairy.IO.FieldTypes;

namespace net.mkv25.DataFairy.VO
{
    /**
     * Represents a field in a schema.
     */
    public class DataFairySchemaField
    {
        /** The name of the field */
        public string FieldName { get; set; }

        /** The type of the field */
        public string FieldType { get; set; }

        /** The name of the lookup table for the field */
        public string FieldLookUp { get; set; }

        /** Returns a deep clone of the object */
        public DataFairySchemaField Clone()
        {
            var schemaField = new DataFairySchemaField();

            schemaField.FieldName = FieldName;
            schemaField.FieldType = FieldType;
            schemaField.FieldLookUp = FieldLookUp;

            return schemaField;
        }
    }
}
