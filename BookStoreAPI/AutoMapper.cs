using AutoMapper;
using BookStoreAPI.DTO;
using BookStoreAPI.Models;

namespace BookStoreAPI
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Role, RoleDTO>().ReverseMap();
            CreateMap<Author, AuthorDTO>().ReverseMap();
            CreateMap<Book, BookDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Publisher, PublisherDTO>().ReverseMap();
        }
    }
}
