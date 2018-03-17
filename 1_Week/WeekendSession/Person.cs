using System;

namespace CsOOP
{
    interface IHasName 
    {
        string Name {get;}
    }
    public class Place : IHasName
    {
        private string _name;
        public Place(string name)
        {
            _name = name;
        }
        public string Name
        {
            get{ return _name; }
        }
    }
    public class Person : IHasName
    {
        public string FirstName;
        public string LastName;
        public string Name
        {
            get {
                return $"{FirstName} {LastName}";
            }
        }
        public virtual void SayName()
        {
            Console.WriteLine($"Hi, I'm {Name}");
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
            Console.WriteLine($"I am {Name}, and gosh, {Motto}");
        }
        
    }
}