using AutoMapper;
using ImageUploas.Dtos;
using ImageUploas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ImageUploas.Controllers
{
	public class StudentControlller : Controller
	{
		public readonly IMapper _mapper;
		StudentContext _studentContext;
		private readonly IWebHostEnvironment _env;
		public StudentControlller(IMapper mapper, StudentContext studentContext, IWebHostEnvironment env)
		{
			_mapper = mapper;
			_studentContext = studentContext;
			_env = env;
		}

		public IActionResult Index()
		{
			var students = _studentContext.Students.ToList(); // Or fetch with async if needed
			return View(students);
		}
		[HttpGet]
		public IActionResult AddStudent()
		{
			return View();

		}
		[HttpPost]
		public async  Task<IActionResult> AddStudent(StudentDTos student)
		{

			if (student.Image != null && student.Image.Length > 0)
			{
				// Generate unique file name
				var fileName = $"{Guid.NewGuid()}{Path.GetExtension(student.Image.FileName)}";

				// Get full path to wwwroot/images
				var imagesPath = Path.Combine(_env.WebRootPath, "images");

				// Ensure directory exists
				if (!Directory.Exists(imagesPath))
					Directory.CreateDirectory(imagesPath);

				// Combine full file path
				var filePath = Path.Combine(imagesPath, fileName);

				// Save the file
				using (var stream = new FileStream(filePath, FileMode.Create))
				{
					await student.Image.CopyToAsync(stream);
				}

				// Save relative path to DB
				var std=_mapper.Map<Student>(student);
				std.Image= $"images/{fileName}";
				_studentContext.Students.Add(std);
				await _studentContext.SaveChangesAsync();
				return RedirectToAction("Index");
			}
		return View();	

			
		}

			
		}

	}

