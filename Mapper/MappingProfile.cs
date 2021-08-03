using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Library.Models;
using Library.DtoModels;

namespace Library.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDTO>().ReverseMap();
            CreateMap<Client, ClientDTO>().ReverseMap();
            CreateMap<BooksRental, BooksRentalDTO>().ReverseMap();
        }
    }
}