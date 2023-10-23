using Books.Domain.Constraints;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Application.DTOs.SendDTOs
{
    public class GenreSendDTO
    {
        [Required]
        [DisplayName("Id")]
        public string Id { get; set; }

        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(GenreConstraints.MinNameLength)]
        [MaxLength(GenreConstraints.MaxNameLength)]
        [DisplayName("Title")]
        public string Name { get; set; }
    }
}
