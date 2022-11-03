using StudentApp.Api.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApp.API.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetStudents();
    }
}
