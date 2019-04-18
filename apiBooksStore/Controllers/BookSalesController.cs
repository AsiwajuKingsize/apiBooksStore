using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using apiBooksStore.Data;
using apiBooksStore.Models;
using AutoMapper;
using apiBooksStore.DTO;
using Microsoft.Extensions.Logging;

namespace apiBooksStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookSalesController : ControllerBase
    {
        private readonly BooksStoreContext _context;

        private ILogger<BookSalesController> _logger;

        private readonly IMapper _mapper;

        public BookSalesController(BooksStoreContext context, ILogger<BookSalesController> bookSalesLogger, IMapper mapper)
        {
            _context = context;
            _logger = bookSalesLogger;
            _mapper = mapper;
        }

        // GET: api/BookSales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookSaleDTO>>> GetBookSales()
        {
            var Books = await _context.BookSales.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<BookSaleDTO>>(Books));
        }

        // GET: api/BookSales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookSaleDTO>> GetBookSale(int id)
        {
            var bookSale = await _context.BookSales.FindAsync(id);

            if (bookSale == null)
            {
                return NotFound();
            }

            return _mapper.Map<BookSaleDTO>(bookSale);
        }

        //Book Sales Put Method not Effected because it will lead to data inconsistency
        // PUT: api/BookSales/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutBookSale(int id, BookSaleDTO bookSaleDTO)
        //{
        //    var bookSale = _mapper.Map<BookSale>(bookSaleDTO);
        //    if (id != bookSale.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(bookSale).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!BookSaleExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return Ok(_mapper.Map<BookSaleDTO>(bookSale));
        //}

        // POST: api/BookSales
        [HttpPost]
        public async Task<ActionResult<BookSale>> PostBookSale(BookSaleDTO bookSaleDTO)
        {
            var bookSale = _mapper.Map<BookSale>(bookSaleDTO);
            if (ModelState.IsValid)
            {
                _context.BookSales.Add(bookSale);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetBookSale", new { id = bookSale.Id }, bookSale);
            }
            else
            {
                return BadRequest();
            }
           
        }

        // DELETE: api/BookSales/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BookSale>> DeleteBookSale(int id)
        {
            var bookSale = await _context.BookSales.FindAsync(id);
            if (bookSale == null)
            {
                return NotFound();
            }
            //Update Books back to state before Sales
            int bookQuantitySold = bookSale.Quantity;
            int bookId = bookSale.BookId;
            Book bookSold = _context.Books.Where(b=>b.BookId== bookId).SingleOrDefault();
            bookSold.Quantity = bookSold.Quantity + bookQuantitySold;
            _context.BookSales.Remove(bookSale);
            await _context.SaveChangesAsync();

            return bookSale;
        }

        private bool BookSaleExists(int id)
        {
            return _context.BookSales.Any(e => e.Id == id);
        }
    }
}
