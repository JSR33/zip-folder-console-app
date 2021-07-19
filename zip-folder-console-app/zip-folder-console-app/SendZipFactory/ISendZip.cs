using System;
using System.Collections.Generic;
using System.Text;

namespace zip_folder_console_app.SendZipFactory
{
    interface ISendZip
    {
        bool Send(string outputParameters, string zipFilePath);
    }
}
