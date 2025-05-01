using CRUDBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        //Static list of person
        private static List<Person> people = new List<Person>();

        //constructor
        public PersonController()
        {
            people.Add(new Person { Id = 1, Name = "Saif", Gender = "Male", Address = "Karachi" });
            people.Add(new Person { Id = 2, Name = "Ali", Gender = "Male", Address = "Lahore" });
            people.Add(new Person { Id = 3, Name = "Khan", Gender = "Male", Address = "Islamabad" });
        }

        //Create Person //Add Person
        [HttpPost]
        public async Task<ActionResult<Person>> AddPerson(Person person)
        {
            people.Add(person);
            return CreatedAtAction(nameof(GetPerson), new { id = person.Id }, person);
        }


        //Get Person By ID // Read Person
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            var person = people.FirstOrDefault(x => x.Id == id);
            if (person == null)
            {
                return NotFound();
            }
            return person;
        }


        //delete Person // remove Person
        [HttpDelete("{id}")]
        public async Task<ActionResult<Person>> DeletePerson(int id)
        {
            var person = people.FirstOrDefault(x => x.Id == id);
            if (person == null)
            {
                return NotFound();
            }
            people.Remove(person);
            return person;
        }


        //Update Person
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson(int id, Person person)
        {
            if (id != person.Id)
            {
                return BadRequest();
            }

            var personToBeUpdated = people.FirstOrDefault(x => x.Id == person.Id);
            if (personToBeUpdated == null)
            {
                return NotFound();
            }

            personToBeUpdated.Name = person.Name;
            personToBeUpdated.Gender = person.Gender;
            personToBeUpdated.Address = person.Address;

            return NoContent();
        }
    }
}