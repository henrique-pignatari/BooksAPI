using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Application.Interfaces
{
    public interface IService<SendDTO, ReceiveDTO>
    {
        Task<IEnumerable<SendDTO>> GetAllAsync();
        Task<SendDTO> GetByIdAsync(string id);
        Task<ICollection<SendDTO>> GetByNameAsync(string name, int quantity, int offset);
        Task CreateAsync(ReceiveDTO dto);
        Task UpdateAsync(ReceiveDTO dto);
        Task RemoveAsync(ReceiveDTO dto);
    }
}
