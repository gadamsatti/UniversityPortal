using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityPortal.Models;
using UniversityPortal.Service;

namespace UniversityPortal.Repository
{
    public class AccountRepository:IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly IUserService _userService;

        public AccountRepository(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,IUserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userService = userService;
        }


        //User Can SignUp
        public async Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel)
        {
            var user = new ApplicationUser()
            {
                FirstName=userModel.FirstName,
                LastName=userModel.LastName,
                DateOfBirth=userModel.DateOfBirth,
                Gender=userModel.Gender,
                PhoneNumber=userModel.ContactNo.ToString(),
                UserId=userModel.UserId,
                Email=userModel.Email,
                UserName=userModel.Email
            };
          var result = await _userManager.CreateAsync(user,userModel.Password);
            // Adding Roles to New User
            await _userManager.AddToRoleAsync(user,"User");

            return result;
        }

        //User Can Signin

        public async Task<SignInResult> PasswordSignInAsync(SignInModel signInModel)
        {
            var result = await _signInManager.PasswordSignInAsync(signInModel.Email, signInModel.Password,signInModel.RememberMe,false);

            return result;
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }


        public async Task<IdentityResult> ChangePasswordAsync(ChangePasswordModel model)
        {
            var userId = _userService.GetUserId();

            var user = await _userManager.FindByIdAsync(userId);
            
            var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);

            return result;
        }


    }
}
