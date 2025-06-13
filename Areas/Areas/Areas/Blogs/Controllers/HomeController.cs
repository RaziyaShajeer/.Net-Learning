using Areas.Models;
using Microsoft.AspNetCore.Mvc;

namespace Areas.Areas.Blogs.Controllers
{
	[Area("Blog")]
	public class HomeController : Controller
	{
	
		areacontext db=new areacontext();
		[HttpGet]
		public IActionResult Index()
		{
			return View("~/Areas/Blogs/Views/Home/Index.cshtml");
		 }
		[HttpGet]
		public IActionResult AddCategory()
		{
			return View("~/Areas/Blogs/Views/Home/AddCategory.cshtml");
		}
		[HttpPost]
		public IActionResult AddCategory(Category cat)
		{
			db.category.Add(cat);
			db.SaveChanges();
			return View("~/Areas/Blogs/Views/Home/AddCategory.cshtml");
		}

	}
}
