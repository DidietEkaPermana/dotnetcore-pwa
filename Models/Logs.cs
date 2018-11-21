using System;
using System.Collections.Generic;

namespace AppCore.Models
{
    public partial class Logs
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Menu { get; set; }
        public string SubMenu { get; set; }
        public string Action { get; set; }
        public string Parameter1 { get; set; }
        public string Parameter2 { get; set; }
        public string Parameter3 { get; set; }
        public string Payload { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime EventTime { get; set; }
    }
}
