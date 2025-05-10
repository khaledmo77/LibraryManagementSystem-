using AutoMapper;
using LiberaryManagmentSystem.Models;
using LiberaryManagmentSystem.ViewModels;
namespace LiberaryManagmentSystem.AutoMapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AuthorViewModel, Author>().ReverseMap();
            CreateMap<Author, AuthorDetailsViewModel>()
               .ForMember(dest => dest.Books, opt => opt.MapFrom(src => src.Books));
            CreateMap<Book, BookMiniViewModel>();
            CreateMap<Book, BookViewModel>();
            CreateMap<Book, BookFormViewModel>();
            CreateMap<BookFormViewModel, Book>();
            CreateMap<BorrowBookViewModel, BorrowingTransaction>()
        
        .ForMember(dest => dest.BookId, opt => opt.MapFrom(src => src.BookId))
        .ForMember(dest => dest.BorrowedDate, opt => opt.MapFrom(src => src.BorrowedDate))
        .ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => src.BorrowedDate.AddDays(14)))
        .ForMember(dest => dest.ReturnedDate, opt => opt.Ignore());
        }
    }
}
