using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;

namespace net.mkv25.DataFairy.VO
{
    /**
     * Represents a file that holds tables.
     */
    public class DataFairyFile : DataSet
    {
        public DataFairyFile()
        {

        }

        public DataFairyTable GetTable(string name)
        {
            foreach (DataFairyTable table in Tables)
            {
                if (table.Schema.TableName == name)
                {
                    return table;
                }
            }
            return null;
        }
    }
}
