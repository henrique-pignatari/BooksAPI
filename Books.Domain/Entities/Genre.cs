using Books.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Domain.Entities
{
    public class Genre : Entity
    {
        public string Name { get; private set; }
        public ICollection<Book> Books { get; private set; }

        public Genre(string name)
        {
            GenreValidation.ValidateName(name);
            Name = name;
        }
    }
}
