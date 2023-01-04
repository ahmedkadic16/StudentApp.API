using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentApp.API.DomainModels;
using StudentApp.API.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApp.API.Controllers
{
    [ApiController] //annottating controlelr
    public class StudentsController : Controller
    {
        private readonly IStudentRepository studentRepository;
        private readonly IMapper mapper;
        private readonly IImageRepository imageRepository;

        public StudentsController(IStudentRepository studentRepository,IMapper mapper,
            IImageRepository imageRepository)
        {
            this.studentRepository = studentRepository;
            this.mapper = mapper;
            this.imageRepository = imageRepository;
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
        [Route("[controller]/{studentId:guid}"),ActionName("GetStudent")]
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

        [HttpPost]
        [Route("[controller]/Add")]
        public async Task<IActionResult> AddStudent([FromBody] AddStudentRequest request)
        {
           var student=await studentRepository.AddStudent(mapper.Map<Api.DataModels.Student>(request));
            return CreatedAtAction(nameof(GetStudent), new { studentId = student.Id }, mapper.Map<Student>(student));
        }
        [HttpPost]
        [Route("[controller]/{studentId:guid}/upload-image")]
        public async Task<IActionResult> UploadImage([FromRoute] Guid studentId,IFormFile profileImage)
        {
            if(await studentRepository.Exists(studentId))
            {
                var fileName = Guid.NewGuid() + Path.GetExtension(profileImage.FileName);
                var fileImagePath = await imageRepository.Upload(profileImage, fileName);

                if(await studentRepository.UpdateProfileImage(studentId, fileImagePath))
                {
                    return Ok(fileImagePath);
                }
                return StatusCode(StatusCodes.Status500InternalServerError, "Error uploading image");


            }
            return NotFound();

        }




    }


}
