using Exam3.Business.ViewModels.AuthVMs;
using Exam3.Business.ViewModels.CardVMs;

namespace Exam3.Business.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<bool> Register(RegisterVM vm);
        public Task<bool> Login(LoginVM vm);
        public Task<bool> CreateRoles();
    }
}
