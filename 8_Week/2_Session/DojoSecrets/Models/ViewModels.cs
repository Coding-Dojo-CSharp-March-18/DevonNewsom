using System.Collections.Generic;

namespace Secrets.Models
{
    public class DashboardModel
    {
        public List<Secret> RecentSecrets {get;set;}
        public Secret NewSecret {get;set;}
        public User LoggedInUser {get;set;}
    }
}
