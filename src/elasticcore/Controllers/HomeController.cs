using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nest;
using elasticcore.Models;

namespace elasticcore.Controllers
{
    public class HomeController : Controller
    {
        private ElasticClient client;

        public HomeController()
        {
            // default elastic search client port
            var node = new Uri("http://localhost:9200");
            var settings = new ConnectionSettings(node);
            settings.MapDefaultTypeNames(m => m.Add(typeof(Boats), "GbrBoats"));
            settings.DefaultIndex("dumasnet");
            client = new ElasticClient(settings);

        }

        public IActionResult Index()
        {

            SearchRequest<Person> sr = new SearchRequest<Person>
            {
                Query = new MatchQuery
                {
                     Field = "firstname",
                     Query = "Hubert"
                }
            };

            var searchResults = client.Search<Person>(sr);

            var searchResults2 = client.Search<Person>(s => s
                .Query(q => q.Match(m => m.Field("lastname")
                .Query("Dumas")))
            );

            var allPeople = client.Search<Person>();

            var multiResults = client.Search<Person>(s => s
              .Query(q => q.MultiMatch(c => c
                  .Fields(f => f.Field("lastname").Field("firstname"))
                  .Query("Gaye")
                ))
            );

            var multiResults2 = client.Search<Person>(s => s
              .Query(q => q.MultiMatch(c => c
                  .Fields(f => f.Field(p => p.Firstname).Field(p => p.Lastname))
                  .Query("Dumas")
                ))
            );


            IClusterHealthResponse res = client.ClusterHealth();
            return View(res);
        }

        public IActionResult Create()
        {
            // will create new type/mapping if not exist and name is 'person' (same as class name)
            //client.Index(person);

            // same as above except type/mapping name will be 'people'
            //var index = client.Index(person, i => i
            //   .Type("people")
            //   .Id(person.Id)
            //);
            //client.Index(index);


            Person person = new Models.Person
            {
                Id = 1,
                Firstname = "Lebron",
                Lastname = "Molly"
            };

            client.Index(person);

            List<Person> people = new List<Person>();
            people.Add(new Person
            {
                Id = 2,
                Firstname = "Gaye",
                Lastname = "Dumas"
            });
            people.Add(new Person
            {
                Id = 3,
                Firstname = "Barack",
                Lastname = "Obama"
            });

            client.IndexMany(people); return View();
        }

        [Route("IndexBoats")]
        public IActionResult IndexBoats()
        {
            using(var db = new BoatContext())
            {
                var boats = db.Boats.Where(x => !x.Deleted && x.Visible).ToList();
                client.IndexMany(boats);
            }

            return View();
        }

        [HttpGet("boats")]
        public IActionResult Boats()
        {
            var results = client.Search<Boats>(s => s
            .Query(q => 
                q.MultiMatch(
                    c => c.Fields(f => 
                        f.Field(p => p.MakeModel)
                        .Field(p => p.Description)
                    )
                    .Query("Scimitar")
                )
            ).Explain());

            return View(results);
        }

        [HttpPost("boats")]
        public IActionResult SearchBoats(SRequest request)
        {
            var results = client.Search<Boats>(s => s
           .Query(q =>
               q.MultiMatch(
                   c => c.Fields(f =>
                       f.Field(p => p.MakeModel)
                       .Field(p => p.Description)
                   )
                   .Query(request.Keywords)
               )
           ).Explain());

            return View("Boats", results);
        }


        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }

    public class SRequest
    {
        public string Keywords { get; set; }
    }
}
