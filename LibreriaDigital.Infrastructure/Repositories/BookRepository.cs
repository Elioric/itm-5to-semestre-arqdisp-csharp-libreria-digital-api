using Microsoft.EntityFrameworkCore;
using LibreriaDigital.Application.Interfaces;
using LibreriaDigital.Domain.Entities;
using LibreriaDigital.Infrastructure.Data; // Referencia a tu DbContext

namespace LibreriaDigital.Infrastructure.Repositories
{
    // Implementa el contrato definido en la capa Application
    public class BookRepository : IBookRepository
    {
        private readonly LibreriaDigitalAppDbContext _context;

        public BookRepository(LibreriaDigitalAppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _context.Books
                .Include(b => b.User)
                .ToListAsync();
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            // Busca el libro por ID. Se incluye el usuario para el contexto
            return await _context.Books
                .Include(b => b.User)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task AddAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Book book)
        {
            // Marca la entidad como modificada para que EF Core sepa que debe actualizarla
            _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
        }

        public Task<bool> ExistsAsync(int id)
        {
            // Verifica si existe un libro con el ID
            return _context.Books.AnyAsync(e => e.Id == id);
        }
    }
}