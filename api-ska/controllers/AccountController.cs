using api_ska.models;
using Microsoft.AspNetCore.Mvc;

namespace api_ska.controllers;

[Route("[controller]")]
public class AccountController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok();
    }
    
    [HttpPost]
    public IActionResult Create([FromBody] Account account)
    {
        return ModelState.IsValid ? Ok(account) : BadRequest();
    }

    [HttpPatch("{id}")]
    public IActionResult Update(int id, [FromBody] dynamic parameters)
    {
        return Ok(parameters);
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return Ok();
    }
}