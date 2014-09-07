using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using net.mkv25.DataFairy.VO;

namespace net.mkv25.writer
{
    public class TemplateWriter
    {
        /** The dataset to base the code generation on */
        public DataFairyFile SourceDataSet;

        /** name of this template */
        public string Name;

        /** author of the template */
        public string Author;

        /** contact info for this template */
        public string Contact;

        /** The template for the database file */
        public TemplateFile DataBaseFileTemplate;

        /** The template for individual table class files */
        public TemplateFile TableFileTemplate;

        /** The template for individual row class files */
        public TemplateFile RowFileTemplate;

        /** The template for enumeration lists */
        public TemplateFile EnumerationFileTemplate;

        /** Any other template files that exist in the package */
        public List<TemplateFile> PackageFileTemplates;

        /** A list of strings to search and replace on */
        public Dictionary<string, string> BasicTypes;

        /** A string to insert before variables */
        public string VariablePrefix = String.Empty;

        /** A list of strings to search and replace on */
        public List<KeyValuePair<string, string>> TemplateVariables;

        /* A list of messages generated during the write process */
        public List<KeyValuePair<DateTime, string>> LogMessages;

        /** The seperator to use between generated package paths */
        public string PackageSeperator = ".";

        /** Should the code template generate folders that match the package structure */
        public bool GeneratePackageFolderStructure = false;

        /** Should the package name be forced to lowercase for a given template */
        public bool ForceLowercasePackageStructure = false;

        /** A fragment for writing new class properties */
        public TemplateFragment ClassPropertyFragment;

        /** A fragment for writing new class level variables */
        public TemplateFragment ClassVariableFragment;

        /** A fragment for defining a constant */
        public TemplateFragment ConstantFragment;

        /** A fragment for defining a property in an enum */
        public TemplateFragment EnumFragment;

        /** A fragment for variable assignment */
        public TemplateFragment LocalVariableFragment;

        /** A fragment for variable assignment */
        public TemplateFragment LocalAssignmentFragment;

        /** A fragment for writing new class instances */
        public TemplateFragment NewClassInstanceFragment;

        /** A fragment for writing parameters */
        public TemplateFragment ParameterFragment;
        
        /** The package path to use for code generation */
        protected string _packageString;

        public TemplateWriter()
        {
            TemplateVariables = new List<KeyValuePair<string, string>>();
        }

        /** The package path for code generation, including the modifier for lowercase mode */
        public string PackageString 
        {
            get
            {
                if (ForceLowercasePackageStructure)
                {
                    return _packageString.ToLower();
                }
                return _packageString;
            }
            set
            {
                _packageString = value;
            }
        }

        /** Add a template variable to be searched and replaced */
        public void AddTemplateVariable(string key, string value)
        {
            TemplateVariables.Add(new KeyValuePair<string, string>(key, value));
        }

        /** Lookup function to convert local type in to language specific type */
        protected string getBasicType(string requestedType)
        {
            // convert "lookup" into int field
            if (requestedType == "lookup")
                return getBasicType("int");

            if (BasicTypes.ContainsKey(requestedType))
                return BasicTypes[requestedType];
            return requestedType;
        }

        /** Get the full extension of a file based on the first . */
        protected string getFullExt(string input)
        {
            string[] split = input.Split(new char[] { '.' }, 2);
            if (split.Count() == 2)
                return '.' + split[1];
            return input;
        }

        /**
         * Generate code from templates into the specified directory.
         */
        public void WriteTo(string outputDirectory)
        {
            LogMessages = new List<KeyValuePair<DateTime, string>>();

            if (String.IsNullOrEmpty(outputDirectory))
            {
                Log("No output directory set");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Log("Output path does not exist.");
                return;
            }

            Log("Starting Write Process");

            // delete down files that already exist
            var directoryBrowser = new DirectoryInfo(outputDirectory);
            directoryBrowser.GetFiles("*", SearchOption.AllDirectories).ToList().ForEach(file => file.Delete());

            // check to see if a folder structure needs generating for the packages
            if (GeneratePackageFolderStructure)
            {
                var packagePath = new StringBuilder();
                var packagePathArray = PackageString.Split(PackageSeperator.ToCharArray());
                foreach (var packagePart in packagePathArray)
                {
                    packagePath.Append(packagePart + "\\");
                }
                outputDirectory = outputDirectory + "\\" + packagePath.ToString();
            }

            // do the work
            WritePackageFiles(outputDirectory);
            WriteEnumerations(outputDirectory);
            WriteRowFiles(outputDirectory);
            WriteTableFiles(outputDirectory);
            WriteDatabaseFile(outputDirectory);

            Log("Finished Write Process");
        }

