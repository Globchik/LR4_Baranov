using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LR4_Baranov.Models
{
    [Table("courses")]
    public class Course
    {
        [Key]
        [Column("course_id")]
        public int CourseId { get; set; }

        [Column("course_name"), MaxLength(150)]
        public string CourseName { get; set; } = string.Empty;

        [Column("credits")]
        public int Credits { get; set; }

        public ICollection<Class> Classes { get; set; } = new List<Class>();
    }
}
