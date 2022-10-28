using System.Threading.Tasks;
using student_registration.Models;

namespace student_registration.Data
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(User user, string email, string password);
        Task<ServiceResponse<string>> Login(string username, string password);
        Task<bool> UserExists(string username);

        Task<bool> EmailExists(string email);
    }
}