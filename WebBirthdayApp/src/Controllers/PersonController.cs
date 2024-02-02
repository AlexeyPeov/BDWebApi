using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebBirthdayApp.Database;
using WebBirthdayApp.Models;

namespace WebBirthdayApp.Controllers;

[Route("/api/people")]
[ApiController]
public class PersonController : ControllerBase
{

    public PersonController(ILogger<PersonController> logger, PersonDbContext conn)
    {
        _logger = logger;
        _connection = conn;
    }

    [HttpGet("{pageNum:int?}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<List<Person>> Index(string? s, int? pageNum = null)
    {
        pageNum ??= 0;
        
        if (pageNum < 0)
            return BadRequest("Bad page number");
        
        
        if (s == null)
        {
            return Ok(_connection.Person
                .Skip(PageSize * pageNum.Value)
                .Take(PageSize).ToList()
            );
        }
        
        if(s != "bd")
            return BadRequest("Bad sort type, only \"bd\" allowed");
        
        var comp = DateTime.Today;
        IQueryable<Person> q = from p in _connection.Person
            orderby 
                p.Birthday.Month < comp.Month || 
                    (p.Birthday.Month == comp.Month && p.Birthday.Day < comp.Day), 
                p.Birthday.Month, 
                p.Birthday.Day
            select p;
        
        return Ok(q.Skip(PageSize * pageNum.Value).Take(PageSize).ToList());
    }
    
    [HttpPost("create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<Person> create([FromBody]Person? p)
    {
        if (p == null)
            return BadRequest();
        
        var person = Person.CreateCopyNoId(p);
        
        _connection.Person.Add(person);
        
        bool err = CheckForErrorsAndSave();

        if (err)
            return StatusCode(StatusCodes.Status500InternalServerError);
        
        return CreatedAtRoute("get", new {id = person.Id}, person);
    }

    [HttpPut]
    [Route("{id:int}/update")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public ActionResult<Person> update(int id, [FromBody] Person? model)
    {
        if (model == null)
            return BadRequest();

        var person = _connection.Person.FirstOrDefault(p => p.Id == id);

        if (person == null)
            return NotFound();
        
        Person.CopyPerson(model, ref person);
            
        bool good = TryValidateModel(person);
        
        if(!good)
            return BadRequest(ModelState);
        
        bool err = CheckForErrorsAndSave();

        if (err)
            return StatusCode(StatusCodes.Status500InternalServerError);
        
        return NoContent();
    }
    
    [HttpPatch]
    [Route("{id:int}/patch")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public ActionResult<Person> Patch(int id, [FromBody]JsonPatchDocument<Person>? model)
    {
        if (id < 0 || model == null)
            return BadRequest();

        var p = _connection.Person.FirstOrDefault(p => p.Id == id);

        if (p == null)
            return NotFound();
        
        model.ApplyTo(p, ModelState);
        bool valid = TryValidateModel(p);
        
        if(!ModelState.IsValid || !valid)
            return BadRequest(ModelState);

        bool err = CheckForErrorsAndSave();

        if (err)
            return StatusCode(StatusCodes.Status500InternalServerError); 
        
        return NoContent();
    }
    
    [HttpGet]
    [Route("{id:int}/get")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<Person?> GetById(int id)
    {
        var p = _connection.Person.FirstOrDefault(p => p.Id == id);
        if (p == null)
        {
            return NotFound();
        }

        return Ok(p);
    }
    
    [HttpDelete]
    [Route("{id:int}/delete")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public ActionResult<Person> Delete(int id)
    {
        if (id <= 0)
            return BadRequest();

        var person = _connection.Person.FirstOrDefault(p => p.Id == id);

        if (person == null)
            return NotFound();

        _connection.Person.Remove(person);
        
        bool err = CheckForErrorsAndSave();

        if (err)
            return StatusCode(StatusCodes.Status500InternalServerError); 
        
        return NoContent();
    }

    private bool CheckForErrorsAndSave()
    {
        bool err = false;
        try
        {
            _connection.SaveChanges();
        }
        catch(DbUpdateException e)
        {
            _logger.LogError($"Couldn't save to db, {e.Message}");
            err = true;
        }
        return err;
    }

    private readonly ILogger<PersonController> _logger;
    private readonly PersonDbContext _connection;
    private const int PageSize = 100;
}
