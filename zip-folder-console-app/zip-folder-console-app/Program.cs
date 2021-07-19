using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text.RegularExpressions;
using zip_folder_console_app.SendZipFactory;
using zip_folder_console_app.SendZipFactory.CreatorsTypes;

namespace zip_folder_console_app
{
    public class Program
    {
        public static string _folderToZip;
        public static string _zipFolderName;
        public static string[] _excludedExtensions;
        public static string[] _excludedDirectories;
        public static string[] _excludedFiles;
        public static int _outputType;
        public static string _outputParameters;

        static void Main(string[] args)
        {
            try
            {
                if (ArgsValidation.ValidatePaths(args[0]))
                    _folderToZip = args[0];
                //if (ArgsValidation.ValidatePaths(args[1]))
                    _zipFolderName = args[1];
                if (ArgsValidation.ValidateExclusionsArrays(args[2]))
                    _excludedExtensions = args[2].Split(',');
                if (ArgsValidation.ValidateExclusionsArrays(args[3]))
                    _excludedDirectories = args[3] == "" ? new string[] { } : args[3].Split(',');
                if (ArgsValidation.ValidateExclusionsArrays(args[4]))
                    _excludedFiles = args[4].Split(',');
                if (!string.IsNullOrEmpty(args[5]))
                    _outputType = Convert.ToInt32(args[5]);
                else throw new ArgumentNullException("Output Type is null or empty.");


                ZipServer server = new ZipServer();
                server.Zip(_folderToZip, _zipFolderName, _excludedExtensions, _excludedDirectories, _excludedFiles);

                SendFile sendFile = new SendFile();
                sendFile.Send(_outputType, _outputParameters, _zipFolderName);
            }
            catch(Exception e)
            {
                Console.WriteLine($"ERROR - {e.Message}");
            }
        }
    }
}
