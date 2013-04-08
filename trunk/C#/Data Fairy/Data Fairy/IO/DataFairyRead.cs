using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using net.mkv25.DataFairy.VO;
using System.Xml;
using System.Data;

namespace net.mkv25.DataFairy.IO
{
    public class DataFairyRead
    {
        public static List<string> Warnings;

        public static DataFairyFile readFile(String path)
        {
            var file = new DataFairyFile();
            Warnings = new List<string>();

            var xmlFile = new XmlDocument();
            xmlFile.Load(path);

            var i = 0;
            XmlNodeList tableNodes = xmlFile.SelectNodes("/Data/Tables/Table");
            foreach (XmlNode tableNode in tableNodes)
            {
                readTable(tableNode, file);
                try
                {
                }
                catch (Exception e)
                {
                    Warnings.Add(String.Format("Error Reading Table {0}, Exception: " + e.Message, i));
                }
                i++;
            }

            return file;
        }

        public static void readTable(XmlNode tableNode, DataFairyFile file)
        {
            var table = new DataFairyTable();

            XmlNode schemaNode = tableNode.SelectSingleNode("Schema");
            readSchema(schemaNode, table);

            XmlNodeList rowNodes = tableNode.SelectNodes("Row");
            readRows(rowNodes, table);

            file.Tables.Add(table);
        }

        private static void readSchema(XmlNode schemaNode, DataFairyTable table)
        {
            table.Schema.TableName = schemaNode["Name"].InnerText;

            var i = 0;
            XmlNodeList fieldNodes = schemaNode.SelectNodes("Field");
            foreach(XmlNode fieldNode in fieldNodes)
            {
                var field = new DataFairySchemaField();

                // only create fields with valid names
                if (fieldNode["Name"] != null)
                {
                    field.FieldName = fieldNode["Name"].InnerText;

                    if(fieldNode["Type"] != null)
                        field.FieldType = fieldNode["Type"].InnerText;

                    if(fieldNode["Lookup"] != null)
                        field.FieldLookUp = fieldNode["Lookup"].InnerText;
                    
                    try
                    {
                        table.Schema.Fields.Add(field);
                    }
                    catch (Exception e)
                    {
                        Warnings.Add(String.Format("Error Adding Field {0}, Exception: " +  e.Message, i));
                    }
                }
                else
                {
                    Warnings.Add(String.Format("Skipped Field {0} because no Name property was found.", i));
                }
                i++;
            }

            table.UpdateFromSchema();
        }

        private static void readRows(XmlNodeList rowNodes, DataFairyTable table)
        {
            var i = 0;
            foreach (XmlNode rowNode in rowNodes)
            {
                var row = table.NewRow();

                // check for id field
                if (rowNode[DataFairyTable.ID] != null)
                    row[DataFairyTable.ID] = rowNode[DataFairyTable.ID].InnerText;

                // check for name field
                if (rowNode[DataFairyTable.NAME] != null)
                    row[DataFairyTable.NAME] = rowNode[DataFairyTable.NAME].InnerText;

                // loop through the schema files for valid column entries
                foreach (var field in table.Schema.Fields)
                {
                    if (rowNode[field.FieldName] != null)
                    {
                        var value = rowNode[field.FieldName].InnerText;
                        int valueInt = 0;
                        if (field.FieldType == "int" || field.FieldType == "lookup")
                        {
                            if(int.TryParse(value, out valueInt))
                                row[field.FieldName] = valueInt;
                        }
                        else
                        {
                            row[field.FieldName] = value;
                        }
                    }
                }

                // check Id constraint
                var idValue = row[DataFairyTable.ID].ToString();
                if (String.IsNullOrEmpty(idValue))
                {
                    row[DataFairyTable.ID] = idValue = "" + 1000 + i;
                    Warnings.Add(String.Format("Error Adding Row {0}, No value set for id field. Defaulting to {1}", i, idValue));
                }

                // check Name constraint
                var nameValue = row[DataFairyTable.NAME].ToString();
                if (String.IsNullOrEmpty(nameValue))
                {
                    row[DataFairyTable.NAME] = nameValue = "Unnamed " + i;
                    Warnings.Add(String.Format("Error Adding Row {0}, No value set for name field. Defaulting to {1}", i, nameValue));
                }

                // try and add the row
                try
                {
                    table.Rows.Add(row);
                }
                catch (Exception e)
                {
                    if (e is ConstraintException)
                    {
                        Warnings.Add(String.Format("Error Adding Row {0}, A unique value, such as the Id or Name field already exists on the table. Details: " + e.Message, i));
                    }
                    else
                    {
                        Warnings.Add(String.Format("Error Adding Row {0}, Exception: " + e.Message, i));
                    }
                }

                i++;
            }
        }
    }
}
