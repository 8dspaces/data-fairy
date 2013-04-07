using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace net.mkv25.DataFairy.IO.FieldTypes
{
    public class DataFairyFieldTypes
    {
        List<IDataFairyFieldType> list;
        
        public List<IDataFairyFieldType> List
        {
            get
            {
                if(list != null)
                    return list;
   
                list = new List<IDataFairyFieldType>();
                list.Add(new DataFairyStringFieldType());
                list.Add(new DataFairyLookupTableFieldType());
                list.Add(new DataFairyBooleanFieldType());
                list.Add(new DataFairyIntegerFieldType());
                list.Add(new DataFairyDecimalFieldType());

                return list;
            }
        }
    }

    public interface IDataFairyFieldType
    {
        string Name { get; }
        bool Validate(string value);
    }

    public class DataFairyStringFieldType : IDataFairyFieldType
    {
        public string Name
        {
            get { return "String"; }
        }

        public bool Validate(string value)
        {
            return true;
        }
    }

    public class DataFairyIntegerFieldType : IDataFairyFieldType
    {
        public string Name
        {
            get { return "Integer"; }
        }

        public bool Validate(string value)
        {
            return true;
        }
    }

    public class DataFairyDecimalFieldType : IDataFairyFieldType
    {
        public string Name
        {
            get { return "Decimal"; }
        }

        public bool Validate(string value)
        {
            try
            {
                Decimal.Parse(value);
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
    }

    public class DataFairyLookupTableFieldType : IDataFairyFieldType
    {
        public string Name
        {
            get { return "Lookup Table"; }
        }

        public bool Validate(string value)
        {
            return true;
        }
    }

    public class DataFairyBooleanFieldType : IDataFairyFieldType
    {
        public string Name
        {
            get { return "Boolean"; }
        }

        public bool Validate(string value)
        {
            try
            {
                Boolean.Parse(value);
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
    }
}
