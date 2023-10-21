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
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Author>> GetByNameAsync(string name, int quantity, int offset)
        {
            return await _context.Authors
                .Where(author => author.Name.Contains(name))
                .Take(quantity)
                .Skip(offset)
                .ToListAsync();
        }
    }
}
