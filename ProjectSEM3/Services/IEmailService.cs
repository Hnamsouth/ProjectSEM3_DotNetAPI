using ProjectSEM3.DTOs.Auth;

namespace ProjectSEM3.Services
{
    public interface IEmailService
    {
        bool SendEmail(string name,string email,string token);
    }
}
