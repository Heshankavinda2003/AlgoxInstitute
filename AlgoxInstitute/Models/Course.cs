using System.ComponentModel.DataAnnotations;
using AlgoxInstitute.Models;

namespace AlgoxInstitute.Models
{
	public class Course
	{
		public int Id { get; set; }
		[Required] public string Title { get; set; }
		public string Description { get; set; }
		public string TeacherEmail { get; set; } // Links to the teacher who created it
		public string? PdfUrl { get; set; } // For offline learning

		public virtual ICollection<Enrollment> Enrollments { get; set; }
	}
}