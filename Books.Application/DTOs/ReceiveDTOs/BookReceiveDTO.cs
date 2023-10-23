using Books.Domain.Constraints;
using Books.Domain.Entities;
using Books.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Application.DTOs.ReceiveDTOs
{
    public class BookReceiveDTO
    {
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
        public int ReadStatus { get; set; }

        [DisplayName("PublisherId")]
        public string PublisherId { get; private set; }

        [DisplayName("CategoryId")]
        public string CategoryId { get; private set; }

        [DisplayName("GenresIds")]
        public ICollection<string> GenresIds { get; private set; }

        [DisplayName("AuthorsIds")]
        public ICollection<string> AuthorsIds { get; private set; }
    }
}
