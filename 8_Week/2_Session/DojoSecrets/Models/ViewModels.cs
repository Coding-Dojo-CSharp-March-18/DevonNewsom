using System.Collections.Generic;

namespace Secrets.Models
{
    public class DashboardViewModel
    {
        public int UserId {get;set;}
        public List<Secret> AllSecrets {get;set;}
    }
}