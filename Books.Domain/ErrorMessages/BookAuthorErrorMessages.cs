using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Domain.ErrorMessages
{
    public class BookAuthorErrorMessages
    {
        public const string NegativeBookId = "Invalid Book Id. Book Id must be positive";
        public const string NegativeAuthorId = "Invalid Author Id. Author Id must be positive";
    }
}
