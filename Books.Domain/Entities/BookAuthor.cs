using Books.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Domain.Entities
{
    public class BookAuthor
    {
        public int Id { get;  private set; }
        public int BookId { get; private set; }
        public Book Book { get; private set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public BookAuthor(int bookId, int authorId)
        {
            BookAuthorValidation.ValidateBookId(bookId);
            BookAuthorValidation.ValidateAuthorId(authorId);

            BookId = bookId;
            AuthorId = authorId;
        }
    }
}
