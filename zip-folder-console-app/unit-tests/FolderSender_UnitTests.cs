using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using zip_folder_console_app.SendZipFactory.SendersTypes;

namespace unit_tests
{
    public class FolderSender_UnitTests
    {
        [Fact]
        public void Move_Zip_File_To_Final_Folder()
        {
            //Arrange
            FolderSender folderSender = new FolderSender();

            //ACT
            bool result = folderSender.Send(@"C:\TempFiles\backup.zip", @"C:\Users\Public\zipped.zip");

            //Assert
            Assert.True(result, "File not moved to output");
        }

        [Fact]
        public void Send_Empty_Destination_Return_False()
        {
            //Arrange
            FolderSender folderSender = new FolderSender();

            //ACT
            bool result = folderSender.Send(@"", @"C:\Users\Public\zipped.zip");

            //Assert
            Assert.False(result);
        }
    }
}
