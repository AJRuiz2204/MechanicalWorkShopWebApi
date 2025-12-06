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
            CreateMap<UserRegisterDto, User>()

                // Ignoramos PasswordHash porque lo generamos con criptografía en el Service
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
                .ForMember(dest => dest.PasswordSalt, opt => opt.Ignore())
                .ForMember(dest => dest.ID, opt => opt.Ignore())
                .ForMember(dest => dest.Profile, opt => opt.Ignore())
                .ForMember(dest => dest.ResetCode, opt => opt.Ignore())
                .ForMember(dest => dest.ResetCodeExpiry, opt => opt.Ignore());


        }
    }
}