using System;

namespace zip_folder_console_app
{
    public class Program
    {
        private static string _folderToZip;
        private static string _zipFolderName;
        private static string[] _excludedExtensions;
        private static string[] _excludedDirectories;
        private static string[] _excludedFiles;
        private static string _outputType;
        private static string _outputParameters;

        static void Main(string[] args)
        {
            try
            {
                if (ArgsValidation.ValidatePaths(args[0]))
                    _folderToZip = args[0];
                if (ArgsValidation.ValidatePaths(args[1]))
                    _zipFolderName = args[1];
                if (ArgsValidation.ValidateExclusionsArrays(args[2]))
                    _excludedExtensions = args[2].Split(',');
                if (ArgsValidation.ValidateExclusionsArrays(args[3]))
                    _excludedDirectories = args[3].Split(',');
                if (ArgsValidation.ValidateExclusionsArrays(args[4]))
                    _excludedFiles = args[4].Split(',');
            }
            catch(Exception e)
            {
                Console.WriteLine($"ERROR - {e.Message}");
            }
        }
    }
}