        /**
         * Generate enumeration files for all rows in all tables in the dataset using a template file.
         */
        public void WriteEnumerations(string outputDirectory)
        {
            if (EnumerationFileTemplate == null)
                return;

            string fileName;
            string FOLDER = Path.GetDirectoryName(EnumerationFileTemplate.FileName);
            string EXT = getFullExt(EnumerationFileTemplate.FileName);
            foreach(DataTable table in SourceDataSet.Tables)
            {
                var className = NameUtils.FormatClassName(table.TableName) + "Enum";
                fileName = className + EXT;

                // build the file
                StringBuilder fileContents = new StringBuilder(EnumerationFileTemplate.FileContents);
                StringBuilder enumList = new StringBuilder();

                // build the list of constants for the enum
                enumList.AppendLine("// code generated list of all rows");
                foreach (DataRow row in table.Rows)
                {
                    var enumName = NameUtils.FormatClassConstantName(row["Name"].ToString());
                    enumList.AppendLine(EnumFragment.WriteConstant(enumName, getBasicType("int"), row["Id"].ToString()));
                }

                // replace standard set of variables
                ReplaceVariables(fileContents, TemplateVariables);
                fileContents.Replace(Keys.PACKAGE_STRING, PackageString);
                fileContents.Replace(Keys.CLASS_NAME, className);
                fileContents.Replace(Keys.ENUM_VALUES_LIST, enumList.ToString().TrimEnd('\n', '\r'));

                // write the file
                var filePath = outputDirectory + "\\" + FOLDER + "\\" + fileName;
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                StreamWriter writer = new StreamWriter(filePath);
                writer.Write(fileContents);
                writer.Close();

                Log("Created Enum File - " + fileName);
            }
        }

        /**
         * Generate class files for all row types in the dataset using a template file
         */
        public void WriteRowFiles(string outputDirectory)
        {
            if (RowFileTemplate == null)
                return;

            string fileName;
            string FOLDER = Path.GetDirectoryName(RowFileTemplate.FileName);
            string EXT = getFullExt(RowFileTemplate.FileName);
            foreach (DataFairyTable table in SourceDataSet.Tables)
            {
                var className = NameUtils.FormatClassName(table.TableName) + "Row";
                var enumClassName = NameUtils.FormatClassName(table.TableName) + "Enum";
                fileName = className + EXT;

                // build the file
                StringBuilder fileContents = new StringBuilder(RowFileTemplate.FileContents);
                StringBuilder variableList = new StringBuilder();
                StringBuilder propertyList = new StringBuilder();
                StringBuilder paramsString = new StringBuilder();
                StringBuilder paramsList = new StringBuilder();

                // start code blocks off with comments
                variableList.AppendLine("// code generated list of variables");
                propertyList.AppendLine("// code generated list of properties");
                paramsList.AppendLine("// code generated list of params");

                // populate list of variables
                foreach (DataFairySchemaField field in table.Schema.AllFields)
                {
                    if (String.IsNullOrEmpty(field.FieldName))
                    {
                        Log("Skipping empty field on " + table.Schema.TableName);
                        continue;
                    }

                    if (field.FieldType == null)
                    {
                        Log("Skipping null field type on " + table.Schema.TableName);
                        continue;
                    }

                    // create variable for basic types
                    string fieldName = field.FieldName;
                    string fieldType = getBasicType(field.FieldType);

                    // create variable for assignment type
                    var paramName = VariablePrefix + "_" + NameUtils.FormatVariableName(field.FieldName);
                    var paramType = getBasicType(field.FieldType);
                    if (paramsString.Length > 0)
                        paramsString.Append(", ");

                    // create properties for lookup values
                    if (field.FieldType == "lookup")
                    {
                        paramName = paramName + "Id";
                        propertyList.AppendLine(ClassPropertyFragment.WriteClassProperty(fieldName, NameUtils.FormatClassName(field.FieldLookUp) + "Row"));
                        variableList.AppendLine(ClassVariableFragment.WriteClassVariable(fieldName + "Id", fieldType));
                        paramsList.AppendLine(LocalAssignmentFragment.WriteLocalAssignment(fieldName + "Id", paramName));
                    }
                    else if (field.FieldName == "id")
                    {
                        // id is a required property on the template
                        paramsList.AppendLine(LocalAssignmentFragment.WriteLocalAssignment(fieldName, paramName));
                    }
                    else
                    {
                        variableList.AppendLine(ClassVariableFragment.WriteClassVariable(fieldName, fieldType));
                        paramsList.AppendLine(LocalAssignmentFragment.WriteLocalAssignment(fieldName, paramName));
                    }

                    paramsString.Append(ParameterFragment.WriteParameter(paramName, paramType));
                }

                // replace standard set of variables
                ReplaceVariables(fileContents, TemplateVariables);
                fileContents.Replace(Keys.VARIABLE_LIST, variableList.ToString().TrimEnd('\n', '\r'));
                fileContents.Replace(Keys.PROPERTY_LIST, propertyList.ToString().TrimEnd('\n', '\r'));
                fileContents.Replace(Keys.CLASS_PARAMS_STRING, paramsString.ToString().TrimEnd('\n', '\r'));
                fileContents.Replace(Keys.CLASS_PARAMS_LIST, paramsList.ToString().TrimEnd('\n', '\r'));
                fileContents.Replace(Keys.ENUM_CLASS_NAME, enumClassName);
                fileContents.Replace(Keys.CLASS_NAME, className);
                fileContents.Replace(Keys.PACKAGE_STRING, PackageString);

                // write the file
                var filePath = outputDirectory + "\\" + FOLDER + "\\" + fileName;
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                StreamWriter writer = new StreamWriter(filePath);
                writer.Write(fileContents);
                writer.Close();

                Log("Created Row File - " + fileName);
            }
        }

