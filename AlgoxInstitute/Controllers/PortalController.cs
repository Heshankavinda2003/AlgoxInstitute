using Microsoft.AspNetCore.Mvc;

namespace AlgoxInstitute.Controllers
{
	public class PortalController : Controller
	{
		public IActionResult RedirectUser()
		{
			if (User.IsInRole("Admin"))
			{
				return RedirectToAction("Index", "Admin");
			}
			else if (User.IsInRole("Teacher"))
			{
				// You need to create CoursesController
				return RedirectToAction("Index", "Courses");
			}
			else if (User.IsInRole("Student"))
			{
				// You need to create DashboardController
				return RedirectToAction("Index", "StudentDashboard");
			}

			return RedirectToAction("Index", "Home");
		}
	}
}