using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LR4_Baranov.Models
{
    [Table("classes")]
    public class Class
    {
        [Key]
        [Column("class_id")]
        public int ClassId { get; set; }

        [Column("course_id")]
        public int CourseId { get; set; }

        [Column("teacher_id")]
        public int? TeacherId { get; set; }

        [Column("semester"), MaxLength(20)]
        public string Semester { get; set; } = string.Empty;

        [Column("schedule_info"), MaxLength(100)]
        public string? ScheduleInfo { get; set; }

        [ForeignKey(nameof(CourseId))]
        public Course Course { get; set; } = null!;

        [ForeignKey(nameof(TeacherId))]
        public Teacher? Teacher { get; set; }

        public ICollection<Grade> Grades { get; set; } = new List<Grade>();
    }
}