        /**
         * Generate class files for all rows in all tables in the dataset using a template file
         */
        public void WriteTableFiles(string outputDirectory)
        {
            if (TableFileTemplate == null)
                return;

            string fileName;
            string FOLDER = Path.GetDirectoryName(TableFileTemplate.FileName);
            string EXT = getFullExt(TableFileTemplate.FileName);
            foreach (DataFairyTable table in SourceDataSet.Tables)
            {
                var className = NameUtils.FormatClassName(table.TableName) + "Table";
                var rowClassName = NameUtils.FormatClassName(table.TableName) + "Row";
                var enumClassName = NameUtils.FormatClassName(table.TableName) + "Enum";

                fileName = className + EXT;

                // build the file
                StringBuilder fileContents = new StringBuilder(TableFileTemplate.FileContents);
                StringBuilder rowList = new StringBuilder();

                // populate individual data rows
                rowList.AppendLine("// code generated list of all rows");
                foreach (DataRow row in table.Rows)
                {
                    var rowParameters = new StringBuilder();

                    var rowEnumName = NameUtils.FormatClassConstantName(row["Name"].ToString());
                    var rowValueId = row["id"].ToString();

                    // populate list of variables
                    foreach (DataFairySchemaField field in table.Schema.AllFields)
                    {
                        if (String.IsNullOrEmpty(field.FieldName))
                            continue;

                        if (rowParameters.Length > 0)
                            rowParameters.Append(", ");

                        // create properties for lookup values
                        string rowValue = row[field.FieldName].ToString();
                        if (field.FieldType == "lookup" || field.FieldType == "int" || field.FieldType == "decimal")
                        {
                            if (String.IsNullOrEmpty(rowValue))
                                rowValue = "-1";
                            rowParameters.Append(rowValue);
                        }
                        else
                        {
                            rowValue = rowValue.Replace("\"", "\\\"");
                            rowParameters.Append(String.Format("\"{0}\"", rowValue));
                        }
                    }

                    var classValue = NewClassInstanceFragment.WriteNewClassInstance(rowClassName, rowParameters.ToString(), rowValueId, rowEnumName);
                    rowList.AppendLine(LocalVariableFragment.WriteLocalVariable(VariablePrefix + "row" + row["id"].ToString(), rowClassName, classValue));
                }

                // replace standard set of variables
                ReplaceVariables(fileContents, TemplateVariables);
                fileContents.Replace(Keys.ROW_LIST, rowList.ToString().TrimEnd('\n', '\r'));
                fileContents.Replace(Keys.PACKAGE_STRING, PackageString);
                fileContents.Replace(Keys.ROW_CLASS_NAME, rowClassName);
                fileContents.Replace(Keys.ENUM_CLASS_NAME, enumClassName);
                fileContents.Replace(Keys.CLASS_NAME, className);
                fileContents.Replace(Keys.TABLE_NAME, table.TableName);

                // write the file
                var filePath = outputDirectory + "\\" + FOLDER + "\\" + fileName;
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                StreamWriter writer = new StreamWriter(filePath);
                writer.Write(fileContents);
                writer.Close();

                Log("Created Table File - " + fileName);
            }
        }

