using System;

namespace ModelsContinued.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
    public class Song
    {
        public string quote {get;set;}
        public string name {get;set;}
    }
}