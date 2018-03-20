using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = JsonToFile<Artist>.ReadJson();
            List<Group> Groups = JsonToFile<Group>.ReadJson();

            //========================================================
            //Solve all of the prompts below using various LINQ queries
            //========================================================

            //There is only one artist in this collection from Mount Vernon, what is their name and age?
            Artist MV = Artists.Where( artist => artist.Hometown == "Mount Vernon").SingleOrDefault();
            System.Console.WriteLine($"{MV.ArtistName}, {MV.Age}");   

            //Who is the youngest artist in our collection of artists?
            System.Console.WriteLine($"{Artists.Where( artist => artist.Age == Artists.Min( a => a.Age)).SingleOrDefault().ArtistName} is the youngest");

            //Display all artists with 'William' somewhere in their real name
            List<Artist> williams = Artists.Where(artist => artist.RealName.Contains("William")).ToList();
            foreach(Artist will in williams)
            {
                System.Console.WriteLine(will.ArtistName);
            }

            //Display the 3 oldest artist from Atlanta
            List<Artist> old = Artists.OrderByDescending( a => a.Age).Take(3).ToList();

            //(Optional) Display the Group Name of all groups that have members that are not from New York City
            List<Group> NonNewYorkGroups = Artists
                                .Join(Groups, artist => artist.GroupId, group => group.Id, (artist, group) => { artist.Group = group; return artist;})
                                .Where(artist => (artist.Hometown != "New York City" && artist.Group != null))
                                .Select(artist => artist.Group)
                                .Distinct()
                                .ToList();
            
            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'
        }
    }
}
