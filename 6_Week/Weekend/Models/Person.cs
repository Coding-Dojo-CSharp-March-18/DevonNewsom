using System;
namespace DITest.Models
{
    public class Person
    {
        public static string[] Names = 
        {
            "Ray", "Jason", "Jessica", "Susan", "Minh", "Devon", "Sally"
        };
        public string Name {get;set;}
        public Dog BestFriend {get;set;}
        public Person(Dog dog)
        {
            Random rand = new Random();
            Name = Names[rand.Next(Names.Length)];
            BestFriend = dog;
        }
    }
    

}

