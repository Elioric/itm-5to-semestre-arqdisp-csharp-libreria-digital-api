using AutoMapper;
using LibreriaDigital.Application.DTOs;
using LibreriaDigital.Domain.Entities;

namespace LibreriaDigital.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<BookCreateDto, Book>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()); 

            CreateMap<Book, BookDetailsDto>()
                .ForMember(dest => dest.UserName, 
                           opt => opt.MapFrom(src => src.User.Name));

            CreateMap<UserCreateDto, User>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()); 

           CreateMap<User, UserDetailsDto>()
                .ForMember(
                    dest => dest.BookTitles, // Propiedad en el DTO (destino)
                    opt => opt.MapFrom(
                        src => src.Books.Select(b => b.Title) // Lógica: Toma la colección Books y mapea solo el Title
                    )
                );

            CreateMap<UserDetailsDto, User>()
                .ForMember(dest => dest.Books, opt => opt.Ignore());
        
        }
    }
}