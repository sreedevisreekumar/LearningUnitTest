using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoLibrary;
using Xunit;
using System.IO;

namespace DemoLibrary.Tests
{
   public class ExamplesTests
    {
        [Fact]
        public void ExampleLoadTextFile_ValidNameShouldWork()
        {
            //Arrange
            string fileName = "File name with more than 10 characters";
            string expected = "The file was correctly loaded.";
            //Act

            var actual = Examples.ExampleLoadTextFile(fileName);

            //Assert

            Assert.Equal(expected, actual);
            Assert.True(actual.Length > 0);
                
         }

        [Fact]
        public void ExampleLoadTextFile_InValidNameShouldFail()
        {

            //Assert
            Assert.Throws<ArgumentException>("file",() => Examples.ExampleLoadTextFile(""));

        }
    }
}
