using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Domain.ErrorMessages
{
    public class BookErrorMessages
    {
        public const string NullOrEmpityTitle = "Invalid Title. Title is required.";
        public const string ShortTitle = "Invalid Title. Title is too short.";
        public const string LongTitle = "Invalid Title. Title is too long.";
        public const string EmpityDescription = "Invalid Description. Description can't be empty.";
        public const string ShortDescription = "Invalid Description. Description is too short.";
        public const string LongDescription = "Invalid Description. Description is too long.";
        public const string NegativeOrZeroPages = "Invalid Number of Pages. Number of Pages must be greater than zero.";
        public const string EmptyImageName = "Invalid Image Name. Image Name can't be empty.";
        public const string LongImageName = "Invalid Image Name. Image Name is Too Long";


    }
}
