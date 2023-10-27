using Books.Domain.Entities;
using Books.Domain.Interfaces;
using Books.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Infra.Data.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(ApplicationDbContext context) : base(context) { }

        public new async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _context.Books
                .Include(b => b.Publisher)
                .Include(b => b.Category)
                .Include(b => b.Genres)
                .Include(b => b.Authors)
                .ToListAsync();
        }

        public new async Task<Book> GetByIdAsync(int id)
        {
            return await _context.Books
                .Include(b => b.Publisher)
                .Include(b => b.Category)
                .Include(b => b.Genres)
                .Include(b => b.Authors)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<IEnumerable<Book>> GetByAuthorAsync(int authorId, int quantity, int offset)
        {
            var author = await _context.Authors
                .Include(a => a.Books)
                .FirstOrDefaultAsync(a => a.Id == authorId);
            
            if(author != null) 
                return author.Books
                    .Skip(offset)
                    .Take(quantity);

            return new List<Book>();
        }

        public async Task<IEnumerable<Book>> GetByCategoryAsync(int categoryId, int quantity, int offset)
        {
            return await _context.Books
                .Where(book => book.CategoryId == categoryId)
                .Skip(offset)
                .Take(quantity)
                .ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetByGenreAsync(int genreId, int quantity, int offset)
        {
            var genre = await _context.Genres
                .Include(g => g.Books)
                .FirstOrDefaultAsync(g => g.Id == genreId);
            
            if(genre != null) 
                return genre.Books
                    .Skip(offset)
                    .Take(quantity);
            
            return new List<Book>();
        }

        public async Task<IEnumerable<Book>> GetByNameAsync(string name, int quantity, int offset)
        {
            return await _context.Books
                .Where(book => book.Name.Contains(name))
                .Skip(quantity)
                .Take(quantity)
                .ToListAsync();
        }
    }
}
