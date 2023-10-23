using Books.Domain.Constraints;
using Books.Domain.Entities;
using Books.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Books.Application.DTOs.SendDTOs
{
    public class BooksSendDTO
    {
        [Required]
        [DisplayName("Id")]
        public string Id { get; set; }

        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(BookConstraints.MinNameLength)]
        [MaxLength(BookConstraints.MaxNameLength)]
        [DisplayName("Title")]
        public string Name { get; set; }

        [MinLength(BookConstraints.MinDescriptionLength)]
        [MaxLength(BookConstraints.MaxDescriptionLength)]
        [DisplayName("Description")]
        public string Description { get; set; }

        [DisplayName("Pages")]
        public int TotalPages { get; set; }

        [MaxLength(BookConstraints.MaxImageLength)]
        [DisplayName("Image")]
        public string Image { get; set; }

        [DisplayName("ReadStatus")]
        public ReadStatus ReadStatus { get; set; }

        [DisplayName("ReadStartDate")]
        [DataType(DataType.DateTime)]
        public DateTime? ReadStartDate { get; set; }

        [DisplayName("ReadStopDate")]
        [DataType(DataType.DateTime)]
        public DateTime? ReadStopDate { get; set; }

        [DisplayName("ReadConclusionDate")]
        [DataType(DataType.DateTime)]
        public DateTime? ReadConclusionDate { get; set; }

        [DisplayName("Publisher")]
        public Publisher Publisher { get; private set; }

        [DisplayName("Category")]
        public Category Category { get; private set; }

        [DisplayName("Genres")]
        public ICollection<Genre> Genres { get; private set; }

        [DisplayName("Authors")]
        public ICollection<Author> Authors { get; private set; }
    }
}
