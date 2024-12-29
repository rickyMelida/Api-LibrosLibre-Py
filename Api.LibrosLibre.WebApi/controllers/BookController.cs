using Microsoft.AspNetCore.Mvc;

namespace Api.LibrosLibre.WebApi
{
    [ApiController]
    [Route("api/books")]
    public class BookController: ControllerBase
    {
        
        [HttpGet("get-book")]
        public string Get()
        {
            return "Hello World";
        }

    }
}