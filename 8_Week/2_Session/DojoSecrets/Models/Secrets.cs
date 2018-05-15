using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Secrets.Models
{
    public class Secret
    {
        [Key]
        public int secret_id {get;set;}
        public string content {get;set;}
        public DateTime created_at {get;set;}
        public int user_id {get;set;}
        public List<Like> Likes {get;set;}
        public string CreatedElapsed
        {
            get
            {
                TimeSpan elapsed = DateTime.Now - created_at;
                if(elapsed.TotalMinutes > 59)
                    return $"{elapsed.TotalHours} hours, {elapsed.TotalMinutes} minutes ago";
                return $"{elapsed.TotalMinutes} minutes ago";
            }
        }
    }

}
