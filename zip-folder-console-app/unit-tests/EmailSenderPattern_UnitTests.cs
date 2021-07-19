using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using zip_folder_console_app.SendZipFactory.SendersTypes;

namespace unit_tests
{
    public class EmailSenderPattern_UnitTests
    {
        [Fact]
        public void Send_File_Throw_Email()
        {
            //Arrange
            string outputParam = "soares1161@hotmail.com";
            string zipFilePath = @"C:\Users\Public\fileZipped.zip";

            EmailSender emailSender = new EmailSender();

            //Act
            var result = emailSender.Send(outputParam, zipFilePath);

            //Assert
            Assert.True(result, "Email not sent.");
        }
    }
}
