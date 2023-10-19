using Books.Domain.ErrorMessages;
using Books.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Domain.Validation
{
    public static class EntityValidation
    {
        public static void ValidateId(int id)
        {
            DomainException.When(id < 0, EntityErrorMessages.NegativeId);
        }
    }
}
