using AutoMapper;
using examwork.DTO;
using examwork.Models;
using Microsoft.AspNetCore.Mvc;

namespace examwork.Areas.Public.Controllers
{
    [Area("Public")]
    public class PublicController : Controller
    {
        IMapper mapper;
        ApplicationDbContext _context = new ApplicationDbContext();

        public PublicController(IMapper _mapper)
        {
            mapper = _mapper;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]

        public IActionResult Register()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Register(UserDTO userDTO) 
        {
            try
            {
                if (ModelState.IsValid)
                {
                    student std = new student();
                    std = mapper.Map<student>(userDTO);
                    std.Role = Enums.Role.User;
                    _context.students.Add(std);
                    _context.SaveChanges();
                    return RedirectToAction("Login", "Public");
                }
                else
                {
                    TempData["Message"] = "Input data is not correct";
                    return View(userDTO);
                }
            }
            catch (Exception ex) 
            { 
                return RedirectToAction("Error", ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Login() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string Name,string password)
        { 
            var user=_context.students.Where(u=>u.Name== Name && u.password==password).FirstOrDefault();
            if (user != null)
            {
                HttpContext.Session.SetString("Id", user.Id.ToString());
                HttpContext.Session.SetString("Role",user.Role.ToString());
                if(user.Role == Enums.Role.Admin)
                {
                    return RedirectToAction("Index", "Admin", new { area = "Admin" });
                }
                else
                {
                    return View();
                }
            }
            else
            {
                ViewData["Message"] = "Invalid login";
                return View();
            }
        }

    }
}
