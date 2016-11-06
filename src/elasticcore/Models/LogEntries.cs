using System;
using System.Collections.Generic;

namespace elasticcore.Models
{
    public partial class LogEntries
    {
        public int Id { get; set; }
        public string MachineName { get; set; }
        public string SiteName { get; set; }
        public DateTime Logged { get; set; }
        public string Level { get; set; }
        public string UserName { get; set; }
        public string Message { get; set; }
        public string Logger { get; set; }
        public string Properties { get; set; }
        public string ServerName { get; set; }
        public string Port { get; set; }
        public string Url { get; set; }
        public bool? Https { get; set; }
        public string ServerAddress { get; set; }
        public string RemoteAddress { get; set; }
        public string Callsite { get; set; }
        public string Exception { get; set; }
    }
}
