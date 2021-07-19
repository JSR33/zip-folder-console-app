using System;
using System.Collections.Generic;
using System.Text;

namespace zip_folder_console_app.SendZipFactory.SendersTypes
{
    internal class EmailSender: ISendZip
    {
        public bool Send(string outputParameters, string zipFilePath)
        {
            return true;
        }
    }
}
