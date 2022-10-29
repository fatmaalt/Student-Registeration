using System.Threading.Tasks;
using student_registration.Data;
//using student_registration.Dtos.User;
using student_registration.Models;
using Microsoft.AspNetCore.Mvc;
using student_registration.Dtos.User;

namespace student_registration.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;
        public AuthController(IAuthRepository authRepo)
        {
            _authRepo = authRepo;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegisterDto request)
        {
            var response = await _authRepo.Register(
                new User { Username = request.Username }, request.Password, request.Email
            );
            if (!response.Sucess)
            {
                return BadRequest(response);
            }
        
            return Ok(response);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(UserLoginDto request)
        {
            var response = await _authRepo.Login(
                request.Username, request.Password
            );
            if (!response.Sucess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}