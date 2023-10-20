using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Domain.Interfaces
{
    public interface INamedEntityRepository<T> : IRepository<T>
    {
        Task<IEnumerable<T>> GetByNameAsync(string name, int? quantity, int? page);
    }
}
