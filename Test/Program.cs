using System;
using System.Security.Authentication;

namespace Test
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Hunter h1 = new  Hunter("John", "Doe", 1);
        }
    }
    class Person
    {
        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    class Hunter : Person
    {
        public Hunter(string firstName, string lastName, int gun) : base(firstName, lastName)
        {
            Gun = gun;
        }
        public int Gun { get; set; }
        
    }
}