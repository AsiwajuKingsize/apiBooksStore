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
    public class AuthorsController : ControllerBase
    {
        private readonly BooksStoreContext _context;

        private ILogger<AuthorsController> _logger;

        private readonly IMapper _mapper;

        public AuthorsController(BooksStoreContext context, ILogger<AuthorsController> authorLogger, IMapper mapper)
        {
            _context = context;
            _logger = authorLogger;
            _mapper = mapper;
        }

        // GET: api/Authors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDTO>>> GetAuthors()
        {
            
            _logger.LogInformation("Get Author method called!!!");
            var Authors = await   _context.Authors.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<AuthorDTO>>(Authors));
         
        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDTO>> GetAuthor(int id)
        {
            var author = await _context.Authors.FindAsync(id);

            if (author == null)
            {
                return NotFound();
            }

            return _mapper.Map<AuthorDTO>(author);
        }

        // PUT: api/Authors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthor(int id, AuthorDTO authorDTO)
        {
            var author = _mapper.Map<Author>(authorDTO);
            if (id != author.AuthorId)
            {
                return BadRequest();
            }

            _context.Entry(author).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return  Ok(_mapper.Map<AuthorDTO>(author));
        }

        // POST: api/Authors
        [HttpPost]
        public async Task<ActionResult<Author>> PostAuthor(AuthorDTO authorDTO)
        {
            var author = _mapper.Map<Author>(authorDTO);

            _context.Authors.Add(author);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuthor", new { id = author.AuthorId }, author);
        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Author>> DeleteAuthor(int id)
        {
            int authorId;
            var author = await _context.Authors.FindAsync(id);
             
            if (author == null)
            {
                return NotFound();
            }
            else
            {
                authorId = author.AuthorId;
            }
            //checked if Author has Book(s) in Books
            if ((_context.Books.Where(a=>a.AuthorId== authorId)).Count() == 0)
            {
                _context.Authors.Remove(author);
            }
            else
            {
                return BadRequest("Author with exiting Books cannot be deleted, delete all Author books to proceed");
            }
          

            await _context.SaveChangesAsync();

            return author;
        }

        private bool AuthorExists(int id)
        {
            return _context.Authors.Any(e => e.AuthorId == id);
        }
    }
}
