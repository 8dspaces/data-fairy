using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace net.mkv25.writer
{
    public class TemplateWriterConfig
    {
        public static List<string> Warnings { get; set; }

        public static TemplateWriter LoadFromDirectory(string directory)
        {
            var fileList = Directory.EnumerateFiles(directory, "*.xml");
            string xmlFile = null;
            foreach (var item in fileList)
            {
                xmlFile = item;
                break;
            }

            if (String.IsNullOrEmpty(xmlFile))
            {
                return null;
            }

            return LoadFromFile(xmlFile);
        }

        /**
         * Load the configuration for a template writer from an XML document
         */
        public static TemplateWriter LoadFromFile(string path)
        {
            var xml = new XmlDocument();
            try
            {
                xml.Load(path);
            }
            catch (Exception e)
            {
                LogWarning(Path.GetFileName(path) + " - Error loading template file, " + e.Message);
                return null;
            }

            var template = new TemplateWriter();
            var fileInfo = new FileInfo(path);
            var templateDirectory = fileInfo.Directory.FullName;

            XmlNode nameNode = xml.SelectSingleNode("/Config/Name");
            if (nameNode != null)
            {
                template.Name = nameNode.InnerText;
                template.AddTemplateVariable("TEMPLATE_NAME", template.Name);
            }

            XmlNode authorNode = xml.SelectSingleNode("/Config/Author");
            if (authorNode != null)
            {
                template.Author = authorNode.InnerText;
                template.AddTemplateVariable("TEMPLATE_AUTHOR", template.Name);
            }

            XmlNode contactNode = xml.SelectSingleNode("/Config/Contact");
            if (contactNode != null)
            {
                template.Contact = contactNode.InnerText;
                template.AddTemplateVariable("TEMPLATE_CONTACT", template.Name);
            }

            XmlNode databaseFileTemplateNode = xml.SelectSingleNode("/Config/DatabaseFileTemplate");
            if (databaseFileTemplateNode != null)
                template.DataBaseFileTemplate = new TemplateFile() { FileName = databaseFileTemplateNode.InnerText, FileContents = ReadFileContents(templateDirectory + "\\" + databaseFileTemplateNode.InnerText) };

            XmlNode tableFileTemplateNode = xml.SelectSingleNode("/Config/TableFileTemplate");
            if (tableFileTemplateNode != null)
                template.TableFileTemplate = new TemplateFile() { FileName = tableFileTemplateNode.InnerText, FileContents = ReadFileContents(templateDirectory + "\\" + tableFileTemplateNode.InnerText) };

            XmlNode rowFileTemplateNode = xml.SelectSingleNode("/Config/RowFileTemplate");
            if (rowFileTemplateNode != null)
                template.RowFileTemplate = new TemplateFile() { FileName = rowFileTemplateNode.InnerText, FileContents = ReadFileContents(templateDirectory + "\\" + rowFileTemplateNode.InnerText) };

            XmlNode enumerationFileTemplateNode = xml.SelectSingleNode("/Config/EnumerationFileTemplate");
            if (enumerationFileTemplateNode != null)
                template.EnumerationFileTemplate = new TemplateFile() { FileName = enumerationFileTemplateNode.InnerText, FileContents = ReadFileContents(templateDirectory + "\\" + enumerationFileTemplateNode.InnerText) };

            XmlNodeList packageFileNodes = xml.SelectNodes("/Config/PackageFile");
            template.PackageFileTemplates = new List<TemplateFile>();
            foreach (XmlNode packageFileNode in packageFileNodes)
            {
                var packageFile = new TemplateFile() { FileName = packageFileNode.InnerText, FileContents = ReadFileContents(templateDirectory + "\\" + packageFileNode.InnerText) };
                if (!String.IsNullOrEmpty(packageFile.FileContents))
                    template.PackageFileTemplates.Add(packageFile);
            }

            XmlNode packageSeperatorNode = xml.SelectSingleNode("/Config/PackageSeperator");
            if(packageSeperatorNode != null)
                template.PackageSeperator = packageSeperatorNode.InnerText;

            XmlNode generatePackageFolderStructureNode = xml.SelectSingleNode("/Config/GeneratePackageFolderStructure");
            if(generatePackageFolderStructureNode != null)
                template.GeneratePackageFolderStructure = (generatePackageFolderStructureNode.InnerText == "true");

            XmlNode forceLowercasePackageStructureNode = xml.SelectSingleNode("/Config/ForceLowercasePackageStructure");
            if (forceLowercasePackageStructureNode != null)
                template.ForceLowercasePackageStructure = (forceLowercasePackageStructureNode.InnerText == "true");

            XmlNodeList fragmentNodes = xml.SelectNodes("/Config/Fragment");
            foreach (XmlNode fragmentNode in fragmentNodes)
            {
                var fragment = new TemplateFragment();
                var fragmentName = fragmentNode.Attributes["name"].Value;
                fragment.fragmentBody = ReadFileContents(templateDirectory + "\\" + fragmentNode.InnerText);

                if (fragmentName == "ClassProperty")
                    template.ClassPropertyFragment = fragment;
                else if (fragmentName == "ClassVariable")
                    template.ClassVariableFragment = fragment;
                else if (fragmentName == "Constant")
                    template.ConstantFragment = fragment;
                else if (fragmentName == "Enum")
                    template.EnumFragment = fragment;
                else if (fragmentName == "LocalAssignment")
                    template.LocalAssignmentFragment = fragment;
                else if (fragmentName == "LocalVariable")
                    template.LocalVariableFragment = fragment;
                else if (fragmentName == "NewClassInstance")
                    template.NewClassInstanceFragment = fragment;
                else if (fragmentName == "Parameter")
                    template.ParameterFragment = fragment;
            }

            XmlNodeList typeNodes = xml.SelectNodes("/Config/Type");
            template.BasicTypes = new Dictionary<string, string>();
            foreach (XmlNode typeNode in typeNodes)
            {
                var key = typeNode.Attributes["name"].Value;
                var value = typeNode.InnerText;
                template.BasicTypes.Add(key, value);
            }
            
            XmlNode variablePrefixNode = xml.SelectSingleNode("/Config/VariablePrefix");
            if (variablePrefixNode != null)
                template.VariablePrefix = variablePrefixNode.InnerText;

            return template;
        }

        /**
         * Write the config to an XML file 
         */
        public static void WriteConfigTo(TemplateWriter config, string path)
        {

        }

        /** 
         * Read the entire contents of a file into a variable
         */
        protected static string ReadFileContents(string path)
        {
            string contents = null;

            if (!File.Exists(path))
            {
                LogWarning("File does not exist: " + path);
                return contents;
            }

            try
            {
                var file = new StreamReader(path);
                contents = file.ReadToEnd();
                file.Close();
            }
            catch (Exception e)
            {
                LogWarning(Path.GetFileName(path) + " - " + e.Message);
            }

            return contents;
        }

        protected static void LogWarning(string message)
        {
            if (Warnings == null)
                Warnings = new List<string>();
            Warnings.Add(message);
        }
    }
}
