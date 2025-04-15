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

		public StudentControlller(IMapper mapper, StudentContext studentContext)
		{
			_mapper = mapper;
			_studentContext = studentContext;
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
				var filePath = Path.Combine("wwwroot/images", student.Image.FileName);
				using (var stream = new FileStream(filePath, FileMode.Create))
				{
					await student.Image.CopyToAsync(stream);
				}
				var st = _mapper.Map<Student>(student);
				st.Image = filePath;
				_studentContext.Students.AddAsync(st);
				_studentContext.SaveChanges();

			}


			return View(student);	
		}

	}
}
