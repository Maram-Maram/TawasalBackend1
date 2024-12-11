//using System.ComponentModel.DataAnnotations.Schema;

//namespace TawasalBackend1.Models

//{
//    public class Course
//    {
//        public int CourseId { get; set; }
//        public string Title { get; set; }
//        public string Description { get; set; }
//        public int Duration { get; set; }
//        public decimal Price { get; set; }
//        public int TeacherId { get; set; } // Foreign Key
//        [NotMapped]
//        public string Link { get; set; } // Course Link (not stored in the database)

//    }
//}
//*********************

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//namespace TawasalBackend1.Models
//{
//    public class Course
//    {
//        public int CourseId { get; set; } // Primary Key

//        [Required]
//        [StringLength(200)]
//        public string Title { get; set; } // Course Title

//        public string Description { get; set; } // Course Description
//        public int Duration { get; set; } // Duration in hours
//        public decimal Price { get; set; } // Course Price
//        public int TeacherId { get; set; } // Foreign Key to Teacher

//        [NotMapped]
//        public string Link { get; set; } // Course Link (not stored in the database)
//    }
//}
//+++++++++++++++++++++++++

using System.ComponentModel.DataAnnotations;

namespace TawasalBackend1.Models
{
    public class Course
    {
        public int CourseId { get; set; }  // Primary Key

        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty; // Non-nullable default value

        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

        [Range(0, int.MaxValue)]
        public int Duration { get; set; } // Duration in hours

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; } // Course price

        public int TeacherId { get; set; } // Foreign Key to Teacher

        [NotMapped]
        public string Link { get; set; } = string.Empty; // Non-persistent property for URL
    }
}
