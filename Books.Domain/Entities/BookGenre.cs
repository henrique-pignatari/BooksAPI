using Books.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Domain.Entities
{
    public class BookGenre
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        public BookGenre(int bookId, int genreId)
        {
            BookGenreValidation.ValidateBookId(bookId);
            BookGenreValidation.ValidateGenreId(genreId);

            BookId = bookId;
            GenreId = genreId; 
        }
    }
}
