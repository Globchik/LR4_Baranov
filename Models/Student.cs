using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LR4_Baranov.Models
{
    [Table("students")]
    public class Student
    {
        [Key]
        [Column("student_id")]
        public int StudentId { get; set; }

        [Column("first_name"), MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Column("last_name"), MaxLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Column("email"), MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        [Column("enrollment_date")]
        public DateTime EnrollmentDate { get; set; }
        public ICollection<Grade> Grades { get; set; } = new List<Grade>();
    }
}
