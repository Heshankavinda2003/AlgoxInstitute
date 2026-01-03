using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlgoxInstitute.Controllers
{
	[Authorize]
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
				return RedirectToAction("Index", "Courses");
			}
			else if (User.IsInRole("Student"))
			{
				return RedirectToAction("Index", "Dashboard");
			}
			return RedirectToAction("Index", "Home");
		}
	}
}