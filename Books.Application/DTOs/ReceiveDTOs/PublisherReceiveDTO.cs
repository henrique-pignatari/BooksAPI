using Books.Domain.Constraints;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Application.DTOs.ReceiveDTOs
{
    public class PublisherReceiveDTO
    {
        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(PublisherConstraints.MinNameLength)]
        [MaxLength(PublisherConstraints.MaxNameLength)]
        [DisplayName("Title")]
        public string Name { get; set; }

        [MaxLength(PublisherConstraints.MaxLogoLength)]
        [DisplayName("Logo")]
        public string? Logo { get; set; }
    }
}
