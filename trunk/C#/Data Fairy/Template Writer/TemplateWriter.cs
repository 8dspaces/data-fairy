﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

namespace net.mkv25.writer
{
    public class TemplateWriter
    {
        /** name of this template */
        public string name;

        /** author of the template */
        public string author;

        /** contact info for this template */
        public string contact;

        /** The template for the database file */
        public TemplateFile dataBaseFileTemplate;

        /** The template for individual table class files */
        public TemplateFile tableFileTemplate;

        /** The template for individual row class files */
        public TemplateFile rowFileTemplate;

        /** The template for enumeration lists */
        public TemplateFile enumerationFileTemplate;

        /** Any other template files that exist in the package */
        public List<TemplateFile> packageFileTemplates;
        
        /** A list of strings to search and replace on */
        public List<KeyValuePair<string, string>> templateVariables;

        /** The dataset to base the code generation on */
        public DataSet sourceDataSet;

        /* A list of messages generated during the write process */
        public List<KeyValuePair<DateTime, string>> logMessages;

        /** The seperator to use between generated package paths */
        public string packageSeperator;

        /** Should the code template generate folders that match the package structure */
        public bool generatePackageFolderStructure;

        /** A fragment for variable assignment */
        public TemplateFragment localVariableFragment;

        /** A fragment for defining a constant */
        public TemplateFragment constantFragment;

        /** A fragment for variable assignment */
        public TemplateFragment localAssignmentFragment;

        /** A fragment for writing new class instances */
        public TemplateFragment newClassInstanceFragment;

        /** A fragment for writing new static variables */
        public TemplateFragment classVariableFragment;

        /** The package path to use for code generation */
        public string packageString;

        public TemplateWriter()
        {
            templateVariables = new List<KeyValuePair<string, string>>();
        }

        /**
         * Generate code from templates into the specified directory.
         */
        public void WriteTo(string outputDirectory)
        {
            logMessages = new List<KeyValuePair<DateTime, string>>();

            Log("Starting Write Process");

            // delete down files that already exist
            var directoryBrowser = new DirectoryInfo(outputDirectory);
            directoryBrowser.GetFiles("*", SearchOption.AllDirectories).ToList().ForEach(file => file.Delete());

            // check to see if a folder structure needs generating for the packages
            if (generatePackageFolderStructure)
            {
                var packagePath = new StringBuilder();
                var packagePathArray = packageString.Split(packageSeperator.ToCharArray());
                foreach (var packagePart in packagePathArray)
                {
                    packagePath.Append(packagePart + "\\");
                }
                outputDirectory = outputDirectory + "\\" + packagePath.ToString();
            }
            
            // do the work
            WriteEnumerations(outputDirectory);
            WriteTableFiles(outputDirectory);
            WriteDatabaseFile(outputDirectory);
            WritePackageFiles(outputDirectory);

            Log("Finished Write Process");
        }

        /**
         * Generate enumeration files for all rows in all tables in the dataset using a template file.
         */
        public void WriteEnumerations(string outputDirectory)
        {
            if (enumerationFileTemplate == null)
                return;

            string fileName;
            string EXT = Path.GetExtension(enumerationFileTemplate.FileName);
            foreach(DataTable table in sourceDataSet.Tables)
            {
                var enumerationName = NameUtils.FormatClassName(table.TableName) + "Enum";
                fileName = enumerationName + "." + EXT;
                // TODO: Write individual enumeration files
                // TODO: Write individual enumeration rows
                // TODO: Replace standard set of variables
            }
        }

