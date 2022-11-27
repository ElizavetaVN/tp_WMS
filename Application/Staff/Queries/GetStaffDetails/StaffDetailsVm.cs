using System;
using AutoMapper;
using Application.Common.Mappings;
using Domain;

namespace Application.Staff.Queries.GetStaffDetails
{
    public class StaffDetailsVm : IMapWith<Domain.Staff>//описывает то, что будет возвращаться пользователю,  когда он запросит парамтеры сотрудника
    {
        public Guid Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }

        public void Mapping(Profile profile)//создание соответствие между классом Staff и StaffDetailsVm
        {
            profile.CreateMap<Domain.Staff, StaffDetailsVm>()
                .ForMember(staffVm => staffVm.Surname,
                    opt => opt.MapFrom(staff => staff.Surname))
                .ForMember(staffVm => staffVm.Name,
                    opt => opt.MapFrom(staff => staff.Name))
                .ForMember(staffVm => staffVm.Id,
                    opt => opt.MapFrom(staff => staff.Id))
                .ForMember(staffVm => staffVm.DateOfBirth,
                    opt => opt.MapFrom(staff => staff.DateOfBirth));
        }
    }
}
