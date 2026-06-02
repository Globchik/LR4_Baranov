using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LR4_Baranov.Models
{
    [Table("grades")]
    public class Grade
    {
        [Key]
        [Column("grade_id")]
        public int GradeId { get; set; }

        [Column("student_id")]
        public int StudentId { get; set; }

        [Column("class_id")]
        public int ClassId { get; set; }

        [Column("score", TypeName = "decimal(5,2)")]
        public decimal Score { get; set; }

        [Column("date_awarded")]
        public DateTime DateAwarded { get; set; }

        [ForeignKey(nameof(StudentId))]
        public Student Student { get; set; } = null!;

        [ForeignKey(nameof(ClassId))]
        public Class Class { get; set; } = null!;
    }
}
