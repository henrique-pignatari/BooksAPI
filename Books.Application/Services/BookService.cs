using AutoMapper;
using Books.Application.DTOs.ReceiveDTOs;
using Books.Application.DTOs.SendDTOs;
using Books.Application.Interfaces;
using Books.Application.Mappings;
using Books.Domain.Entities;
using Books.Domain.Interfaces;
using HashidsNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Books.Application.Services
{
    public class BookService : ServiceBase<Book, IBookRepository, BookSendDTO, BookReceiveDTO>, IBookService
    {
        public BookService(IBookRepository bookRepository, IMapper mapper, IHashids hashIds) : base(bookRepository, mapper, hashIds) { }

        public async Task<bool> ConcludeReadingAsync(string bookId)
        {
            var id = _hashIds.DecodeSingle(bookId);
            var entity = await _repository.GetByIdAsync(id);

            return entity != null;
        }

        public async Task<bool> FullRestartReadingAsync(string bookId)
        {
            var id = _hashIds.DecodeSingle(bookId);
            var book = await _repository.GetByIdAsync(id);

            if(book != null)
            {
                book.FullRestartReading();

                return await _repository.UpdateAsync(book) != null;
            }

            return false;
        }

        public async Task<IEnumerable<BookSendDTO>> GetByAuthorAsync(string authorId, int quantity, int offset)
        {
            var id = _hashIds.DecodeSingle(authorId);
            var entities = await _repository.GetByAuthorAsync(id, quantity, offset);
            
            return _mapper.Map<List<BookSendDTO>>(entities);
        }

        public async Task<IEnumerable<BookSendDTO>> GetByCategoryAsync(string categoryId, int quantity, int offset)
        {
            var id = _hashIds.DecodeSingle(categoryId);
            var entities = await _repository.GetByCategoryAsync(id, quantity, offset);

            return _mapper.Map<List<BookSendDTO>>(entities);
        }

        public async Task<IEnumerable<BookSendDTO>> GetByGenreAsync(string genreId, int quantity, int offset)
        {
            var id = _hashIds.DecodeSingle(genreId);
            var entities = await _repository.GetByGenreAsync(id, quantity, offset);

            return _mapper.Map<List<BookSendDTO>>(entities);
        }

        public async Task<bool> PartialRestartReadingAsync(string bookId)
        {
            var id = _hashIds.DecodeSingle(bookId);
            var book = await _repository.GetByIdAsync(id);

            if(book != null)
            {
                book.PartialRestartReading();
                return await _repository.UpdateAsync(book) != null;
            }

            return false;
        }

        public async Task<bool> StartReadingAsync(string bookId)
        {
            var id = _hashIds.DecodeSingle(bookId);
            var book = await _repository.GetByIdAsync(id);

            if(book != null)
            {
                book.StartReading();
                return await _repository.UpdateAsync(book) != null;
            }

            return false;
        }

        public async Task<bool> StopReadingAsync(string bookId)
        {
            var id = _hashIds.DecodeSingle(bookId);
            var book = await _repository.GetByIdAsync(id);

            if (book != null)
            {
                book.StopReading();
                return await _repository.UpdateAsync(book) != null;
            }

            return false;
        }
    }
}
