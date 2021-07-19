using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;
using zip_folder_console_app;

namespace unit_tests
{
    public class ZipServer_UnitTests
    {
        [Theory]
        [InlineData("C:\\Users\\Public\\TestesAppZip", "C:\\Users\\Public\\fileZipped.zip")]
        public void Create_Zip_From_Folder_Without_Restrictions(string source, string destination)
        {
            //Arrange
            ZipServer server = new ZipServer();

            //Act
            server.Zip(source, destination, new string[0], new string[0], new string[0]);
            bool result = File.Exists(destination);

            //Assert
            Assert.True(result, "Zip folder without restrictions not created");
        }

        [Theory]
        [InlineData("C:\\Users\\Public\\TestesAppZip", "C:\\Users\\Public\\fileZipped.zip", new string[] { ".txt" })]
        [InlineData("C:\\Users\\Public\\TestesAppZip", "C:\\Users\\Public\\fileZipped.zip", new string[] { ".xml" })]
        public void Create_Zip_From_Folder_With_Extension_Restrictions(string source, string destination, string[] extensionRestriction)
        {
            //Arrange
            ZipServer server = new ZipServer();

            //Act
            server.Zip(source, destination, extensionRestriction, new string[0], new string[0]);
            var zipFile = ZipFile.Read(destination);
            bool result = zipFile.Any(entry => entry.FileName.EndsWith(extensionRestriction[0]));
            
            //Assert
            Assert.False(result, $"Zip folder with extention '{extensionRestriction[0]}' restriction wasn't created or is copying files with this extension");
        }

        [Theory]
        [InlineData("C:\\Users\\Public\\TestesAppZip", "C:\\Users\\Public\\fileZipped.zip", new string[] { "Folder1" })]
        [InlineData("C:\\Users\\Public\\TestesAppZip", "C:\\Users\\Public\\fileZipped.zip", new string[] { "Folder2" })]
        public void Create_Zip_From_Folder_With_FolderName_Restrictions(string source, string destination, string[] folderRestriction)
        {
            //Arrange
            ZipServer server = new ZipServer();

            //Act
            server.Zip(source, destination, new string[0], folderRestriction, new string[0]);
            var zipFile = ZipFile.Read(destination);
            bool result = zipFile.Any(entry => entry.FileName.Contains(folderRestriction[0]));

            //Assert
            Assert.False(result, $"Zip folder with directory name '{folderRestriction[0]}' restriction wasn't created or is copying directories with this name.");
        }

        [Theory]
        [InlineData("C:\\Users\\Public\\TestesAppZip", "C:\\Users\\Public\\fileZipped.zip", new string[] { "New Microsoft Excel Worksheet" })]
        public void Create_Zip_From_Folder_With_FileName_Restrictions(string source, string destination, string[] fileRestriction)
        {
            //Arrange
            ZipServer server = new ZipServer();

            //Act
            server.Zip(source, destination, new string[] { "" }, new string[] { "" }, fileRestriction);
            var zipFile = ZipFile.Read(destination);
            bool result = zipFile.Any(entry => entry.FileName.Contains(fileRestriction[0]));

            //Assert
            Assert.False(result, $"Zip folder with file name '{fileRestriction[0]}' restriction wasn't created or is copying directories with this name.");
        }

    }
}
