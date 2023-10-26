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
    public interface IBookService : IService<BookSendDTO, BookReceiveDTO>
    {
        Task<IEnumerable<BookSendDTO>> GetByAuthorAsync(string authorId, int quantity, int offset);
        Task<IEnumerable<BookSendDTO>> GetByGenreAsync(string genreId, int quantity, int offset);
        Task<IEnumerable<BookSendDTO>> GetByCategoryAsync(string categoryId, int quantity, int offset);
        Task<bool> StartReadingAsync(string bookId);
        Task<bool> StopReadingAsync(string bookId);
        Task<bool> PartialRestartReadingAsync(string bookId);
        Task<bool> FullRestartReadingAsync(string bookId);
        Task<bool> ConcludeReadingAsync(string bookId);
    }
}
