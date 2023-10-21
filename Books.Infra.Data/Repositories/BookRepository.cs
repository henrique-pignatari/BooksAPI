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

        public async Task<IEnumerable<Book>> GetByAuthorAsync(int authorId, int quantity, int offset)
        {
            var author = await _context.Authors.FindAsync(authorId);
            
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
            var genre = await _context.Genres.FindAsync(genreId);
            
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
