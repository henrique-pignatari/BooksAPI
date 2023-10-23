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
    public class CategorySendDTO
    {
        [Required]
        [DisplayName("Id")]
        public string Id { get; set; }

        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(CategoryConstraints.MinNameLength)]
        [MaxLength(CategoryConstraints.MaxNameLength)]
        [DisplayName("Title")]
        public string Name { get; set; }
    }
}
