using System;
using System.Collections.Generic;

namespace elasticcore.Models
{
    public partial class Logs
    {
        public int LogId { get; set; }
        public int LogType { get; set; }
        public string LogText { get; set; }
        public DateTime LogDate { get; set; }
    }
}
