namespace TawasalBackend1.Models
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public int CourseId { get; set; } // Foreign Key
        public DateTime EnrollmentDate { get; set; }
    }
}
