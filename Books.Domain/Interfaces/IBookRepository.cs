using Books.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Domain.Interfaces
{
    public interface IBookRepository : INamedEntityRepository<Book>
    {
        Task<IEnumerable<Book>> GetByAuthorAsync(int authorId, int quantity, int offset);
        Task<IEnumerable<Book>> GetByGenreAsync(int genreId, int quantity, int offset);
        Task<IEnumerable<Book>> GetByCategoryAsync(int categoryId, int quantity, int offset);
    }
}
