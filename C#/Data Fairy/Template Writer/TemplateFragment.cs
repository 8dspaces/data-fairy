using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace net.mkv25.writer
{
    public class TemplateFragment
    {
        public string fragmentBody;

        public string WriteLocalAssignment(string name, string value)
        {
            var s = fragmentBody;
            s = s.Replace("NAME", name);
            s = s.Replace("VALUE", value);
            return s;
        }

        public string WriteLocalVariable(string varName, string type, string value)
        {
            var s = fragmentBody;
            s = s.Replace("NAME", varName);
            s = s.Replace("TYPE", type);
            s = s.Replace("VALUE", value);
            return s;
        }

        public string WriteConstant(string varName, string type, string value)
        {
            var s = fragmentBody;
            s = s.Replace("NAME", varName);
            s = s.Replace("TYPE", type);
            s = s.Replace("VALUE", value);
            return s;
        }

        public string WriteNewClassInstance(string className, string parameters)
        {
            var s = fragmentBody;
            s = s.Replace("CLASS_NAME", className);
            s = s.Replace("PARAMS", parameters);
            return s;
        }

        public string WriteClassProperty(string name, string type)
        {
            var s = fragmentBody;
            s = s.Replace("NAME", name);
            s = s.Replace("TYPE", type);
            return s;
        }

        public string WriteClassVariable(string name, string type, string scope = "public")
        {
            var s = fragmentBody;
            s = s.Replace("SCOPE", scope);
            s = s.Replace("NAME", name);
            s = s.Replace("TYPE", type);
            return s;
        }

        public string WriteParameter(string name, string type)
        {
            var s = fragmentBody;
            s = s.Replace("NAME", name);
            s = s.Replace("TYPE", type);
            return s;
        }
    }
}
