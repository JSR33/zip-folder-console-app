using System;
using System.Collections.Generic;
using System.Text;

namespace zip_folder_console_app.SendZipFactory.SendersTypes
{
    public class FileShareSender : ISendZip
    {
        public bool Send(string outputParameters, string zipFilePath)
        {
            try
            {

                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }
    }
}
