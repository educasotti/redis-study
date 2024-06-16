using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Services;
using System.Text.Json;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestRedisController : ControllerBase
    {
        private readonly IDistributedCache _cache;
        private readonly IPersonService _personService;

        public TestRedisController(IDistributedCache cache, IPersonService personService)
        {
            _personService = personService;
            _cache = cache;
        }
        [HttpGet("{document}")]
        public IActionResult Get(string document)
        {
            var json = _cache.GetString(document);
            Person person;
            if (string.IsNullOrEmpty(json))
            {
                var people = _personService.GetPeople();
                person = people.FirstOrDefault(x => x.Document == document);
                json = JsonSerializer.Serialize<Person>(person);
                _cache.SetString(document, json);
            }
            else
            {
                person = JsonSerializer.Deserialize<Person>(json);
            }
            return Ok(json);
        }
    }
}
