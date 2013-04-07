using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace net.mkv25.DataFairy.VO
{
    public class DataFairyLookupValue<T>
    {
        public T Value;
        public string Name;

        public DataFairyLookupValue()
        {

        }

        public override string ToString()
        {
            return Name;
        }
    }
}
