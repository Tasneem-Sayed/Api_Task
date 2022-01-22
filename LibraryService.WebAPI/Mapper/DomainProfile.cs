using AutoMapper;
using LibraryService.WebAPI.Data;
using LibraryService.WebAPI.SeedData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryService.WebAPI.Mapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Book, BookForm>();
            CreateMap<BookForm, Book>();

            CreateMap<LibraryForm, Library>();
            CreateMap<Library, LibraryForm>();
        }
    }
}
