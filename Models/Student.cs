using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LR4_Baranov.Models;

[Table("students")]
[Index("Email", Name = "email", IsUnique = true)]
public partial class Student
{
    [Key]
    [Column("student_id")]
    public int StudentId { get; set; }

    [Column("first_name")]
    [StringLength(50)]
    public string FirstName { get; set; } = null!;

    [Column("last_name")]
    [StringLength(50)]
    public string LastName { get; set; } = null!;

    [Column("email")]
    [StringLength(100)]
    public string Email { get; set; } = null!;

    [Column("enrollment_date")]
    public DateOnly EnrollmentDate { get; set; }

    [InverseProperty("Student")]
    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();
}
