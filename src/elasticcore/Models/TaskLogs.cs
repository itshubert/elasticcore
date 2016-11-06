using System;
using System.Collections.Generic;

namespace elasticcore.Models
{
    public partial class TaskLogs
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime RunTime { get; set; }
        public string Message { get; set; }
    }
}
