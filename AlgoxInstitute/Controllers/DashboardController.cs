using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AlgoxInstitute.Data;
using AlgoxInstitute.Models;

namespace AlgoxInstitute.Controllers
{
	[Authorize(Roles = "Student")] // Strictly for Students
	public class DashboardController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly UserManager<IdentityUser> _userManager;

		public DashboardController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
		{
			_context = context;
			_userManager = userManager;
		}

		// GET: Dashboard (My Courses)
		public async Task<IActionResult> Index()
		{
			var user = await _userManager.GetUserAsync(User);

			var myEnrollments = await _context.Enrollments
				.Include(e => e.Course) // Load course details too
				.Where(e => e.StudentEmail == user.Email)
				.ToListAsync();

			return View(myEnrollments);
		}

		// POST: Mark Progress
		[HttpPost]
		public async Task<IActionResult> MarkProgress(int id)
		{
			var enrollment = await _context.Enrollments.FindAsync(id);
			if (enrollment != null)
			{
				enrollment.Progress += 25;
				if (enrollment.Progress > 100) enrollment.Progress = 100;
				await _context.SaveChangesAsync();
			}
			return RedirectToAction(nameof(Index));
		}
	}
}