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
    public class PublisherRepository : Repository<Publisher>, IPublisherRepository
    {
        public PublisherRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Publisher>> GetByNameAsync(string name, int quantity, int offset)
        {
            return await _context.Publishers
                .Where(publisher => publisher.Name.Contains(name))
                .Skip(offset)
                .Take(quantity)
                .ToListAsync();
        }
    }
}
