using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace zip_folder_console_app.SendZipFactory.SendersTypes
{
    public class FolderSender : ISendZip
    {
        public bool Send(string outputParameters, string zipFilePath)
        {
            try
            {
                if (string.IsNullOrEmpty(outputParameters))
                    throw new ArgumentNullException("Destination folder must be declared");
                
                if (File.Exists(outputParameters))
                    File.Delete(outputParameters);

                File.Move(zipFilePath, outputParameters);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR - " + e.Message);
                return false;
            }
        }
    }
}
