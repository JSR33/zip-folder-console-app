using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using zip_folder_console_app;

namespace unit_tests
{
    public class ZipServer_UnitTests
    {
        [Theory]
        [InlineData("C:\\Users\\Public\\TestesAppZip", "C:\\Users\\Public\\TestesAppZip\\New Text Document.txt", "")]
        public void File_In_Root_Return_No_Upper_Directory(string source, string a, string b)
        {
            //Arrange
            ZipServer server = new ZipServer();

            //Act
            server.

            //Assert

        }

        
    }
}
