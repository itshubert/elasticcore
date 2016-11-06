using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace elasticcore.Models
{
    public class Post
    {
        public string Id { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? Score { get; set; }
        public int? AnswerCount { get; set; }
        public string Body { get; set; }
        public string Title { get; set; }

        [Text(Index = false)]
        public IEnumerable<string> Tags { get; set; }

        [Completion]
        public IEnumerable<string> Suggest { get; set; }
    }


}
