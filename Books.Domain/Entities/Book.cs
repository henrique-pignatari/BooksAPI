using Books.Domain.Enums;
using Books.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using static System.Net.Mime.MediaTypeNames;

namespace Books.Domain.Entities
{
    public class Book : Entity
    {
        public string Title { get; private set; }
        public string? Description { get; private set; }
        public int? TotalPages { get; private set; }
        public string? Image { get; private set; }
        public ReadStatus ReadStatus { get; private set; }
        public DateTime? ReadStartDate { get; private set; }
        public DateTime? ReadStopDate { get; private set; }
        public DateTime? ReadConclusionDate { get; private set; }

        public int PublisherId { get; private set; }
        public Publisher Publisher { get; private set; }
        public int CategoryId { get; private set; }
        public Category Category { get; private set; }
        public ICollection<BookGenre> BooksGenres { get; private set; }
        public ICollection<BookAuthor> BookAuthors { get; private set; }

        public Book(string title, int publisherId, int categoryId, ICollection<BookAuthor> authors, ICollection<BookGenre> genres)
            : this(title, publisherId, categoryId, authors, genres, null, null, null) { }

        public Book(string title, int publisherId, int categoryId, ICollection<BookAuthor> authors, ICollection<BookGenre> genres, string? description, int? totalPages, string? image)
            : base()
        {
            ValidateDomain(title, publisherId, categoryId, authors, genres, description, totalPages, image);

            Title = title;
            Description = description;
            TotalPages = totalPages;
            Image = image;
            ReadStatus = ReadStatus.Pending;
            PublisherId = publisherId;
            CategoryId = categoryId;
            BookAuthors = authors;
            BooksGenres = genres;
        }

        private void ValidateDomain(string title, int publisherId, int categoryId, ICollection<BookAuthor> authors, ICollection<BookGenre> genres, string? description, int? totalPages, string? image)
        {
            BookValidation.ValidateTitle(title);
            BookValidation.ValidateDescription(description);
            BookValidation.ValidateTotalPages(totalPages);
            BookValidation.ValidateImage(image);
            BookValidation.ValidatePublisherId(publisherId);
            BookValidation.ValidateCategoryId(categoryId);
            BookValidation.ValidateBookAuthors(authors);
            BookValidation.ValidateBookGenres(genres);
        }

        public void StartReading()
        {
            ReadStatus = ReadStatus.InProgress;
            ReadStartDate = DateTime.UtcNow;
            ReadStopDate = null;
            ReadConclusionDate = null;
        }

        public void StopReading()
        {
            ReadStatus = ReadStatus.Pending;
            ReadStopDate = DateTime.UtcNow;
            ReadConclusionDate = null;
        }

        public void PartialRestartReading()
        {
            ReadStatus = ReadStatus.InProgress;
            ReadStopDate = null;
        }

        public void FullRestartReading()
        {
            ReadStatus = ReadStatus.InProgress;
            ReadStartDate = DateTime.Now;
            ReadStopDate = null;
        }

        public void ConcludeReading()
        {
            ReadStatus = ReadStatus.Finished;
            ReadConclusionDate = DateTime.UtcNow;
            ReadStopDate = null;
        }

        public void Update(string title, int publisherId, int categoryId, ICollection<BookAuthor> authors, ICollection<BookGenre> genres, string? description, int? totalPages, string? image)
        {
            ValidateDomain(title, publisherId, categoryId, authors, genres, description, totalPages, image);

            Title = title;
            Description = description;
            TotalPages = totalPages;
            Image = image;
            ReadStatus = ReadStatus.Pending;
            PublisherId = publisherId;
            CategoryId = categoryId;
            BookAuthors = authors;
            BooksGenres = genres;
        }
    }
}
