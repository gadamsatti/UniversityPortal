using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using UniversityPortal.Models;

namespace UniversityPortal.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel);

        Task<SignInResult> PasswordSignInAsync(SignInModel signInModel);

        Task SignOutAsync();

        Task<IdentityResult> ChangePasswordAsync(ChangePasswordModel model);
    }
}