using System;
using System.Collections.Generic;
using System.Text;

namespace Csharp_LINQ_methods_as_a_Backend_Developer
{
    public class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public GenderEnum Gender { get; set; }

        public override string ToString()
        {
            return $"Name: {FirstName} {LastName}, Age: {Age}, Gender: {Gender}";
        }
    }

    public enum GenderEnum
    {
        FEMALE = 1,
        MALE = 2
    };
}
