using Books.Domain.ErrorMessages;
using Books.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Domain.Validation
{
    public static class BookGenreValidation
    {
        public static void ValidateBookId(int bookId)
        {
            DomainException.When(bookId < 0, BookAuthorErrorMessages.NegativeBookId);
        }

        public static void ValidateGenreId(int genreId)
        {
            DomainException.When(genreId < 0, BookGenreErrorMessages.NegativeGenreId);
        }
    }
}
