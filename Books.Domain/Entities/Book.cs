﻿using Books.Domain.Enums;
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
        public ReadStatus ReadStatus { get; private set; }
        public DateTime? ReadStartDate { get; private set; }
        public DateTime? ReadStopDate { get; private set; }
        public DateTime? ReadConclusionDate { get; private set; }

        public int PublisherId { get; private set; }
        public Publisher Publisher { get; private set; }
        public int CategoryId { get; private set; }
        public Category Category { get; private set; }
        public ICollection<Genre> Genres { get; private set; }
        public ICollection<BookAuthor> BookAuthors { get; private set; }

        public Book(string title, int publisherId, int categoryId, ICollection<BookAuthor> authors)
            : this(title, publisherId, categoryId, authors, null, null, null) { }

        public Book(string title, int publisherId, int categoryId, ICollection<BookAuthor> authors, string? description, int? totalPages, string? image) : base()
        {
            BookValidation.ValidateTitle(title);
            BookValidation.ValidateDescription(description);
            BookValidation.ValidateTotalPages(totalPages);
            BookValidation.ValidateImage(image);
            BookValidation.ValidatePublisherId(publisherId);
            BookValidation.ValidateCategoryId(categoryId);
            BookValidation.ValidateBookAuthors(authors);

            Title = title;
            Description = description;
            TotalPages = totalPages;
            Image = image;
            ReadStatus = ReadStatus.Pending;
            PublisherId = publisherId;
            CategoryId = categoryId;
            BookAuthors = authors;
        }
    }
}
