using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using DemoLibrary;
using DemoLibrary.Models;

namespace DemoLibrary.Tests
{
   public class DataAccessTests
    {
        [Fact]
        public void AddPersonToPeopleList_ShouldWork()
        {
            //Arrange
            PersonModel newPerson = new PersonModel { FirstName="Sree",LastName ="Devi"};
            List<PersonModel> people = new List<PersonModel>();
            //Act
            DataAccess.AddPersonToPeopleList(people, newPerson);
            //Assert
            Assert.True(people.Count == 1);
            Assert.Contains<PersonModel>(newPerson, people);
        }
        [Theory]
        [InlineData("Sree","","LastName")]
        [InlineData("","Devi","FirstName")]
        public void AddPersonToPeopleList_ShouldFail(string firstName,string lastName,string badParameter)
        {
            //Arrange
            PersonModel newPerson = new PersonModel { FirstName = firstName, LastName = lastName };
            List<PersonModel> people = new List<PersonModel>();

            //Assert exception
            Assert.Throws<ArgumentException>(badParameter, () => DataAccess.AddPersonToPeopleList(people, newPerson));
        }

        [Fact]
        public void ConvertModelsToCSV_ShouldWork()
        {
            //Arrange
            List<PersonModel> people = new List<PersonModel>
            {
                new PersonModel{FirstName ="Sree",LastName ="Devi"},
                new PersonModel{FirstName ="Sree", LastName ="Kumar"}
            };
            List<String> peopleList = new List<string>();

            //Act
            peopleList = DataAccess.ConvertModelsToCSV(people);

            //Assert

            Assert.True(peopleList.Count == 2);
            Assert.Contains<String>("Sree,Devi", peopleList);
            Assert.Contains<String>("Sree,Kumar", peopleList);


        }
    }
}
