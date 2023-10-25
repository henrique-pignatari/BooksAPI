using AutoMapper;
using Books.Application.DTOs.ReceiveDTOs;
using Books.Application.DTOs.SendDTOs;
using Books.Application.Interfaces;
using Books.Domain.Entities;
using Books.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Application.Services
{
    public class BookService : ServiceBase<Book, IBookRepository, BooksSendDTO, BookReceiveDTO>, IBookService
    {
        public BookService(IBookRepository bookRepository, IMapper mapper) : base(bookRepository, mapper) { }

        public async Task<bool> ConcludeReadingAsync(int bookId)
        {
            var entity = await _repository.GetByIdAsync(bookId);

            return entity != null;
        }

        public async Task<bool> FullRestartReadingAsync(int bookId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Book>> GetByAuthorAsync(int authorId, int quantity, int offset)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Book>> GetByCategoryAsync(int categoryId, int quantity, int offset)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Book>> GetByGenreAsync(int genreId, int quantity, int offset)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> PartialRestartReadingAsync(int bookId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> StartReadingAsync(int bookId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> StopReadingAsync(int bookId)
        {
            throw new NotImplementedException();
        }
    }
}
