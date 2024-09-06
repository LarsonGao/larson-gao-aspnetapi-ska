using api_ska.models;
using api_ska.services;
using Microsoft.AspNetCore.Mvc;

namespace api_ska.controllers;

[Route("api/v1/[controller]")]
public class AccountController : ControllerBase
{
    private readonly StaticStorageService _storageService;
    public AccountController(StaticStorageService storageService)
    {
        _storageService = storageService;
    }
    
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(new Response
        {
            status = 200,
            message = "Success",
            data = _storageService.accounts
        });
    }
    
    [HttpPost]
    public IActionResult Create([FromBody] Account account)
    {
        account.id = _storageService.nextId++;
        _storageService.accounts.Add(account);

        if (ModelState.IsValid)
        {
            return Ok(new Response
            {
                status = 200,
                message = "Success",
                data = account
            });
        }
        else
        {
            return BadRequest(new Response
            {
                status = 400,
                message = "Bad Request",
                data = ModelState
            });

        }
    }

    [HttpPatch("{id}")]
    public IActionResult Update([FromRoute]int id, [FromBody] UpdateParameters parameter)
    {
        var record = _storageService.accounts.Find(r => r.id == id);
        
        if(record == null)
        {
            return NotFound(new Response
            {
                status = 404,
                message = "Not Found",
                data = null
            });
        }
        if(parameter.amount != null)
        {
            record.amount = parameter.amount.Value;
        }
        if(parameter.remark != null)
        {
            record.remark += ", " + parameter.remark;
        }
        if(parameter.date != null)
        {
            record.date = parameter.date.Value;
        }

        return Ok(new Response
        {
            status = 200,
            message = "Success",
            data = record
        });
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var result = _storageService.accounts.RemoveAll(r => r.id == id);
        return result > 0 ? Ok() : NotFound();
    }
    
    public class UpdateParameters
    {
        public decimal? amount { get; set; }
        public string remark { get; set; }
        public DateTime? date { get; set; }
    }
}