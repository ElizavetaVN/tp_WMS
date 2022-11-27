using AutoMapper;
using System;
using Application.Common.Mappings;
using Domain;

namespace Application.Staff.Queries.GetStaffList
{
    public class StaffLookupDto : IMapWith<Domain.Staff>//список пользователей 
    {//каждая запись списка содержит ту информацию, которая необходима
        public Guid Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Staff, StaffLookupDto>()
                .ForMember(staffDto => staffDto.Id,
                    opt => opt.MapFrom(staff => staff.Id))
                .ForMember(staffDto => staffDto.Surname,
                    opt => opt.MapFrom(staff => staff.Surname))
                .ForMember(staffDto => staffDto.Name,
                    opt => opt.MapFrom(staff => staff.Name));
        }
    }
}
