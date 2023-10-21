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
    public class GenreRepository : Repository<Genre>, IGenreRepository
    {
        public GenreRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Genre>> GetByNameAsync(string name, int quantity, int offset)
        {
            return await _context.Genres
                .Where(genre => genre.Name.Contains(name))
                .Skip(offset)
                .Take(quantity)
                .ToListAsync();
        }
    }
}
