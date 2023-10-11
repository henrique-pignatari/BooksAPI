using Books.Domain.ErrorMessages;
using Books.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Domain.Validation
{
    public class BookValidation
    {
        public static void ValidateTitle(string title)
        {
            DomainException.When(string.IsNullOrWhiteSpace(title), BookErrorMessages.NullOrEmpityTitle);
            DomainException.When(title.Length < 3, BookErrorMessages.ShortTitle);
            DomainException.When(title.Length > 250, BookErrorMessages.LongTitle);
        }

        public static void ValidateDescription(string? description)
        {
            if (description != null)
            {
                DomainException.When(string.IsNullOrWhiteSpace(description), BookErrorMessages.EmpityDescription);
                DomainException.When(description.Length < 3, BookErrorMessages.ShortDescription);
                DomainException.When(description.Length > 1000, BookErrorMessages.LongDescription);
            }
        }
    }
}
