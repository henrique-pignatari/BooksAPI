using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Domain.Constraints
{
    public class BookConstraints
    {
        public const int MinNameLength = 3;
        public const int MaxNameLength = 250;

        public const int MinDescriptionLength = 3;
        public const int MaxDescriptionLength = 250;

        public const int MinTotalPages = 0;

        public const int MaxImageLength = 250;

    }
}
