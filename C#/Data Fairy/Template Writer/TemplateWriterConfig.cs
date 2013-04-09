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
                template.name = nameNode.InnerText;

            XmlNode authorNode = xml.SelectSingleNode("/Config/Author");
            if (authorNode != null)
                template.author = authorNode.InnerText;

            XmlNode contactNode = xml.SelectSingleNode("/Config/Contact");
            if (contactNode != null)
                template.contact = contactNode.InnerText;

            XmlNode databaseFileTemplateNode = xml.SelectSingleNode("/Config/DatabaseFileTemplate");
            if (databaseFileTemplateNode != null)
                template.dataBaseFileTemplate = new TemplateFile() { FileName = databaseFileTemplateNode.InnerText, FileContents = ReadFileContents(templateDirectory + "\\" + databaseFileTemplateNode.InnerText) };

            XmlNode tableFileTemplateNode = xml.SelectSingleNode("/Config/TableFileTemplate");
            if (tableFileTemplateNode != null)
                template.tableFileTemplate = new TemplateFile() { FileName = tableFileTemplateNode.InnerText, FileContents = ReadFileContents(templateDirectory + "\\" + tableFileTemplateNode.InnerText) };

            XmlNode rowFileTemplateNode = xml.SelectSingleNode("/Config/RowFileTemplate");
            if (rowFileTemplateNode != null)
                template.rowFileTemplate = new TemplateFile() { FileName = rowFileTemplateNode.InnerText, FileContents = ReadFileContents(templateDirectory + "\\" + rowFileTemplateNode.InnerText) };

            XmlNode enumerationFileTemplateNode = xml.SelectSingleNode("/Config/EnumerationFileTemplate");
            if (enumerationFileTemplateNode != null)
                template.enumerationFileTemplate = new TemplateFile() { FileName = enumerationFileTemplateNode.InnerText, FileContents = ReadFileContents(templateDirectory + "\\" + enumerationFileTemplateNode.InnerText) };

            XmlNodeList packageFileNodes = xml.SelectNodes("/Config/PackageFile");
            template.packageFileTemplates = new List<TemplateFile>();
            foreach (XmlNode packageFileNode in packageFileNodes)
            {
                var packageFile = new TemplateFile() { FileName = packageFileNode.InnerText, FileContents = ReadFileContents(templateDirectory + "\\" + packageFileNode.InnerText) };
                if (!String.IsNullOrEmpty(packageFile.FileContents))
                    template.packageFileTemplates.Add(packageFile);
            }

            XmlNode packageSeperatorNode = xml.SelectSingleNode("/Config/PackageSeperator");
            if(packageSeperatorNode != null)
                template.packageSeperator = packageSeperatorNode.InnerText;

            XmlNode generatePackageFolderStructureNode = xml.SelectSingleNode("/Config/GeneratePackageFolderStructure");
            if(generatePackageFolderStructureNode != null)
                template.generatePackageFolderStructure = (generatePackageFolderStructureNode.InnerText == "true");

            XmlNodeList fragmentNodes = xml.SelectNodes("/Config/Fragment");
            foreach (XmlNode fragmentNode in fragmentNodes)
            {
                var fragment = new TemplateFragment();
                var fragmentName = fragmentNode.Attributes["name"].Value;
                fragment.fragmentBody = ReadFileContents(templateDirectory + "\\" + fragmentNode.InnerText);
                
                if(fragmentName == "LocalAssignment")
                    template.localAssignmentFragment = fragment;
                else if(fragmentName == "LocalVariable")
                    template.localVariableFragment = fragment;
                else if (fragmentName == "Constant")
                    template.constantFragment = fragment;
                else if (fragmentName == "NewClassInstance")
                    template.newClassInstanceFragment = fragment;
                else if (fragmentName == "ClassProperty")
                    template.classPropertyFragment = fragment;
                else if (fragmentName == "ClassVariable")
                    template.classVariableFragment = fragment;
            }

            XmlNodeList typeNodes = xml.SelectNodes("/Config/Type");
            template.basicTypes = new Dictionary<string, string>();
            foreach (XmlNode typeNode in typeNodes)
            {
                var key = typeNode.Attributes["name"].Value;
                var value = typeNode.InnerText;
                template.basicTypes.Add(key, value);
            }

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
