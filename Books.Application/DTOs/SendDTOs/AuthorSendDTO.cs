using Books.Domain.Constraints;
using Books.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Application.DTOs.SendDTOs
{
    public class AuthorSendDTO
    {
        [Required]
        [DisplayName("Id")]
        public string Id { get; set; }

        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(AuthorConstraints.MinNameLength)]
        [MaxLength(AuthorConstraints.MaxNameLength)]
        [DisplayName("Title")]
        public string Name { get; set; }
    }
}
