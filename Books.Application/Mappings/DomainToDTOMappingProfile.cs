using AutoMapper;
using Books.Application.DTOs.ReceiveDTOs;
using Books.Application.DTOs.SendDTOs;
using Books.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Book, BookSendDTO>()
                .ForMember(dest => dest.Id, opt => opt.ConvertUsing<HashFormatter, int>());

            CreateMap<BookReceiveDTO, Book>()
                .ForMember(d => d.CategoryId, opt => opt.ConvertUsing<IntFromHash, string>())
                .ForMember(d => d.PublisherId, opt => opt.ConvertUsing<IntFromHash, string>());

            CreateMap<Author, AuthorSendDTO>()
                .ForMember(dest => dest.Id, opt => opt.ConvertUsing<HashFormatter, int>());

            CreateMap<AuthorReceiveDTO, Author>();

            CreateMap<Category, CategorySendDTO>()
                .ForMember(dest => dest.Id, opt => opt.ConvertUsing<HashFormatter, int>());

            CreateMap<CategoryReceiveDTO, Category>();

            CreateMap<Genre, GenreSendDTO>()
                .ForMember(dest => dest.Id, opt => opt.ConvertUsing<HashFormatter, int>());

            CreateMap<GenreReceiveDTO, Genre>();

            CreateMap<Publisher, PublisherSendDTO>()
                .ForMember(dest => dest.Id, opt => opt.ConvertUsing<HashFormatter, int>());

            CreateMap<PublisherReceiveDTO, Publisher>();
        }
    }
}
