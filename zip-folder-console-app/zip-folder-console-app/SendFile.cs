using System;
using System.Collections.Generic;
using System.Text;
using zip_folder_console_app.SendZipFactory;
using zip_folder_console_app.SendZipFactory.CreatorsTypes;

namespace zip_folder_console_app
{
    public class SendFile
    {
        public void Send(int outputType, string outputParameters, string zipFilePath)
        {
            SendCreator sender;

            switch (outputType)
            {
                case 1:
                    sender = new EmailCreator();
                    break;
                default:
                    throw new Exception("Output type not valid");
            }

            sender.SendZippedFolder(outputParameters, zipFilePath);
        }
    }
}
