using AutoMapper;

namespace Application.Common.Mappings
{
    public interface IMapWith<T> //инфраструктура (все что относится к поведениям, исключениям)
    { //интерфейс с реализацией по умолчанию
        void Mapping(Profile profile) =>
            profile.CreateMap(typeof(T), GetType());
    }
}
