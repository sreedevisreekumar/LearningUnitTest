using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoLibrary.Models;
using System.IO;
namespace DemoLibrary
{
    public static class DataAccess
    {
        private static string personTextFile = "PersonText.txt";

        public static void AddNewPerson(PersonModel person)
        {
            List<PersonModel> people = GetAllPeople();

            AddPersonToPeopleList(people, person);

            List<string> lines = ConvertModelsToCSV(people);

            File.WriteAllLines(personTextFile, lines);
        }

        public static void AddPersonToPeopleList(List<PersonModel> people, PersonModel person)
        {
            if (string.IsNullOrWhiteSpace(person.FirstName))
            {
                throw new ArgumentException("You passed in an invalid parameter", "FirstName");
            }

            if (string.IsNullOrWhiteSpace(person.LastName))
            {
                throw new ArgumentException("You passed in an invalid parameter", "LastName");
            }

            people.Add(person);
        }

        public static List<string> ConvertModelsToCSV(List<PersonModel> people)
        {
            List<string> output = new List<string>();

            foreach (PersonModel user in people)
            {
                output.Add($"{ user.FirstName },{ user.LastName }");
            }

            return output;
        }

        public static List<PersonModel> GetAllPeople()
        {
            List<PersonModel> people = new List<PersonModel>();
            string[] content = File.ReadAllLines(personTextFile);
            GetPeopleList(content, people);
            return people;
        }

        public static void GetPeopleList(string[] content,List<PersonModel>people)
        {
            foreach (string line in content)
            {
                string[] data = line.Split(',');
                people.Add(new PersonModel { FirstName = data[0], LastName = data[1] });
            }
        }
    }
}
