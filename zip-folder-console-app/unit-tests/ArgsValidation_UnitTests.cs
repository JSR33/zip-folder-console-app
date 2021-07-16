using System;
using Xunit;
using zip_folder_console_app;

namespace unit_tests
{
    public class ArgsValidation_UnitTests
    {
        [Fact]
        public void Set_Values_And_Validate_Available_Path()
        {
            //Arrange

            //Act
            bool validatedString = ArgsValidation.ValidatePaths("C:\\");

            //Assert
            Assert.True(validatedString, $"Arg : C:\\");
        }

        [Fact]
        public void Set_Values_And_Validate_Unavailable_Path()
        {
            //Arrange

            //Act
            Action act = () => ArgsValidation.ValidatePaths("teste");

            //Assert
            Assert.Throws<ArgumentException>(act);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Set_Not_Accepted_Values_And_Return_False(string arg)
        {
            //Arrange

            //Act
            Action act = () => ArgsValidation.ValidatePaths(arg);

            //Assert
            Assert.Throws<ArgumentNullException>(act);
        }

        [Fact]
        public void Set_Values_And_Validate_Available_Exclusions_Array()
        {
            //Arrange

            //Act
            bool validatedString = ArgsValidation.ValidateExclusionsArrays(".pdf,.jpeg,.png");

            //Assert
            Assert.True(validatedString, $"Arg : .pdf,.jpeg,.png");
        }

        [Fact]
        public void Set_Null_As_Exclusions_Array_And_Return_False()
        {
            //Arrange

            //Act
            Action act = () => ArgsValidation.ValidateExclusionsArrays(null);

            //Assert
            Assert.Throws<ArgumentNullException>(act);
        }
    }
}
