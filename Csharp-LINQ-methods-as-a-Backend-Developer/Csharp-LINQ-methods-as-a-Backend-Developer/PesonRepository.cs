using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Csharp_LINQ_methods_as_a_Backend_Developer
{
    public class PesonRepository
    {
        private readonly List<Person> PersonContainer;
    }
        public PesonRepository()
        {
            // In Memory List for examle demonstration.
            PersonContainer = new List<Person>
            {
                new Person{FirstName = "Ibra", LastName = "Jaber", Age = 25, Gender = GenderEnum.MALE},
                new Person{FirstName = "Jacob", LastName = "Smith", Age = 15, Gender = GenderEnum.MALE},
                new Person{FirstName = "Emily", LastName = "Luke", Age = 32, Gender = GenderEnum.FEMALE},
                new Person{FirstName = "Noah", LastName = "Liam", Age = 44, Gender = GenderEnum.MALE},
                new Person{FirstName = "Iman", LastName = "tale", Age = 12, Gender = GenderEnum.FEMALE},
                new Person{FirstName = "Ben", LastName = "Armstrong", Age = 56, Gender = GenderEnum.MALE},
                new Person{FirstName = "Samantha", LastName = "Luis", Age = 22, Gender = GenderEnum.FEMALE}
            };
        }

        /// <summary>
        /// Demonstrating FirstOrDefault
        /// </summary>
        public Person FindPersonByname(string nameToSearch)
        {
            return PersonContainer.FirstOrDefault(p => p.FirstName.Contains(nameToSearch) || p.FirstName.Contains(nameToSearch));
        }

        /// <summary>
        /// Demonstrating  WHERE and SELECT
        /// </summary>
        public List<Person> SearchPeopleByName(string nameToSearch)
        {
            return PersonContainer
                .Where(p => p.FirstName.Contains(nameToSearch) || p.LastName.Contains(nameToSearch))
                .Select(p => p).ToList();
        }

        /// <summary>
        /// Demonstrating OrderBy and OrderByDecending
        /// </summary>
        public List<Person> GetPersonsOrderedByAge(bool isDesecending)
        {
            var personsOrdered = PersonContainer.OrderBy(p => p.Age).ToList();

            if (isDesecending) return personsOrdered.OrderByDescending(p => p.Age).ToList();

            return personsOrdered;
        }

        /// <summary>
        ///  Demonstrating Min
        /// </summary>
        public int GetYoungestPersonAge()
        {
            return PersonContainer.Min(p => p.Age);
        }

        /// <summary>
        /// Demonstrating Max
        /// </summary>
        public int GetOldestPersonAge()
        {
            return PersonContainer.Max(p => p.Age);
        }



        
    }
}
