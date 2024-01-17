using Exam3.Business.ViewModels.AuthVMs;
using Exam3.Core.Enums;
using Exam3.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace Exam3.Business.Services.Implements
{
    public class AuthService : IAuthService
    {
        UserManager<AppUser> _userManager { get; }
        SignInManager<AppUser> _signInManager { get; }
        RoleManager<IdentityRole> _roleManager { get; }

        public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task<bool> Login(LoginVM vm)
        {
            AppUser user = new();
            if(vm.UsernameOrEmail.Contains("@"))
            {
                user = await _userManager.FindByEmailAsync(vm.UsernameOrEmail);
            }
            else
            {
                user = await _userManager.FindByNameAsync(vm.UsernameOrEmail);
            }
            if (user == null)
            {
                return false;
            }
            var result = await _signInManager.PasswordSignInAsync(user,vm.Password,vm.RememberMe,false);
            if (!result.Succeeded)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> Register(RegisterVM vm)
        {
            AppUser user = new AppUser
            {
                Email = vm.Email,
                UserName = vm.Username,
                Name = vm.Name,
                Surname = vm.Surname,
            };
            var result = await _userManager.CreateAsync(user,vm.Password);
            if (!result.Succeeded)
            {
                return false;
            }
            var resul2 = await _userManager.AddToRoleAsync(user, Roles.Member.ToString());
            return true;
        }

        public async Task<bool> CreateRoles()
        {
            foreach (var item in Enum.GetNames(typeof(Roles)))
            {
                if(!await _roleManager.RoleExistsAsync(item))
                {
                    await _roleManager.CreateAsync(new IdentityRole { Name = item});
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        public async Task<bool> CreateAdmin()
        {
            if(await _userManager.FindByNameAsync("Admin") == null)
            {
                AppUser admin = new AppUser
                {
                    Email = "admin@gmail.com",
                    Name = "admin",
                    Surname = "admin",
                    UserName = "admin",
                };
                var result = await _userManager.CreateAsync(admin,"Admin123");
                if(!result.Succeeded)
                {
                    return false;
                }
                var result2 = await _userManager.AddToRoleAsync(admin, Roles.Admin.ToString());
                if (!result2.Succeeded)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            return true;
        }
    }
}
