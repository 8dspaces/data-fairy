using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using net.mkv25.DataFairy.VO;
using System.Data;

namespace net.mkv25.DataFairy.IO
{
    public class DataFairyWrite
    {
        public static void writeFile(DataFairyFile file, String path)
        {
            var xmlWriter = new XmlTextWriter(path, null);
            xmlWriter.Formatting = Formatting.Indented;
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Data");
            xmlWriter.WriteStartElement("Tables");

            // for each table in file.tables, write a table node
            foreach (DataFairyTable table in file.Tables)
            {
                xmlWriter.WriteStartElement("Table");
                
                // write the table schema
                xmlWriter.WriteStartElement("Schema");
                xmlWriter.WriteElementString("Name", table.Schema.TableName);
                foreach (var field in table.Schema.Fields)
                {
                    xmlWriter.WriteStartElement("Field");
                    if(field.FieldName != null) 
                        xmlWriter.WriteElementString("Name", field.FieldName);
                    if(field.FieldType != null)
                        xmlWriter.WriteElementString("Type", field.FieldType);
                    if(field.FieldLookUp != null)
                        xmlWriter.WriteElementString("Lookup", field.FieldLookUp);
                    xmlWriter.WriteEndElement();
                }
                xmlWriter.WriteEndElement();

                // for each row in table, write a row node
                foreach (DataRow row in table.Rows)
                {
                    xmlWriter.WriteStartElement("Row");
                    xmlWriter.WriteElementString(DataFairyTable.ID, row[DataFairyTable.ID].ToString());
                    xmlWriter.WriteElementString(DataFairyTable.NAME, row[DataFairyTable.NAME].ToString());
                    foreach (var field in table.Schema.Fields)
                    {
                        if (field.FieldName != null)
                            xmlWriter.WriteElementString(field.FieldName, row[field.FieldName].ToString());
                    }
                    xmlWriter.WriteEndElement();
                }

                // close the table
                xmlWriter.WriteEndElement();
            }

            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Flush();
            xmlWriter.Close();
        }
    }
}
