using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Domain.ErrorMessages
{
    public class CategoryErrorMessages
    {
        public const string NullOrEmpityName = "Invalid Name. Name is required.";
        public const string ShortName = "Invalid Name. Name is too short.";
        public const string LongName = "Invalid Name. Name is too long";
    }
}
