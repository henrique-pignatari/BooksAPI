using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Domain.Constraints
{
    public class AuthorConstraints
    {
        public const int MinNameLength = 3;
        public const int MaxNameLength = 150;
    }
}
