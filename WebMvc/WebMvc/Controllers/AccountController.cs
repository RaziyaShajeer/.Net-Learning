using System.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using WebMvc.Models.ViewModels;

namespace WebMvc.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            this._userManager = userManager;
                this._signInManager = signInManager;
            this._roleManager = roleManager;
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult>Login(LoginViewModel model,string ReturnUrl="/")
        {
            if (!ModelState.IsValid)
                return View(model);
            var User = await _userManager.FindByNameAsync(model.UserName);
            if(User == null)
            {
                ModelState.AddModelError(string.Empty, "User not found");
                return View(model);
            }
            var res = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, true, true);
            if (res.Succeeded)
            {
                    Console.WriteLine("Hello1");
                var role = await _userManager.GetRolesAsync(User);
                    Console.WriteLine("Hello2");
                foreach (var item in role)
                {
                    Console.WriteLine(item);
                    Console.WriteLine("Hello3");
                }
                switch (role.First())
                {
                    case "Admin":
                        return RedirectToAction("Index", "Dashboard", new {area="Admin"});
                    case "Seller":
                        return RedirectToAction("Index", "Dashboard", new { area = "Seller" });
                    case "Customer":
                        //return RedirectToAction("Index", "", new { area = "Customer" });
                        return Redirect(ReturnUrl);
                }
                
            }

            else if(res.IsLockedOut)
            {
                ModelState.AddModelError(string.Empty, "Account Locked plz wait");
                return View(model);
            }
            else if (res.IsNotAllowed)
            {
                ModelState.AddModelError(string.Empty, "Login os not Allowed");
                return View(model);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Plz Check Credentials");
                return View(model);
            }

                return View(model);
        }





        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }



        public IActionResult SellerRegister()
        {
            return View();
        }




        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            { 
            return View(model);
            }
            IdentityUser User = new()
            {
                UserName = model.UserName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber
            };
            var res = await _userManager.CreateAsync(User, model.Password);
            if (res.Succeeded)
            {
                //Assign "Admin" role to the user
                await _userManager.AddToRoleAsync(User,model.Role);
                return RedirectToAction(nameof(Login));
            }
            else {
                foreach (var err in res.Errors)
                    ModelState.AddModelError(string.Empty, err.Description);
            }
            
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }

        public IActionResult AccessDenied()
        {
            return View();
        }


        // Roles Static

        //public async Task<IActionResult> CreateRole()
        //{
        //    await _roleManager.CreateAsync(new IdentityRole("Customer"));
        //    return Ok("RoleCreated");
        //}
    }
}
