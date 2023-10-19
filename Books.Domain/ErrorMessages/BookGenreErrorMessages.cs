using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Domain.ErrorMessages
{
    public class BookGenreErrorMessages
    {
        public const string NegativeBookId = "Invalid Book Id. Book Id must be positive";
        public const string NegativeGenreId = "Invalid Genre Id. Genre Id must be positive";
    }
}
