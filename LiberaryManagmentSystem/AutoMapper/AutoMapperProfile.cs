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
        }
    }
}
