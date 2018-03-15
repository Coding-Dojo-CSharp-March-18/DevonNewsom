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

            DebbyDowner d1 = new DebbyDowner("Swanson", "I hate mondays!");
            DebbyDowner d2 = new DebbyDowner("Orville", "Someone forgot to take out the trash");
            DebbyDowner d3 = new DebbyDowner("Sanders", "I lost my bike");

            List<Person> people = new List<Person>()
            {
                person1,
                person2,
                person3,
                d1, d2, d3
            };

            foreach(Person p in people)
            {
                if(p is DebbyDowner)
                {
                    (p as DebbyDowner).SayName();
                }
                else
                    p.SayName();
            }

            d2.SayName();
            
        }
    }
}
