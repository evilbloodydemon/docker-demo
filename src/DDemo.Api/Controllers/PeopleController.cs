using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDemo.Data;
using LinqToDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly ILogger<PeopleController> _logger;

        public PeopleController(ILogger<PeopleController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Person> Get()
        {
            using var db = new DemoDb();
            
            return db.People
                .OrderBy(x => x.ID)
                .ToList();
        }

        [HttpGet("{id:min(1)}")]
        public Person GetById(int id)
        {
            using var db = new DemoDb();
            
            return db.People
                .FirstOrDefault(x => x.ID == id);
        }
        
        [HttpPost]
        public int NewPerson([FromBody]PersonData data)
        {
            using var db = new DemoDb();
            
            return db.InsertWithInt32Identity(new Person
            {
                FirstName = data.FirstName,
                LastName = data.LastName,
                BirthDate = data.BirthDate,
            });
        }     
        
        [HttpPut("{id:min(1)}")]
        public IActionResult UpdatePerson(int id, [FromBody]PersonData data)
        {
            using var db = new DemoDb();
            
            var affected = db.Update(new Person
            {
                ID = id,
                FirstName = data.FirstName,
                LastName = data.LastName,
                BirthDate = data.BirthDate,
            });

            if (affected > 0)
                return Ok();

            return NotFound();
        }
        
        [HttpDelete("{id:min(1)}")]
        public IActionResult DeletePerson(int id)
        {
            using var db = new DemoDb();
            
            var affected = db.People.Delete(x => x.ID == id);

            if (affected > 0)
                return Ok();

            return NotFound();
        }
    }
    
    public class PersonData
    {
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
