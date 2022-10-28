using AutoMapper;
using student_registration.Dtos.Student;

namespace student_registration
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile(){
            CreateMap<Studentt,GetStudentDto>();
             CreateMap<AddStudentDto,Studentt>();
         CreateMap<UpdateStudentDto,Studentt>();
    }}
}