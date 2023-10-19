using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Domain.ErrorMessages
{
    public class PublisherErrorMessages
    {
        public const string NullOrEmptyName = "Invalid Name. Name is required.";
        public const string ShortName = "Invalid Name. Name is too short.";
        public const string LongName = "Invalid Name. Name is too long.";

        public const string EmptyLogoName = "Invalid Logo Name. Logo Name can't be empty.";
        public const string LongLogoName = "Invalid Logo Name. Logo Name is Too Long";
    }
}
