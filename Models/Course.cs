using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LR4_Baranov.Models;

[Table("courses")]
public partial class Course
{
    [Key]
    [Column("course_id")]
    public int CourseId { get; set; }

    [Column("course_name")]
    [StringLength(150)]
    public string CourseName { get; set; } = null!;

    [Column("credits")]
    public int Credits { get; set; }

    [InverseProperty("Course")]
    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();
}
