using AutoMapper;
using Mechanical_workshop.Models;
using static MechanicalWorkShopWebApi.Domain.DTOs.UserDto;

namespace Mechanical_workshop.Services.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // De Entidad a DTO de Respuesta
            CreateMap<User, UserResponseDto>();

            // De DTO de Registro a Entidad
            CreateMap<UserRegisterDto, User>();
        }
    }
}