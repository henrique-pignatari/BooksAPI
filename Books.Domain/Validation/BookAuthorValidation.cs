using Books.Domain.ErrorMessages;
using Books.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Domain.Validation
{
    public static class BookAuthorValidation
    {
        public static void ValidateBookId(int bookId)
        {
            DomainException.When(bookId < 0, BookAuthorErrorMessages.NegativeBookId);
        }

        public static void ValidateAuthorId(int authorId)
        {
            DomainException.When(authorId < 0, BookAuthorErrorMessages.NegativeAuthorId);
        }
    }
}
