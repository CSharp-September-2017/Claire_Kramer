using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;
// Pretty clean Claire.  Hope the queries are making sense.  This style of querying will pop up again later!
namespace music
{
    class Program
    {
        static void Main(string[] args)
        {
             //Collections to work with
            List<Artist> Artists = JsonToFile<Artist>.ReadJson();
            List<Group> Groups = JsonToFile<Group>.ReadJson();

            //========================================================
            //Solve all of the prompts below using various LINQ queries
            //========================================================

            //There is only one artist in this collection from Mount Vernon, what is their name and age?
            Artist FromMV = Artists.Where(artist => artist.Hometown == "Mount Vernon").Single();
            Console.WriteLine($"{0} - {1}", FromMV.ArtistName, FromMV.Age);
            //Who is the youngest artist in our collection of artists?
            Artist Youngest = Artists.OrderBy(artist => artist.Age).First();
            Console.WriteLine($"The Youngest Artist is {0} at {1} years old", Youngest.ArtistName, Youngest.Age);
            //Display all artists with 'William' somewhere in their real name
            List<Artist> William = Artists.Where(artist => artist.RealName.Contains("William")).ToList();
            foreach (var artist in William)
            {
                Console.WriteLine(artist.ArtistName +" - "+ artist.RealName);   
            }
            //Display all groups with names less than 8 characters in length
            List<Group> LessThan = Groups.Where(group => group.GroupName.Length < 8).ToList();
            foreach (var group in LessThan)
            {
                Console.WriteLine(group.GroupName);
            }
            //Display the 3 oldest artist from Atlanta
            List<Artist> AtlantasOldest = Artists.OrderByDescending(artist => artist.Age).Take(3).ToList();
            foreach (var artist in AtlantasOldest)
            {
                Console.WriteLine($"{0} - {1} years old", artist.ArtistName, artist.Age);
            }
            //(Optional) Display the Group Name of all groups that have members that are not from New York City
            List<Group> NonNY = Artists.Join(Groups, artist => artist.GroupId, group => group.Id, (artist, group) => { artist.Group = group, return artist; })
                                        .Where(artist => (artist.Hometown != "New York City" && artist.Group != null))
                                        .Select(artist => artist.Group.GroupName)
                                        .Distinct().ToList();
            foreach(var group in NonNY) {
                Console.WriteLine(group);
            }
            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'
            Group WuTang = Groups.Where(group => group.GroupName == "Wu Tang Clan")
                                    .GroupJoin(Artists, group => group.Id, artist => artist.GroupId,
                                    (group, artists) => { group.Members = artists.ToList(); return group;})
                                    .Single();
            foreach (var artist in WuTang.Members) {
                Console.WriteLine(artist.ArtistName);
            }
        }
    }
}
