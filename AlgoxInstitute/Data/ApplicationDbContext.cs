using AlgoxInstitute.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AlgoxInstitute.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
		public DbSet<Course> Courses { get; set; }
		public DbSet<Enrollment> Enrollments { get; set; }

	}
}
