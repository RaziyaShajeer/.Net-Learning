using Microsoft.AspNetCore.Mvc;

namespace Areas.Areas.Blogs.Controllers
{
	public class HomeController : Controller
	{
		[HttpGet]
		[Area("Blog")]
		public IActionResult Index()
		{
			return View("~/Areas/Blogs/Views/Home/Index.cshtml");
		 }
	
	}
}
