using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WebBirthdayApp.Models;

namespace WebBirthdayApp.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class PersonController : ControllerBase
{

    public static List<Person> PersonList = new List<Person>
    {
        new Person
        {
            Id = 1,
            Name = "Abobus",
            SecondName = "Azimov",
            Birthday = new DateOnly(2000,12,1)
        },
        new Person
        {
            Id = 2,
            Name = "Abobus",
            SecondName = "Azimov",
            Birthday = new DateOnly(2000,12,1)
        },
        new Person
        {
            Id = 3,
            Name = "Abobus",
            SecondName = "Azimov",
            Birthday = new DateOnly(2000,12,1)
        }
    };
    
    [HttpGet("get")]
    public List<Person> GetAll()
    {
        return PersonList;
    }
    
    [HttpPost("create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<Person> create([FromBody]Person? p)
    {
        if (p == null)
            return BadRequest();
        
        PersonList.Add(p);
        
        return CreatedAtRoute("get", new {id = p.Id}, p);
    }
    
    [HttpPatch]
    [Route("{id:int}/patch")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    
    public ActionResult<Person> Patch(int id, [FromBody]JsonPatchDocument<Person>? model)
    {
        if (id < 0 || model == null)
            return BadRequest();

        var p = PersonList.FirstOrDefault(p => p.Id == id);

        if (p == null)
            return NotFound();
        
        model.ApplyTo(p, ModelState);
        
        if(!ModelState.IsValid)
            return BadRequest(ModelState);
        
        return NoContent();
    }
    
    [HttpGet]
    [Route("{id:int}", Name = "get")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Person?> GetById(int id)
    {
        var p = PersonList.FirstOrDefault(p => p.Id == id);
        if (p == null)
        {
            return NotFound();
        }

        return Ok(p);
    }
}