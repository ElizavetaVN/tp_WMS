using Application.Staff.Commands.CreateStaff;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Application.Common.Mappings;

namespace WebApi.Models
{
    public class CreateStaffDto : IMapWith<CreateStaffCommand>
    {
        [Required]
        public string Surname { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateStaffDto, CreateStaffCommand>()
                .ForMember(staffCommand => staffCommand.Surname,
                    opt => opt.MapFrom(staffDto => staffDto.Surname))
                .ForMember(staffCommand => staffCommand.Name,
                    opt => opt.MapFrom(staffDto => staffDto.Name));
        }
    }
}
