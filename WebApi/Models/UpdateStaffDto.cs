using AutoMapper;
using System;
using Application.Common.Mappings;
using Application.Staff.Commands.UpdateStaff;

namespace WebApi.Models
{
    public class UpdateStaffDto : IMapWith<UpdateStaffCommand>
    {
        public Guid Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateStaffDto, UpdateStaffCommand>()
                .ForMember(staffCommand => staffCommand.Id,
                    opt => opt.MapFrom(staffDto => staffDto.Id))
                .ForMember(staffCommand => staffCommand.Surname,
                    opt => opt.MapFrom(staffDto => staffDto.Surname))
                .ForMember(staffCommand => staffCommand.Name,
                    opt => opt.MapFrom(staffDto => staffDto.Name));
        }
    }
}
