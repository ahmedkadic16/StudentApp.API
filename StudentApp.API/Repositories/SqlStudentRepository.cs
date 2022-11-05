using StudentApp.Api.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StudentApp.API.Repositories
{
    public class SqlStudentRepository : IStudentRepository
    {
        private readonly StudentAdminContext context;

        public SqlStudentRepository(StudentAdminContext context)
        {
            this.context = context;
        }

        

        public async Task<List<Student>> GetStudents()
        {
           return await context.Student.Include(nameof(Gender)).Include(nameof(Address)).ToListAsync();
        }
        public async Task<Student> GetStudent(Guid studentId)
        {
              return await context.Student
                .Include(nameof(Gender)).Include(nameof(Address))
                .FirstOrDefaultAsync(x=>x.Id ==studentId);
        }

    }
}
