using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dtos;
using WebApi.Models;
using WebApi.Repositories;
using System.Data;
using WebApi.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/Students")]
    public class StudentController: ControllerBase
    {
    /*
        private readonly DataContext context;
        public StudentController(DataContext context){
            this.context = context;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try 
            {
                return Ok(context.Students.ToList());
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    
        [HttpGet("{StudentId}")]
        public ActionResult GetStudent(int StudentId)
        {
            try 
            {
                var student = context.Students.FirstOrDefault(f => f.StudentId == StudentId);
                return Ok(student);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        */

        private readonly IStudentRepository _studentRepository;
        public StudentController(IStudentRepository studentRepository)
        {
        _studentRepository = studentRepository;
        }
    
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            var students = await _studentRepository.GetAll();
            return Ok(students);
        }
    
        [HttpGet("{StudentId}")]
        public async Task<ActionResult<Student>> GetStudent(int StudentId)
        {
            var student = await _studentRepository.Get(StudentId);
            if(student == null)
                return NotFound();
    
            return Ok(student);
        }
        [HttpPost]
        public async Task<ActionResult> CreateStudent(CreateStudentDto createStudentDto)
        {
            Student student = new()
            {
                StudentId = createStudentDto.StudentId,
                StudentName = createStudentDto.StudentName,
                ParentName = createStudentDto.ParentName,
                PhoneNumber = createStudentDto.PhoneNumber,
                City = createStudentDto.City,
            };
            await _studentRepository.Add(student);
            return Ok();
        }
    
        [HttpDelete("{StudentId}")]
        public async Task<ActionResult> DeleteStudent(int StudentId)
        {
            await _studentRepository.Delete(StudentId);
            return Ok();
        }
    
        [HttpPut("{StudentId}")]
        public async Task<ActionResult> UpdateStudent(int StudentId, UpdateStudentDto updateStudentDto)
        {
            Student student = new()
            {
                StudentName = updateStudentDto.StudentName,
                ParentName = updateStudentDto.ParentName,
                PhoneNumber = updateStudentDto.PhoneNumber,
                City = updateStudentDto.City,
            };
            
    
            await _studentRepository.Update(student);
            return Ok();
    
        }
        
    }
}