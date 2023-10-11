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

        public Book(string title, string? description, int? TotalPages, string? Image) : base()
        {

        }

    }
}
