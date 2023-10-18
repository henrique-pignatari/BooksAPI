﻿using Books.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Domain.Entities
{
    public class Author : Entity
    {
        public string Name { get; set; }
        public ICollection<BookAuthor> BookAuthors { get; set; }

        public Author(string name) : base()
        {
            AuthorValidation.ValidateName(name);
            Name = name;
        }
    }
}
