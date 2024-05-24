using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using rwaspnet5.Model;
using rwaspnet5.Business;

namespace rwaspnet5.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class BookController : ControllerBase
    {

        private readonly ILogger<BookController> _logger;
        private IBookBusiness _BookBusiness;

        public BookController(ILogger<BookController> logger, IBookBusiness BookBusiness)
        {
            _logger = logger;
            _BookBusiness = BookBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_BookBusiness.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var Book = _BookBusiness.FindByID(id);
            if (Book == null) return NotFound();
            return Ok(Book);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Book book)
        {

            if (book == null) return BadRequest();
            return Ok(_BookBusiness.Create(book));
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] Book book)
        {

            if (book == null) return BadRequest();
            return Ok(_BookBusiness.Update(book));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _BookBusiness.Delete(id);
            return NoContent();
        }
    }
}
