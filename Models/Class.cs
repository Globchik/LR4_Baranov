using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LR4_Baranov.Models;

[Table("classes")]
[Index("CourseId", Name = "course_id")]
[Index("TeacherId", Name = "teacher_id")]
public partial class Class
{
    [Key]
    [Column("class_id")]
    public int ClassId { get; set; }

    [Column("course_id")]
    public int CourseId { get; set; }

    [Column("teacher_id")]
    public int? TeacherId { get; set; }

    [Column("semester")]
    [StringLength(20)]
    public string Semester { get; set; } = null!;

    [Column("schedule_info")]
    [StringLength(100)]
    public string? ScheduleInfo { get; set; }

    [ForeignKey("CourseId")]
    [InverseProperty("Classes")]
    public virtual Course Course { get; set; } = null!;

    [InverseProperty("Class")]
    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();

    [ForeignKey("TeacherId")]
    [InverseProperty("Classes")]
    public virtual Teacher? Teacher { get; set; }
}
