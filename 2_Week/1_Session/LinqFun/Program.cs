using System;
using System.Collections.Generic;
using System.Linq;
namespace LinqFun
{
    class Program
    {
        static void Main(string[] args)
        {
            // "Helper Methods" / Buildins
            int[] numbers = {834,2,-23,2,103,-5,42,-1,27};

            
            // find max
            int max = numbers.Max();
            numbers.Sum();

            List<string> names = new List<string>
            {
                "Sharon",
                "Charlie",
                "Barbara",
                "Molly",
                "Ashton",
                "Marcellus",
                "John Jacob Gingleheimershchmitt",
                "Molly",
                "Bob"
            };

            // TODO: GET MARCELLUS
            int maxName = names.Max(n => n.Length);
            string longestName = names.FirstOrDefault(name => name.Length == maxName);

            // Filtering: Where, SingleOrDefault/FirstOrDefault

            // positive numbers
            var positives = numbers.Where(num => num>=0);
            List<int> listP = positives.ToList();
            int[] arrayP = positives.ToArray();

            var evens = numbers.Where(n => n%2==0);

            var msOnly = names.Where(name => name[0] == 'M');

            

            // .Select => mutates output bases on "predicate"

            // "stringify" int[]      ie. 3 => "3"
            string[] strNums = numbers.Select(num => num.ToString()).ToArray();


            List<City> cities = Place.GetCities();

            List<string> shortCityNames = cities.Select(c => c.Name)
                .Where(n => n.Length < 8).ToList();

            List<State> states = Place.GetStates();

            // ["Seattle, Washington", "Los Angeles, California"]
            string[] JoinedCityStates = cities.Join(states,
                city => city.StateCode,
                state => state.StateCode,
                (joinedCity, joinedState) => {
                    return $"{joinedCity.Name}, {joinedState.Name}";
                }).ToArray();

        }
    }
}
