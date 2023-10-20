using Books.Domain.Constraints;
using Books.Domain.ErrorMessages;
using Books.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Books.Domain.Validation
{
    public static class PublisherValidation
    {
        public static void ValidateName(string name)
        {
            DomainException.When(string.IsNullOrWhiteSpace(name), PublisherErrorMessages.NullOrEmptyName);
            DomainException.When(name.Length < PublisherConstraints.MinNameLength, PublisherErrorMessages.ShortName);
            DomainException.When(name.Length > PublisherConstraints.MaxNameLength, PublisherErrorMessages.LongName);
        }

        public static void ValidateLogo(string logo)
        {
            if (logo != null)
            {
                DomainException.When(string.IsNullOrWhiteSpace(logo), PublisherErrorMessages.EmptyLogoName);
                DomainException.When(logo.Length > PublisherConstraints.MaxLogoLength, PublisherErrorMessages.LongLogoName);
            }
        }
    }
}
