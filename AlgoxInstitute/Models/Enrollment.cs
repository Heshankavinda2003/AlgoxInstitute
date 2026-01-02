namespace AlgoxInstitute.Models
{
	public class Enrollment
	{
		public int Id { get; set; }
		public int CourseId { get; set; }
		public string StudentEmail { get; set; } // Links to student
		public int Progress { get; set; } = 0;

		public virtual Course Course { get; set; }
	}
}