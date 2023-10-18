using Books.Domain.ErrorMessages;
using Books.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Domain.Validation
{
    public static class BookValidation
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

        public static void ValidateTotalPages(int? totalPages)
        {
            if(totalPages != null)
            {
                DomainException.When(totalPages == 0, BookErrorMessages.NegativeOrZeroPages);
            }
        }

        public static void ValidateImage(string? image)
        {
            if (image != null)
            {
                DomainException.When(string.IsNullOrWhiteSpace(image), BookErrorMessages.EmptyImageName);
                DomainException.When(image.Length > 250, BookErrorMessages.LongImageName);
            }
        }
    }
}
