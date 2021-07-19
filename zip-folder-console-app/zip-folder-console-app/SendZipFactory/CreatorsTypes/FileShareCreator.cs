using System;
using System.Collections.Generic;
using System.Text;
using zip_folder_console_app.SendZipFactory.SendersTypes;

namespace zip_folder_console_app.SendZipFactory.CreatorsTypes
{
    internal class FileShareCreator : SendCreator
    {
        public override ISendZip FactoryMethod()
        {
            return new FileShareSender();
        }
    }
}