        /**
         * Generate class files for all row types in the dataset using a template file
         */
        public void WriteRowFiles(string outputDirectory)
        {
            if (rowFileTemplate == null)
                return;

            string fileName;
            string FOLDER = Path.GetDirectoryName(rowFileTemplate.FileName);
            string EXT = Path.GetExtension(rowFileTemplate.FileName);
            foreach (DataTable table in sourceDataSet.Tables)
            {
                var className = NameUtils.FormatClassName(table.TableName) + "Row";
                fileName = className + EXT;

                // build the file
                StringBuilder fileContents = new StringBuilder(rowFileTemplate.FileContents);
                StringBuilder propertyList = new StringBuilder();
                StringBuilder variableList = new StringBuilder();

                // populate individual data rows

                // replace standard set of variables
                ReplaceVariables(fileContents, templateVariables);
                fileContents.Replace("PACKAGE_STRING", packageString);
                fileContents.Replace("CLASS_NAME", className);
                fileContents.Replace("PROPERTY_LIST", propertyList.ToString());
                fileContents.Replace("VARIABLE_LIST", variableList.ToString());

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
            if (tableFileTemplate == null)
                return;

            string fileName;
            string FOLDER = Path.GetDirectoryName(tableFileTemplate.FileName);
            string EXT = Path.GetExtension(tableFileTemplate.FileName);
            foreach (DataTable table in sourceDataSet.Tables)
            {
                var className = NameUtils.FormatClassName(table.TableName) + "Table";
                fileName = className + EXT;

                // build the file
                StringBuilder fileContents = new StringBuilder(tableFileTemplate.FileContents);
                StringBuilder rowList = new StringBuilder();

                // populate individual data rows

                // replace standard set of variables
                ReplaceVariables(fileContents, templateVariables);
                fileContents.Replace("PACKAGE_STRING", packageString);
                fileContents.Replace("CLASS_NAME", className);
                fileContents.Replace("ROW_LIST", rowList.ToString());

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
            if(dataBaseFileTemplate == null)
                return;

            // check prerequisites
            if (newClassInstanceFragment == null)
            {
                Log("No class instance fragment available to write database template.");
                return;
            }
            if (localAssignmentFragment == null)
            {
                Log("No local assignment fragment available to write database template.");
            }

            string fileName = dataBaseFileTemplate.FileName;
            StringBuilder fileContents = new StringBuilder(dataBaseFileTemplate.FileContents);

            StringBuilder variableList = new StringBuilder();
            variableList.AppendLine("// code generated list of all tables");
            foreach (DataTable table in sourceDataSet.Tables)
            {
                var className = NameUtils.FormatClassName(table.TableName) + "Table";
                var classValue = newClassInstanceFragment.WriteNewClassInstance(className, "");
                var varName = NameUtils.FormatClassName(table.TableName).ToUpper();
                variableList.AppendLine(classVariableFragment.WriteClassVariable(varName, className));
            }

            StringBuilder classList = new StringBuilder();
            classList.AppendLine("// code generated list of all tables");
            foreach (DataTable table in sourceDataSet.Tables)
            {
                var className = NameUtils.FormatClassName(table.TableName) + "Table";
                var classValue = newClassInstanceFragment.WriteNewClassInstance(className, "");
                var varName = NameUtils.FormatClassName(table.TableName).ToUpper();
                classList.AppendLine(localAssignmentFragment.WriteLocalAssignment(varName, classValue));
            }

            // replace standard set of variables
            ReplaceVariables(fileContents, templateVariables);
            fileContents.Replace("VARIABLE_LIST", variableList.ToString());
            fileContents.Replace("CLASS_LIST", classList.ToString());
            fileContents.Replace("PACKAGE_STRING", packageString);

            // write the file
            var filePath = outputDirectory + "\\" + dataBaseFileTemplate.FileName;
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            StreamWriter writer = new StreamWriter(filePath);
            writer.Write(fileContents);
            writer.Close();

            Log("Created Database File - " + dataBaseFileTemplate.FileName);
        }

        public void WritePackageFiles(string outputDirectory)
        {
            string fileName;
            StringBuilder fileContents;
            StreamWriter writer;

            foreach (TemplateFile packageFileTemplate in packageFileTemplates)
            {
                // work out the file name
                fileName = packageFileTemplate.FileName;
                fileContents = new StringBuilder(packageFileTemplate.FileContents);

                // build the file contents
                ReplaceVariables(fileContents, templateVariables);
                fileContents.Replace("PACKAGE_STRING", packageString);

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
            logMessages.Add(log);
        }
    }
}