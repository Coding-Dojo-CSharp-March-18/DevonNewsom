using System;

namespace DITest
{
    public class Dog
    {
        public static string[] Names = 
        {
            "Maxine", "Murphy", "Sterling", "Wanda", "Lil Paw"
        };
        public static string[] Breeds = 
        {
            "West Highland Terrier",
            "Chihuahua",
            "Rotweiler",
            "Doberman"
        };
        public static string[] Personalities = 
        {
            "Chill", "Barky", "Slow", "A genious, emotionally"
        };
        public string Name {get;set;}
        public string Breed {get;set;}
        public string Personality {get;set;}

        // Constructor takes no args, creates a random dog
        public Dog()
        {
            Random rand = new Random();
            Name = Names[rand.Next(Names.Length)];
            Breed = Breeds[rand.Next(Breeds.Length)];
            Personality = Personalities[rand.Next(Personalities.Length)];
        }
    }

}