using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebMvc.Areas.Seller.Controllers
{
    [Area("Seller")]
    
    [Authorize(Roles = "Seller")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
