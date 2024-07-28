﻿using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VersionedApiDeprecatedPackages.Controllers.v2;

[Route("api/v{version:ApiVersion}/[controller]")]
[ApiController]
[ApiVersion("2.0")]
public class UsersController : ControllerBase
{
    // GET: api/v1/Users
    // GET: api/v2/Users
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "Version 2 value1", "Version 2 value2" };
    }

    // GET api/<UsersController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<UsersController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<UsersController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<UsersController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
