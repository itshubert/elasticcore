using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nest;

namespace elasticcore.Models
{
    [ElasticsearchType(IdProperty = "Id", Name ="people")]
    public class Person
    {
        
        public int Id { get; set; }
        public string Firstname {get;set;}
        public string Lastname { get; set; }
    }

    
}
