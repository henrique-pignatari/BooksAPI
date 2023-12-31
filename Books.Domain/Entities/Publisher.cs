﻿using Books.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Domain.Entities
{
    public class Publisher : Entity
    {
        public string Name { get; private set; }
        public string? Logo { get; private set; }
        public ICollection<Book> Books { get; private set; }

        public Publisher(string name, string? logo)
        {
            PublisherValidation.ValidateName(name);
            PublisherValidation.ValidateLogo(logo);

            Name = name;
            Logo = logo;
        }
    }
}
