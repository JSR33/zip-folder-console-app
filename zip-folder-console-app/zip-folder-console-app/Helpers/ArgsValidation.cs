using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace zip_folder_console_app
{
    public static class ArgsValidation
    {
        public static bool ValidatePaths(string arg)
        {
            if (string.IsNullOrWhiteSpace(arg))
            {
                throw new ArgumentNullException("Argument (folder path) cannot be null or empty");
            }
            if (!Directory.Exists(arg))
            {
                throw new ArgumentException("The path is not valid or does not exist.");
            }
             
            return true;
        }

        public static bool ValidateExclusionsArrays(string arg)
        {
            if (arg == null)
            {
                throw new ArgumentNullException("Argument (string array) cannot be null");
            }
            
            return true;
        }
    }
}
