using Microsoft.AspNetCore.Mvc;
using PeopleManager.Services;

namespace PeopleManager.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly PersonService _personService;

        public PeopleController(PersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public IActionResult Find()
        {
            var people = _personService.Find();
            return Ok(people);
        }
    }
}
