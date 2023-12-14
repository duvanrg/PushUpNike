
using API.Dtos;
using AutoMapper;
using Domain.Entities;

namespace API.profiles
{
    public class MappinProfiles : Profile
    {
        public MappinProfiles()
        {
            CreateMap <Categoria, CategoriaDto > ().ReverseMap();
            CreateMap <Producto, ProductoDto > ().ReverseMap();
        }
    }
}
