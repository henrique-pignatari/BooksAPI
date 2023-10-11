﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Domain.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException(string message) : base(message) { }

        public static void When(bool hasError, string message)
        {
            if (hasError)
            {
                throw new DomainException(message);
            }
        }
    }
}
