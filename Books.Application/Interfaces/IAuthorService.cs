using Books.Application.DTOs.ReceiveDTOs;
using Books.Application.DTOs.SendDTOs;
using Books.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Application.Interfaces
{
    public interface IAuthorService : IService<AuthorSendDTO, AuthorReceiveDTO>
    {
    }
}
