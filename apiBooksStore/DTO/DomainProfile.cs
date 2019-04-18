using apiBooksStore.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiBooksStore.DTO
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Author, AuthorDTO>().ReverseMap();
            CreateMap<Book, BookDTO>().ReverseMap();
            CreateMap<BookSale, BookSaleDTO>().ReverseMap();
        }
    }
}
