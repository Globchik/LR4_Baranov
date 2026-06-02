using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LR4_Baranov.Models;

[Table("grades")]
[Index("ClassId", Name = "class_id")]
[Index("StudentId", "ClassId", Name = "uq_student_class", IsUnique = true)]
public partial class Grade
{
    [Key]
    [Column("grade_id")]
    public int GradeId { get; set; }

    [Column("student_id")]
    public int StudentId { get; set; }

    [Column("class_id")]
    public int ClassId { get; set; }

    [Column("score")]
    [Precision(5, 2)]
    public decimal Score { get; set; }

    [Column("date_awarded")]
    public DateOnly? DateAwarded { get; set; }

    [ForeignKey("ClassId")]
    [InverseProperty("Grades")]
    public virtual Class Class { get; set; } = null!;

    [ForeignKey("StudentId")]
    [InverseProperty("Grades")]
    public virtual Student Student { get; set; } = null!;
}
