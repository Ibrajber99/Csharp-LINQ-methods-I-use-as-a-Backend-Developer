using System;

namespace Csharp_LINQ_methods_as_a_Backend_Developer
{
    class Program
    {
        static void Main(string[] args)
        {
            var personRepository = new PesonRepository();

            Console.WriteLine("Demonstrating FirstOrDefault");

            Console.WriteLine(personRepository.FindPersonByname("Ibra").ToString());

            Console.WriteLine("============================\n");

            Console.WriteLine("Demonstrating WHERE and SELECT");

            foreach (var person in personRepository.SearchPeopleByName("i"))
            {
                Console.WriteLine(person.ToString());
            }

            Console.WriteLine("============================\n");

            Console.WriteLine("Demonstrating OrderBy");

            foreach (var person in personRepository.GetPersonsOrderedByAge(isDesecending: false))
            {
                Console.WriteLine(person.ToString());
            }

            Console.WriteLine("============================\n");


            Console.WriteLine("Demonstrating OrderByDecending");

            foreach (var person in personRepository.GetPersonsOrderedByAge(isDesecending: true))
            {
                Console.WriteLine(person.ToString());
            }

            Console.WriteLine("============================\n");

            Console.WriteLine("Demonstrating MIN");

            Console.WriteLine(personRepository.GetYoungestPersonAge().ToString());

            Console.WriteLine("============================\n");

            Console.WriteLine("Demonstrating MAX");

            Console.WriteLine(personRepository.GetOldestPersonAge().ToString());

            Console.WriteLine("============================\n");
        }
    }
}
