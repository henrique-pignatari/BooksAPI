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
        public string Name { get; private set; }
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
        public ICollection<Genre> Genres { get; private set; }
        public ICollection<BookGenre> BooksGenres { get; private set; }
        public ICollection<Author> Authors { get; private set; }
        public ICollection<BookAuthor> BookAuthors { get; private set; }

        public Book(string name, string? description, int? totalPages, string? image)
            : base()
        {
            ValidateDomain(name, description, totalPages, image);

            Name = name;
            Description = description;
            TotalPages = totalPages;
            Image = image;
            ReadStatus = ReadStatus.Pending;
            Genres = new List<Genre>();
            Authors = new List<Author>();
        }

        private void ValidateDomain(string name, string? description, int? totalPages, string? image)
        {
            BookValidation.ValidateName(name);
            BookValidation.ValidateDescription(description);
            BookValidation.ValidateTotalPages(totalPages);
            BookValidation.ValidateImage(image);
        }

        public void StartReading()
        {
            ReadStatus = ReadStatus.InProgress;
            ReadStartDate = DateTime.Now;
            ReadStopDate = null;
            ReadConclusionDate = null;
        }

        public void StopReading()
        {
            ReadStatus = ReadStatus.Pending;
            ReadStopDate = DateTime.Now;
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
            ReadConclusionDate = DateTime.Now;
            ReadStopDate = null;
        }

        public void Update(string name, int publisherId, int categoryId, ICollection<BookAuthor> authors, ICollection<BookGenre> genres, string? description, int? totalPages, string? image)
        {
            ValidateDomain(name, description, totalPages, image);
            BookValidation.ValidateBookAuthors(authors);
            BookValidation.ValidatePublisherId(publisherId);
            BookValidation.ValidateCategoryId(categoryId);

            Name = name;
            Description = description;
            TotalPages = totalPages;
            Image = image;
            PublisherId = publisherId;
            CategoryId = categoryId;
            BookAuthors = authors;
            BooksGenres = genres;
        }
    }
}
