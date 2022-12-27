using Microsoft.AspNetCore.Mvc;
using NetAngularCrud.Data.Model;
using NetAngularCrud.Data.Services;
using System;

namespace NetAngularCrud.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private IBookService _service;

        public BooksController(IBookService service)
        {
            _service = service;
        }

        [HttpPost("AddBook")]
        public IActionResult AddBook([FromBody] Book book)
        {
            try
            {
                if(book.Author != null && book.Title != null && book.Description != null)
                {
                    _service.AddBook(book);
                    return Ok();
                }
                return BadRequest("Book was not added");
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("[action]")]
        public IActionResult GetBooks()
        {
            var allBooks = _service.GetAllBooks();
            return Ok(allBooks);
        }

        [HttpPut("UpdateBook/{id}")]
        public IActionResult Update(int id, [FromBody] Book book)
        {
            _service.UpdateBook(id, book);
            return Ok(book);
        }

        [HttpDelete("DeleteBook/{id}")]
        public IActionResult Delete(int id)
        {
            _service.DeleteBook(id);
            return Ok();
        }

        [HttpGet("SingleBook/{id}")]
        public IActionResult GetBookById(int id)
        {
            return Ok(_service.GetBookById(id));
        }
    }
}
