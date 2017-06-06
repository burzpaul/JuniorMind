using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Cors;

namespace WebApi.Controllers
{
  [Route("api/[controller]")]
  public class ValuesController : Controller
  {
    private PasswordInfo info = new PasswordInfo()
    {
      NumberOfPasswords = 1,
      PasswordLength = 8,
      UpperCase = 2,
      Digits = 2,
      Symbols = 2,
      ExcludeSimilar = false,
      ExcludeAmbigous = false
    };

    [HttpGet]
    public IActionResult Get()
    {
      return Json(new PasswordGenerator(info).GeneratePassword());
    }

    [HttpGet("{id}", Name = "Passwords")]
    public IActionResult Get(int numberOf)
    {
      return Json(new PasswordGenerator(info).GeneratePassword());
    }

    [HttpGet]
    [Route("defaultvalues")]
    public IActionResult GetInfo()
    {
      var result = new
      {
        NumberOfPasswords = info.NumberOfPasswords,
        PasswordLength = info.PasswordLength,
        UpperCase = info.UpperCase,
        Digits = info.Digits,
        Symbols = info.Symbols,
        ExcludeSimilar = info.ExcludeSimilar,
        ExcludeAmbigous = info.ExcludeAmbigous
      };

      return new ObjectResult(result);
    }

    // POST api/values
    [HttpPost]
    public IActionResult Post([FromBody]PasswordInfo info)
    {
      if (info.NumberOfPasswords <= 0)
      {
        return BadRequest(new ExceptionClas
        {
          NumberOfPasswords = info.NumberOfPasswords,
          Message = "number of passwords has to ge greater than 0"
        });
      }
      if (info.PasswordLength < 8)
      {
        return BadRequest("Password must contain more than 8 characters");
      }
      return new ObjectResult(new PasswordGenerator(info).GeneratePassword());
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }

  public class ExceptionClas
  {
    public int NumberOfPasswords { get; set; }
    public string Message { get; set; }
  }
}