using AutoMapper;
using DataModels= StudentApp.Api.DataModels;
using StudentApp.API.DomainModels;

namespace StudentApp.API.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<DataModels.Student, Student>()
                .ReverseMap();
            CreateMap<DataModels.Gender, Gender>()
               .ReverseMap();
            CreateMap<DataModels.Address, Address>()
               .ReverseMap();

        }
    }
}
