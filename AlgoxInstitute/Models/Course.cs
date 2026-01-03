using System.ComponentModel.DataAnnotations;
using AlgoxInstitute.Models;

namespace AlgoxInstitute.Models
{
	public class Course
	{
		public int Id { get; set; }
		[Required] public string Title { get; set; }
		public string Description { get; set; }
		public string TeacherEmail { get; set; } 
		public string? PdfUrl { get; set; } // 

		public virtual ICollection<Enrollment> Enrollments { get; set; }
	}
}