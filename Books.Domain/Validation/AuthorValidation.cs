using Books.Domain.Constraints;
using Books.Domain.ErrorMessages;
using Books.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Domain.Validation
{
    public static class AuthorValidation
    {
        public static void ValidateName(string name)
        {
            DomainException.When(string.IsNullOrWhiteSpace(name), AuthorErrorMessages.NullOrEmpityName);
            DomainException.When(name.Length < AuthorConstraints.MinNameLength, AuthorErrorMessages.ShortName);
            DomainException.When(name.Length > AuthorConstraints.MaxNameLength, AuthorErrorMessages.LongName);
        }
    }
}
