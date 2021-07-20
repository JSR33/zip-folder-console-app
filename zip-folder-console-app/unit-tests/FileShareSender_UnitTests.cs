using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using zip_folder_console_app.SendZipFactory.SendersTypes;

namespace unit_tests
{
    public class FileShareSender_UnitTests
    {
        [Fact]
        public void Send_File_To_Valid_FileShare_Folder()
        {
            //Arrange
            FileShareSender fileShareSender = new FileShareSender();

            //Act
            bool result = fileShareSender.Send(@"\\192.168.3.6\Maeil\Backup\zipped.zip", @"C:\Users\Public\TestesAppZip\zipped.zip");

            //Assert
            Assert.True(result, "File not moved with success");
        }

        [Fact]
        public void Send_File_To_Not_Valid_FileShare_Folder()
        {
            //Arrange
            FileShareSender fileShareSender = new FileShareSender();

            //Act
            fileShareSender.Send(@"\\192.168.3.5\Maeil\Backup\zipped.zip", @"C:\Users\Public\TestesAppZip\zipped.zip");

            //Assert
            Assert.False(result, "File not moved with success");
        }
    }
}
