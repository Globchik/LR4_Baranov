using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LR4_Baranov.Models;

[Table("teachers")]
[Index("Email", Name = "email", IsUnique = true)]
public partial class Teacher
{
    [Key]
    [Column("teacher_id")]
    public int TeacherId { get; set; }

    [Column("first_name")]
    [StringLength(50)]
    public string FirstName { get; set; } = null!;

    [Column("last_name")]
    [StringLength(50)]
    public string LastName { get; set; } = null!;

    [Column("email")]
    [StringLength(100)]
    public string Email { get; set; } = null!;

    [Column("department")]
    [StringLength(100)]
    public string Department { get; set; } = null!;

    [InverseProperty("Teacher")]
    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();
}
