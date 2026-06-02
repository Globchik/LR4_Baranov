using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LR4_Baranov.Models
{
    [Table("teachers")]
    public class Teacher
    {
        [Key]
        [Column("teacher_id")]
        public int TeacherId { get; set; }

        [Column("first_name"), MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Column("last_name"), MaxLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Column("email"), MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        [Column("department"), MaxLength(100)]
        public string Department { get; set; } = string.Empty;

        public ICollection<Class> Classes { get; set; } = new List<Class>();
    }
}
