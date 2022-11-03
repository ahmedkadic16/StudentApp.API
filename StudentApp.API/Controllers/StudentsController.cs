﻿using AutoMapper;
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
    }
}