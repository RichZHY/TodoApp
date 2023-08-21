using AutoMapper;
using Data.DataTransferObjects;
using TodoApp.API.Models;

namespace TodoApp.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EmployeeUpdateDto, Employee>();
        }
    }
}
