using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Services;

namespace RestWithASPNETUdemy.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonController : ControllerBase
{
    private readonly IPersonService _personService;

    public PersonController(
        IPersonService personService)
    {
        _personService = personService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_personService.FindAll());
    }

    [HttpGet("{id}")]
    public IActionResult Get(long id)
    {
        return Ok(_personService.FindById(id));
    }

    [HttpPost]
    public IActionResult Post([FromBody] Person person)
    {
        if (person == null) return BadRequest("Invalid input");
        return Ok(_personService.Create(person));
    }

    [HttpPut]
    public IActionResult Put([FromBody] Person person)
    {
        if (person == null) return BadRequest("Invalid input");
        return Ok(_personService.Update(person));
    }

    [HttpDelete("delete/{id}")]
    public IActionResult Put(long id)
    {
        _personService.Delete(id);
        return NoContent();
    }



}
