using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using LibreriaDigital.Domain.Entities;
using LibreriaDigital.Application.Interfaces;
using LibreriaDigital.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibreriaDigital.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        // Inyección del Repositorio y AutoMapper
        public BooksController(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        // GET: api/Books
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<BookDetailsDto>), 200)]
        public async Task<ActionResult<IEnumerable<BookDetailsDto>>> GetBooks()
        {
            var books = await _bookRepository.GetAllAsync();
            
            // Mapear la lista de Entidades a DTOs de salida
            var bookDtos = _mapper.Map<IEnumerable<BookDetailsDto>>(books);
            
            return Ok(bookDtos);
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BookDetailsDto), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<BookDetailsDto>> GetBook(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            var bookDto = _mapper.Map<BookDetailsDto>(book);
            
            return Ok(bookDto);
        }

        // POST: api/Books
        [HttpPost]
        [ProducesResponseType(typeof(BookDetailsDto), 201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<BookDetailsDto>> PostBook(BookCreateDto bookDto)
        {
            var bookEntity = _mapper.Map<Book>(bookDto);
            
            await _bookRepository.AddAsync(bookEntity);

            var createdBook = await _bookRepository.GetByIdAsync(bookEntity.Id);
            
            var createdBookDto = _mapper.Map<BookDetailsDto>(createdBook);

            return CreatedAtAction(nameof(GetBook), new { id = createdBookDto.Id }, createdBookDto);
        }

        // PUT: api/Books/5
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> PutBook(int id, BookCreateDto bookDto)
        {
            if (!await _bookRepository.ExistsAsync(id))
            {
                return NotFound();
            }
            
            var bookToUpdate = _mapper.Map<Book>(bookDto);
            
            bookToUpdate.Id = id;
            
            await _bookRepository.UpdateAsync(bookToUpdate);

            return NoContent();
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteBook(int id)
        {
            if (!await _bookRepository.ExistsAsync(id))
            {
                return NotFound();
            }

            await _bookRepository.DeleteAsync(id);

            return NoContent();
        }
    }
}