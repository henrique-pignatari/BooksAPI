using Books.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Domain.Entities
{
    public class Book : Entity
    {
        public string Title { get; private set; }
        public string? Description { get; private set; }
        public int? TotalPages { get; private set; }
        public string? Image { get; private set; }
        public DateTime? StartRead { get; private set; }
        public DateTime? StopDate { get; private set; }
        public DateTime? ConclusionDate { get; private set; }

        public int PublisherId { get; private set; }
        public Publisher Publisher { get; private set; }
        public int CategoryId { get; private set; }
        public Category Category { get; private set; }
        public ICollection<Genre> Genres { get; private set; }
        public ICollection<BookAuthor> BookAuthors { get; private set; }

        public Book(string title, string? description, int? totalPages, string? image) : base()
        {
            BookValidation.ValidateTitle(title);
            BookValidation.ValidateDescription(description);
            BookValidation.ValidateTotalPages(totalPages);
            BookValidation.ValidateImage(image);

            Title = title;
            Description = description;
            TotalPages = totalPages;
            Image = image;
        }

    }
}
