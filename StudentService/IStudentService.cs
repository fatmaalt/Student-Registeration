//using StudentRegistrationAPI.Dtos.Student;


using student_registration.Models;

using student_registration.Dtos.Student;
using student_registration.Models;

namespace student_registration.Services.StudentService
{
    public interface IStudentService
    {

        Task<ServiceResponse<List<GetStudentDto>>> GetAllStudents();
        Task<ServiceResponse<GetStudentDto>> GetStudentById(Guid id);
        Task<ServiceResponse<List<GetStudentDto>>> AddStudent(AddStudentDto newStudent);

        Task<ServiceResponse<GetStudentDto>> UpdateStudent(UpdateStudentDto updatedStudent);
        Task<ServiceResponse<List<GetStudentDto>>> DeleteStudent(Guid id);

    }
}