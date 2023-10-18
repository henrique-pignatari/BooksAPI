using Books.Domain.ErrorMessages;
using Books.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Domain.Validation
{
    public static class GenreValidation
    {
        public static void ValidateName(string name)
        {
            DomainException.When(string.IsNullOrWhiteSpace(name), AuthorErrorMessages.NullOrEmpityName);
            DomainException.When(name.Length < 3, AuthorErrorMessages.ShortName);
            DomainException.When(name.Length > 150, AuthorErrorMessages.LongName);
        }
    }
}
