using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Domain.ErrorMessages
{
    public class BookErrorMessages
    {
        public const string NullOrEmptyTitle = "Invalid Title. Title is required.";
        public const string ShortTitle = "Invalid Title. Title is too short.";
        public const string LongTitle = "Invalid Title. Title is too long.";
        
        public const string EmpityDescription = "Invalid Description. Description can't be empty.";
        public const string ShortDescription = "Invalid Description. Description is too short.";
        public const string LongDescription = "Invalid Description. Description is too long.";
        
        public const string EmptyImageName = "Invalid Image Name. Image Name can't be empty.";
        public const string LongImageName = "Invalid Image Name. Image Name is Too Long";

        public const string NegativeOrZeroPages = "Invalid Number of Pages. Number of Pages must be greater than zero.";

        public const string NegativePublisherId = "Invalid Pusblisher Id. Publisher Id must be positive";

        public const string NegativeCategoryId = "Invalid Category Id. Category Id mus be positive";

        public const string NullAuthorsArray = "Invalid Authors. Authors is required";
        public const string NoAuthorsProvided = "Invalid Authors. There must be at least one Author";

        public const string NullGenresArray = "Invalid Genres. Genres is required";
        public const string NoGenresProvided = "Invalid Genres. There must be at least one Author";
    }
}
