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

            CreateMap<BookSendDTO, Book>()
                .ForMember(dest => dest.Id, opt => opt.ConvertUsing<IntFromHash, string>());

            CreateMap<BookReceiveDTO, Book>()
                .ForMember(dest => dest.CategoryId, opt => opt.ConvertUsing<IntFromHash, string>())
                .ForMember(dest => dest.PublisherId, opt => opt.ConvertUsing<IntFromHash, string>());

            CreateMap<Author, AuthorSendDTO>()
                .ForMember(dest => dest.Id, opt => opt.ConvertUsing<HashFormatter, int>());

            CreateMap<AuthorSendDTO, Author>()
                .ForMember(dest => dest.Id, opt => opt.ConvertUsing<IntFromHash, string>());

            CreateMap<AuthorReceiveDTO, Author>();

            CreateMap<Category, CategorySendDTO>()
                .ForMember(dest => dest.Id, opt => opt.ConvertUsing<HashFormatter, int>());

            CreateMap<CategorySendDTO, Category>()
                .ForMember(dest => dest.Id, opt => opt.ConvertUsing<IntFromHash, string>());

            CreateMap<CategoryReceiveDTO, Category>();

            CreateMap<Genre, GenreSendDTO>()
                .ForMember(dest => dest.Id, opt => opt.ConvertUsing<HashFormatter, int>());

            CreateMap<GenreSendDTO, Genre>()
                .ForMember(dest => dest.Id, opt => opt.ConvertUsing<IntFromHash, string>());

            CreateMap<GenreReceiveDTO, Genre>();

            CreateMap<Publisher, PublisherSendDTO>()
                .ForMember(dest => dest.Id, opt => opt.ConvertUsing<HashFormatter, int>());

            CreateMap<PublisherSendDTO, Publisher>()
                .ForMember(dest => dest.Id, opt => opt.ConvertUsing<IntFromHash, string>());

            CreateMap<PublisherReceiveDTO, Publisher>();
        }
    }
}
