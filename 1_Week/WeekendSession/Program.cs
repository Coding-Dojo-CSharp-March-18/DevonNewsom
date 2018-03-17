using System;
using System.Collections.Generic;

namespace CsOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person("Devon", "Newsom");
            Person person2 = new Person("Rom", "Cooley");
            Person person3 = new Person("Mars", "Fairbanks");

            Place seattle = new Place("Seattle");
            Place losAngeles = new Place("Los Angeles");
            Place hoquiam = new Place("Hoquiam");

            DebbyDowner d1 = new DebbyDowner("Swanson", "I hate mondays!");
            DebbyDowner d2 = new DebbyDowner("Orville", "Someone forgot to take out the trash");
            DebbyDowner d3 = new DebbyDowner("Sanders", "I lost my bike");

            List<IHasName> peopleAndPlaces = new List<IHasName>()
            {
                person1,
                person2,
                person3,
                d1, d2, d3,
                seattle,
                losAngeles,
                hoquiam
            };

            foreach(IHasName nThing in peopleAndPlaces)
            {
               Console.WriteLine(nThing.Name);
            }

            List<Person> peopleList = new List<Person>()
            {
                person1,
                person2,
                person3,
                d1, d2, d3,
            };

            Person[] peopleArray = new Person[]
            {
                person1,
                person2,
                person3,
                d1, d2, d3,
            };

            LoopPeople(peopleList);
            LoopPeople(peopleArray);
        }
        public static void LoopPeople(IEnumerable<Person> people)
        {
            foreach(Person p in people)
            {
                p.SayName();
            }
        }
    }
}
