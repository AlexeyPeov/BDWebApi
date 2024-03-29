using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WebBirthdayApp.Database;
using WebBirthdayApp.Models;
using WebBirthdayApp.Validators;

namespace WebBirthdayApp.Controllers;

[Route("/api/people")]
[ApiController]
public class PersonController : ControllerBase
{

    public PersonController(ILogger<PersonController> logger, AppDbContext conn)
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
    
    [HttpGet("pages_amount")]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<int> GetPages()
    {
        return Ok(_connection.Person.Count() / PageSize);
    }
    
    [HttpPost("create")]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<Person?> Create([FromForm]FrontendPersonCreationRequest? r)
    {
        if (r == null)
        {
            return BadRequest(ModelState);
        }
        
        var person = new Person();
        person.CopyFromFrontend(r);
        
        var image = new Image();

        using var transaction = _connection.Database.BeginTransaction();
        
        if (r.Img != null)
        {
            image.SetFromFile(r.Img);
            _connection.Image.Add(image);
            bool imgErr = CheckForErrorsAndSave();

            if (imgErr)
            {
                transaction.Rollback();
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        if (image.Id != null)
            person.ImgId = image.Id;
        
        _connection.Person.Add(person);
        
        bool persErr = CheckForErrorsAndSave();
        
        if (persErr || person.Id == null)
            return StatusCode(StatusCodes.Status500InternalServerError);
        
        transaction.Commit();
        
        return Ok(person);
    }

    [HttpPut]
    [Route("{id:int}/update")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public ActionResult<Person> Update(int id, [FromForm] FrontendPersonCreationRequest? r)
    {
        if (r == null)
            return BadRequest(ModelState);

        var person = _connection.Person.FirstOrDefault(p => p.Id == id);

        if (person == null)
            return NotFound();
        
        person.CopyFromFrontend(r);
        
        using var transaction = _connection.Database.BeginTransaction();
        
        if (r.Img == null)
        {
            if (!CheckForErrorsAndSave())
            {
                transaction.Commit();
                return NoContent();
            }
            
            transaction.Rollback();

            return StatusCode(StatusCodes.Status500InternalServerError);

        }
        
        var image = new Image(r.Img);
        
        var dbImg = _connection.Image.FirstOrDefault(i => i.Id == person.ImgId);
        
        if (dbImg == null)
        {
            _connection.Image.Add(image);
            
            bool imgErr = CheckForErrorsAndSave();
            if (imgErr)
            {
                transaction.Rollback();
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            person.ImgId = image.Id;
        }
        else
        {
            dbImg.Bytes = image.Bytes;
        }
        
        bool err = CheckForErrorsAndSave();

        if (err)
        {
            transaction.Rollback();
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
        
        transaction.Commit();
        
        return NoContent();
    }
    
    [HttpPatch]
    [Route("{id:int}/patch")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public ActionResult<Person> Patch(int id, [FromBody]JsonPatchDocument<Person>? model) {
        if (id < 0 || model == null)
            return BadRequest(ModelState);

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
    
    [HttpPatch]
    [Route("{id:int}/patch_img")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public ActionResult Patch(int id, [FromForm]FrontendImageRequest r)
    {
        var f = r.Img;
        
        if (id < 0 || f == null)
            return BadRequest("Empty image sent");

        var p = _connection.Person.FirstOrDefault(p => p.Id == id);
        
        if (p == null)
            return NotFound();
        
        var image = new Image(f);
        using var transaction = _connection.Database.BeginTransaction();
        
        var dbImg = _connection.Image
            .FirstOrDefault(i => i.Id == p.ImgId);
        
        if (dbImg == null)
        {
            _connection.Image.Add(image);
            
            bool imgErr = CheckForErrorsAndSave();
            if (imgErr)
            {
                transaction.Rollback();
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            p.ImgId = image.Id;
        }
        else
        {
            dbImg.Bytes = image.Bytes;
        }
        
        bool err = CheckForErrorsAndSave();

        if (err)
        {
            transaction.Rollback();
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
        
        transaction.Commit();
        
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
            return NotFound();
        
        return Ok(p);
    }
    
    [HttpGet]
    [Route("{id:int}/get_image")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetImage(int id)
    {
        var p = _connection.Person.FirstOrDefault(p => p.Id == id);
        
        if (p == null || p.ImgId == null)
        {
            return NotFound();
        }

        var img = _connection.Image.FirstOrDefault(i => i.Id == p.ImgId);
        
        if(img == null)
        {
            return NotFound();
        }
        
        return File(img.Bytes, "image/jpeg");
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
            return BadRequest(ModelState);

        var person = _connection.Person.FirstOrDefault(p => p.Id == id);
        
        if (person == null)
            return NotFound();
        
        var image = _connection.Image.FirstOrDefault(i => i.Id == person.ImgId);
        
        using var transaction = _connection.Database.BeginTransaction();
        _connection.Person.Remove(person);
        
        if(image != null)
            _connection.Image.Remove(image);
        
        bool err = CheckForErrorsAndSave();

        if (err)
        {
            transaction.Rollback();
            return StatusCode(StatusCodes.Status500InternalServerError); 
        }
        transaction.Commit();
        
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
    private readonly AppDbContext _connection;
    private const int PageSize = 10;
}
