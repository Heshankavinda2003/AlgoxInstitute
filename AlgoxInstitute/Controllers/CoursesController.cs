using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AlgoxInstitute.Data;
using AlgoxInstitute.Models;

namespace AlgoxInstitute.Controllers
{
	[Authorize] //must login
	public class CoursesController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly UserManager<IdentityUser> _userManager;

		public CoursesController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
		{
			_context = context;
			_userManager = userManager;
		}

		//get corses
		public async Task<IActionResult> Index()
		{
			return View(await _context.Courses.ToListAsync());
		}

		//get courses
		[Authorize(Roles = "Teacher,Admin")]
		public IActionResult Create()
		{
			return View();
		}

		//post courses
		[HttpPost]
		[Authorize(Roles = "Teacher,Admin")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(Course course, IFormFile? resourceFile)
		{
			if (ModelState.IsValid)
			{
				// File Upload Logic
				if (resourceFile != null && resourceFile.Length > 0)
				{
					var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
					if (!Directory.Exists(uploadsFolder)) Directory.CreateDirectory(uploadsFolder);

					var uniqueFileName = Guid.NewGuid().ToString() + "_" + resourceFile.FileName;
					var filePath = Path.Combine(uploadsFolder, uniqueFileName);

					using (var stream = new FileStream(filePath, FileMode.Create))
					{
						await resourceFile.CopyToAsync(stream);
					}
					course.PdfUrl = "/uploads/" + uniqueFileName;
				}

				// Set Teacher Email automatically
				course.TeacherEmail = User.Identity.Name;

				_context.Add(course);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(course);
		}

		// POST: Courses/Enroll (STUDENT ONLY)
		[HttpPost]
		[Authorize(Roles = "Student")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Enroll(int id)
		{
			var user = await _userManager.GetUserAsync(User);

			// Prevent duplicates
			bool alreadyEnrolled = await _context.Enrollments.AnyAsync(e =>
				e.CourseId == id && e.StudentEmail == user.Email);

			if (!alreadyEnrolled)
			{
				var enrollment = new Enrollment
				{
					CourseId = id,
					StudentEmail = user.Email,
					Progress = 0
				};
				_context.Add(enrollment);
				await _context.SaveChangesAsync();
			}

			return RedirectToAction("Index", "Dashboard");
		}
	}
}