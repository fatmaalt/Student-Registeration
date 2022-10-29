using Microsoft.AspNetCore.Mvc;
using student_registration.Dtos.Student;
using student_registration.Services.StudentService;
using student_registration.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using student_registration.RabbitMQService;

namespace student_registration.Controllers
{
    [Authorize(Roles = "Student, Admin")]
    [ApiController]
    [Route("api/[controller]")]

    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IMessageProducer _messagePublisher;
        private readonly ILogger<StudentController> _logger;
        public StudentController(IStudentService studentService, IMessageProducer messagePublisher, ILogger<StudentController> logger)
        {
            _studentService = studentService;
            _messagePublisher = messagePublisher;
            _logger =logger;
        }


        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetStudentDto>>>> Get()
        {
            //  int id = int.Parse(User.Claims.FirstOrDefault(c => c.Type ==ClaimTypes.NameIdentifier).Value);
            return Ok(await _studentService.GetAllStudents());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetStudentDto>>> GetSingle(Guid id)
        {
            return Ok(await _studentService.GetStudentById(id));
        }



        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetStudentDto>>>> AddStudent(AddStudentDto newStudent)
        {
           _messagePublisher.SendMessage(newStudent);
            return Ok(await _studentService.AddStudent(newStudent));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetStudentDto>>> UpdateStudent(UpdateStudentDto updatedStudent)
        {
            var response = await _studentService.UpdateStudent(updatedStudent);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            //
            _messagePublisher.SendMessage(updatedStudent);
            return Ok(response);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetStudentDto>>>> Delete(Guid id)
        {
            var response = await _studentService.DeleteStudent(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

    }
}