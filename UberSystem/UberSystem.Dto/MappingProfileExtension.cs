using AutoMapper;
using UberSystem.Domain.Entities;
using UberSystem.Domain.Enums;
using UberSystem.Dto.Requests;
using UberSystem.Dto.Responses;

namespace UberSystem.Dto
{
    public class MappingProfileExtension : Profile
    {
        /// <summary>
        /// Mapping entities with data transfer objects
        /// </summary>
        public MappingProfileExtension()
        {
            CreateMap<User, LoginResponseModel>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.ToString()));

            CreateMap<SignupModel, User>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => Enum.Parse(typeof(UserRole), src.Role, true)))
                .ForMember(dest => dest.EmailVerified, opt => opt.MapFrom(src => false));   // Before email verificitaion process, the value of property is false
        }
    }
}
