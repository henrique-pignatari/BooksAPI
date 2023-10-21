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
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Category>> GetByNameAsync(string name, int quantity, int offset)
        {
            return await _context.Categories
                .Where(category => category.Name.Contains(category.Name))
                .Skip(offset)
                .Take(quantity)
                .ToListAsync();
        }
    }
}