        public void WriteDatabaseFile(string outputDirectory)
        {
            if(DataBaseFileTemplate == null)
                return;

            // check prerequisites
            if (NewClassInstanceFragment == null)
            {
                Log("No class instance fragment available to write database template.");
                return;
            }
            if (LocalAssignmentFragment == null)
            {
                Log("No local assignment fragment available to write database template.");
            }

            string fileName = DataBaseFileTemplate.FileName;
            StringBuilder fileContents = new StringBuilder(DataBaseFileTemplate.FileContents);

            StringBuilder variableList = new StringBuilder();
            variableList.AppendLine("// code generated list of all tables");
            foreach (DataTable table in SourceDataSet.Tables)
            {
                var variableName = NameUtils.FormatClassConstantName(table.TableName);
                var className = NameUtils.FormatClassName(table.TableName) + "Table";
                variableList.AppendLine(ClassVariableFragment.WriteClassVariable(variableName, className));
            }

            StringBuilder classList = new StringBuilder();
            classList.AppendLine("// code generated list of all tables");
            foreach (DataTable table in SourceDataSet.Tables)
            {
                var variableName = NameUtils.FormatClassConstantName(table.TableName);
                var className = NameUtils.FormatClassName(table.TableName) + "Table";
                var classValue = NewClassInstanceFragment.WriteNewClassInstance(className, "", "", variableName);
                classList.AppendLine(LocalAssignmentFragment.WriteLocalAssignment(variableName, classValue));
            }

            // replace standard set of variables
            ReplaceVariables(fileContents, TemplateVariables);
            fileContents.Replace(Keys.VARIABLE_LIST, variableList.ToString().TrimEnd('\n', '\r'));
            fileContents.Replace(Keys.CLASS_LIST, classList.ToString().TrimEnd('\n', '\r'));
            fileContents.Replace(Keys.ENUM_CLASS_NAME, "this");
            fileContents.Replace(Keys.PACKAGE_STRING, PackageString);

            // write the file
            var filePath = outputDirectory + "\\" + DataBaseFileTemplate.FileName;
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            StreamWriter writer = new StreamWriter(filePath);
            writer.Write(fileContents);
            writer.Close();

            Log("Created Database File - " + DataBaseFileTemplate.FileName);
        }

        public void WritePackageFiles(string outputDirectory)
        {
            string fileName;
            StringBuilder fileContents;
            StreamWriter writer;

            foreach (TemplateFile packageFileTemplate in PackageFileTemplates)
            {
                // work out the file name
                fileName = packageFileTemplate.FileName;
                fileContents = new StringBuilder(packageFileTemplate.FileContents);

                // build the file contents
                ReplaceVariables(fileContents, TemplateVariables);
                fileContents.Replace(Keys.PACKAGE_STRING, PackageString);

                // write the file
                var filePath = outputDirectory + "\\" + fileName;
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                writer = new StreamWriter(filePath);
                writer.Write(fileContents);
                writer.Close();

                Log("Created Package File - " + fileName);
            }
        }

        public static void ReplaceVariables(StringBuilder fileContents, List<KeyValuePair<string, string>> variables)
        {
            foreach (KeyValuePair<string, string> pair in variables)
            {
                fileContents.Replace(pair.Key, pair.Value);
            }
        }

        public void Log(string message)
        {
            var log = new KeyValuePair<DateTime, string>(DateTime.Now, message);
            LogMessages.Add(log);
        }
    }
}
