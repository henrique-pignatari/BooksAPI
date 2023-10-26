using AutoMapper;
using Books.Application.DTOs.ReceiveDTOs;
using Books.Application.DTOs.SendDTOs;
using Books.Application.Interfaces;
using Books.Domain.Entities;
using Books.Domain.Interfaces;
using HashidsNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Application.Services
{
    public class GenreService : ServiceBase<Genre, IGenreRepository, GenreSendDTO, GenreReceiveDTO>, IGenreService
    {
        public GenreService(IGenreRepository repository, IMapper mapper, IHashids hashIds) : base(repository, mapper, hashIds)
        {
        }
    }
}
