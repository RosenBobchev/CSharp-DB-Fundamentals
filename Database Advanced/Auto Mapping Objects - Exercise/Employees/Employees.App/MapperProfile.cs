namespace Employees.App
{
    using AutoMapper;
    using Employees.Models;
    using Models;

    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<EmployeeDto, Employee>().ReverseMap();
            CreateMap<Employee, Employee>();

            CreateMap<Employee, EmployeePersonalInfoDto>().ReverseMap();

            CreateMap<Employee, ManagerDto>()
                .ForMember(dest => dest.EmployeeDto, from => from.MapFrom(x => x.ManagerEmployees)).ReverseMap();

            CreateMap<Employee, EmployeeWithManagerDto>().ForMember(dest => dest.ManagerLastName, from => from.MapFrom(x => x.Manager.LastName)).ReverseMap();
        }
    }
}