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
            s = s.Replace(Keys.NAME, name);
            s = s.Replace(Keys.VALUE, value);
            return s;
        }

        public string WriteLocalVariable(string varName, string type, string value)
        {
            var s = fragmentBody;
            s = s.Replace(Keys.TYPE, type);
            s = s.Replace(Keys.NAME, varName);
            s = s.Replace(Keys.VALUE, value);
            return s;
        }

        public string WriteConstant(string varName, string type, string value)
        {
            var s = fragmentBody;
            s = s.Replace(Keys.TYPE, type);
            s = s.Replace(Keys.NAME, varName);
            s = s.Replace(Keys.VALUE, value);
            return s;
        }

        public string WriteEnum(string enumName, string type, string value)
        {
            var s = fragmentBody;
            s = s.Replace(Keys.TYPE, type);
            s = s.Replace(Keys.NAME, enumName);
            s = s.Replace(Keys.VALUE, value);
            return s;
        }

        public string WriteNewClassInstance(string className, string parameters, string valueId, string enumValueName)
        {
            var s = fragmentBody;
            s = s.Replace(Keys.CLASS_NAME, className);
            s = s.Replace(Keys.PARAMS, parameters);
            s = s.Replace(Keys.VALUE_ID, valueId);
            s = s.Replace(Keys.ENUM_VALUE_NAME, enumValueName);
            return s;
        }

        public string WriteClassProperty(string name, string type)
        {
            var s = fragmentBody;
            s = s.Replace(Keys.TYPE, type);
            s = s.Replace(Keys.NAME, name);
            return s;
        }

        public string WriteClassVariable(string name, string type, string scope = "public")
        {
            var s = fragmentBody;
            s = s.Replace(Keys.TYPE, type);
            s = s.Replace(Keys.SCOPE, scope);
            s = s.Replace(Keys.NAME, name);
            return s;
        }

        public string WriteParameter(string name, string type)
        {
            var s = fragmentBody;
            s = s.Replace(Keys.TYPE, type);
            s = s.Replace(Keys.NAME, name);
            return s;
        }
    }
}
