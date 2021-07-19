using System;
using System.Collections.Generic;
using System.Text;
using zip_folder_console_app.SendZipFactory.SendersTypes;

namespace zip_folder_console_app.SendZipFactory.CreatorsTypes
{
    internal class FolderCreator : SendCreator
    {
        public override ISendZip FactoryMethod()
        {
            return new FolderSender();
        }
    }
}
