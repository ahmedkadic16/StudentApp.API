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
    [ApiController]
    public class GendersController : Controller
    {
        private readonly IStudentRepository studentRepository;
        private readonly IMapper mapper;

        public GendersController(IStudentRepository studentRepository,IMapper mapper )
        {
            this.studentRepository = studentRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllGenders()
        {
            var genderList = await studentRepository.GetGenders();

           
            return Ok(mapper.Map<List<Gender>>(genderList));
        }
    }
 
}
