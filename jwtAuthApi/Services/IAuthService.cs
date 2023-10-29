using jwtAuth.Data.Model;

namespace jwtAuthApi.Services
{
    public interface IAuthService
    {
        Task<(int, string)> Registeration(RegisterModel model, string role);
        Task<(int, string)> Login(LoginModel model);
    }
}
