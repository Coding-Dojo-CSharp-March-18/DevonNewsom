using System.Collections.Generic;
namespace weekend_session
{
    public class Friend
    {
        public string name;
        public string location;
        public Friend(string n, string l)
        {
            name = n;
            location = l;
        }
        public static List<Friend> MakeFriends()
        {
            return new List<Friend>()
            {
                new Friend("Devon", "Seattle"),
                new Friend("Jason", "Tacoma"),
                new Friend("Minh", "Everett"),
                new Friend("Todd", "Bothell")
            };
        }
    }
}