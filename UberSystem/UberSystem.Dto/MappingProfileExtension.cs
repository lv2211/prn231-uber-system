﻿using AutoMapper;
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

            CreateMap<User, UserResponseModel>();
            CreateMap<UpdateUserRequestModel, User>()
                .ForMember(dest => dest.Email, opt => opt.Ignore())
                .ForMember(dest => dest.Role, opt => opt.Ignore())
                .ForMember(dest => dest.EmailVerified, opt => opt.Ignore())
                .ForMember(dest => dest.VerifiedToken, opt => opt.Ignore());

            CreateMap<User, DriverResponseModel>()
                .ForMember(dest => dest.DriverId, opt => opt.MapFrom(src => src.Drivers.Select(d => d.Id).First()))
                .ForMember(dest => dest.Dob, opt => opt.MapFrom(src => src.Drivers.Select(d => d.Dob).First()))
                .ForMember(dest => dest.CreateAt, opt => opt.MapFrom(src => src.Drivers.Select(d => d.CreateAt).First()));

            CreateMap<FeedbackRequestModel, Rating>();
            CreateMap<Driver, DriverResponseModel>()
                .ForMember(dest => dest.DriverId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Cabs.Select(c => c.Type).First()))
                .ForMember(dest => dest.RegNo, opt => opt.MapFrom(src => src.Cabs.Select(c => c.RegNo).First()))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.User.Id))
                .ForMember(dest => dest.CreateAt, opt => opt.Ignore());

            CreateMap<TripRequestModel, Trip>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => TripStatus.Ongoing))  // default value for booking a trip
                .ForMember(dest => dest.CreateAt, opt => opt.MapFrom(src => BitConverter.GetBytes(DateTime.Now.Ticks)));
        }
    }
}
