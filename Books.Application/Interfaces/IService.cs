using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Application.Interfaces
{
    public interface IService<SendDTO, ReceiveDTO>
    {
        Task<IEnumerable<SendDTO>> GetAll();
        Task<SendDTO> GetByIdAsync(int id);
        Task<ICollection<SendDTO>> GetByNameAsync(string name, int quantity, int offset);
        Task CreateAsync(ReceiveDTO dto);
        Task UpdateAsync(ReceiveDTO dto);
        Task RemoveAsync(ReceiveDTO dto);
    }
}
