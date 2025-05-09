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
        }
    }
}
