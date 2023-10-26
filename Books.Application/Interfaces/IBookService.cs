using Books.Application.DTOs.ReceiveDTOs;
using Books.Application.DTOs.SendDTOs;
using Books.Domain.Entities;
using Books.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Application.Interfaces
{
    public interface IBookService : IService<BooksSendDTO, BookReceiveDTO>
    {
        Task<IEnumerable<Book>> GetByAuthorAsync(int authorId, int quantity, int offset);
        Task<IEnumerable<Book>> GetByGenreAsync(int genreId, int quantity, int offset);
        Task<IEnumerable<Book>> GetByCategoryAsync(int categoryId, int quantity, int offset);
        Task<bool> StartReadingAsync(int bookId);
        Task<bool> StopReadingAsync(int bookId);
        Task<bool> PartialRestartReadingAsync(int bookId);
        Task<bool> FullRestartReadingAsync(int bookId);
        Task<bool> ConcludeReadingAsync(int bookId);
    }
}
