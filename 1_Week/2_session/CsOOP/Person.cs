using System;

namespace CsOOP
{
    public class Person
    {
        public string FirstName;
        public string LastName;
        public string FullName
        {
            get {
                return $"{FirstName} {LastName}";
            }
        }
        public virtual void SayName()
        {
            Console.WriteLine($"Hi, I'm {FullName}");
        }
        public Person(string first, string last)
        {
            FirstName = first;
            LastName = last;
        }
    }
    public class DebbyDowner : Person
    {
        public string Motto;
        // base("Debby", last) > new Person(first, last)
        public DebbyDowner(string last, string motto) : base("Debby", last)
        {
            Motto = motto;
        }
        public new void SayName()
        {
            Console.WriteLine($"I am {FullName}, and gosh, {Motto}");
        }
        
    }
}