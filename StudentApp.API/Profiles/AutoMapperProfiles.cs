using AutoMapper;
using DataModels= StudentApp.Api.DataModels;
using StudentApp.API.DomainModels;
using StudentApp.API.Profiles.AfterMaps;

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
            CreateMap<UpdateStudentRequest, DataModels.Student>()
                 .AfterMap<UpdateStudentRequestAfterMap>();
        }
    }
}
