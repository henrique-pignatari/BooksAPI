using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Domain.Entities
{
    public class BookAuthor : Entity
    {
        public int BookId { get; private set; }
        public Book Book { get; private set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
