using AutoMapper;
using StudentApp.API.DomainModels;


namespace StudentApp.API.Profiles.AfterMaps
{
    public class UpdateStudentRequestAfterMap : IMappingAction<UpdateStudentRequest, Api.DataModels.Student>
    {
        public void Process(UpdateStudentRequest source, Api.DataModels.Student destination, ResolutionContext context)
        {
            destination.Address = new Api.DataModels.Address()
            {
                PhysicalAddress = source.PhysicalAddress,
                PostalAddress = source.PostalAddress
            };
        }
    }
    
    }
