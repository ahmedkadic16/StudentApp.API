using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentApp.API.DomainModels;
using StudentApp.API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApp.API.Controllers
{
    [ApiController] //annottating controlelr
    public class StudentsController : Controller
    {
        private readonly IStudentRepository studentRepository;
        private readonly IMapper mapper;

        public StudentsController(IStudentRepository studentRepository,IMapper mapper)
        {
            this.studentRepository = studentRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await studentRepository.GetStudents();

            return Ok(mapper.Map<List<Student>>(students));
        }

        [HttpGet]
        [Route("[controller]/{studentId:guid}")]
        public async Task<IActionResult> GetStudent([FromRoute] Guid studentId)
        {
            var student = await studentRepository.GetStudent(studentId);

            if (student == null) {
                return NotFound();
            }

            return Ok(mapper.Map<Student>(student));
        }
        [HttpPut]
        [Route("[controller]/{studentId:guid}")]
        public async Task<IActionResult> UpdateStudent([FromRoute] Guid studentId,[FromBody] UpdateStudentRequest request)
        {
            if( await studentRepository.Exists(studentId))
            {//update student
             var updatetStudent = await studentRepository.UpdateStudent(studentId, mapper.Map<Api.DataModels.Student>(request));

                if(updatetStudent !=null)
                {
                    return Ok(mapper.Map<Student>(updatetStudent));
                }
            }
            return NotFound();
        }
        [HttpDelete]
        [Route("[controller]/{studentId:guid}")]
        public async Task<IActionResult> DeleteStudent([FromRoute] Guid studentId)
        {
            if(await studentRepository.Exists(studentId))
            {
               var student= await this.studentRepository.DeleteStudent(studentId);
                return Ok(mapper.Map<Student>(student));
            }
            return NotFound();
        }
    }
}
