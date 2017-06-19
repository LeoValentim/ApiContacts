using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ApiContacts.Models;
using System.Linq;

namespace ApiContacts.Controllers
{
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        private readonly PersonContext _context;

        public PersonController(PersonContext context)
        {
            _context = context;

            if (_context.Persons.Count() == 0)
            {
                _context.Persons.Add(new Person { 
                    name = "Contato 1",
                    lastname = "last name",
                    email = "teste@teste.com",
                    companyname = "teste",
                    telephone = "12312312332" 
                });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<Person> GetAll()
        {
            return _context.Persons.ToList();
        }

        [HttpGet("{id}", Name = "GetPerson")]
        public IActionResult GetById(long id)
        {
            var item = _context.Persons.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Person person)
        {
            if (person == null)
            {
                return BadRequest();
            }

            _context.Persons.Add(person);
            _context.SaveChanges();

            return CreatedAtRoute("GetPerson", new { id = person.Id }, person);
        }
    }
}