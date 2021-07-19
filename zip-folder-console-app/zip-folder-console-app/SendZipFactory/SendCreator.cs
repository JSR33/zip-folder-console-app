using System;
using System.Collections.Generic;
using System.Text;

namespace zip_folder_console_app.SendZipFactory
{
    abstract class SendCreator
    {
        public abstract ISendZip FactoryMethod();

        public bool SendZippedFolder(string outputParameters, string zipFilePath)
        {
            var sender = FactoryMethod();
            return sender.Send(outputParameters, zipFilePath);
        }
    }
}
