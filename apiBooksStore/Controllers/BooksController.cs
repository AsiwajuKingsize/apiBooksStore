using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using apiBooksStore.Data;
using apiBooksStore.Models;
using Microsoft.Extensions.Logging;
using AutoMapper;
using apiBooksStore.DTO;

namespace apiBooksStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BooksStoreContext _context;

        private ILogger<BooksController> _logger;

        private readonly IMapper _mapper;

        public BooksController(BooksStoreContext context, ILogger<BooksController> bookLogger, IMapper mapper)
        {
            _context = context;
            _logger = bookLogger;
            _mapper = mapper;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDTO>>> GetBooks()
        {
            _logger.LogInformation("Get Book method called!!!");
            var book = await _context.Books.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<BookDTO>>(book));
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDTO>> GetBook(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return _mapper.Map<BookDTO>(book);
        }

        // PUT: api/Books/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, BookDTO bookDTO)
        {
            var book = _mapper.Map<Book>(bookDTO);
            if (id != book.BookId)
            {
                return BadRequest();
            }

            _context.Entry(book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(_mapper.Map<BookDTO>(book));
        }

        // POST: api/Books
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(BookDTO bookDTO)
        {
            var book = _mapper.Map<Book>(bookDTO);
           
            if (ModelState.IsValid)
            {
                if (_context.Authors.Any(e => e.AuthorId == book.AuthorId))
                {

                    _context.Books.Add(book);
                    await _context.SaveChangesAsync();
                    return CreatedAtAction("GetBook", new { id = book.BookId }, book);


                }
                else
                {
                    return BadRequest("Book Author does not exist in Authors Record, proceed to create Author");
                }
            }
            else
            {
                return BadRequest();
            }
           

           
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Book>> DeleteBook(int id)
        {
            int bookId;
            var book = await _context.Books.FindAsync(id);
         
            if (book == null)
            {
                return NotFound();
            }
            else
            {
                bookId = book.BookId;
            }

            //checked if Book exists in BooksSale, if Yes reject delete
            if ((_context.BookSales.Where(bks => bks.BookId == bookId)).Count() == 0)
            {
                _context.Books.Remove(book);
            }
            else
            {
                return BadRequest("Book with sales record cannot be deleted, proceed to delete Book sale record");
            }
            await _context.SaveChangesAsync();

            return book;
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.BookId == id);
        }
    }
}
