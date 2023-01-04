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
        Task<Student> GetStudent(Guid studentId);
        Task<List<Gender>> GetGenders();
        Task<bool> Exists(Guid studentId);
        Task<Student> UpdateStudent(Guid studentId, Student request);
        Task<Student> DeleteStudent(Guid studentId);

        Task<Student> AddStudent(Student request);
        Task<bool> UpdateProfileImage(Guid studentId, string profileImageUrl);
    }
}
