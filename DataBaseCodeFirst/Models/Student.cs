using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBaseCodeFirst.Models
{
    [Table("Student")]
    public class Student
    {
        public Student()
        {
            Courses = new HashSet<Course>();
        }

        [Key]
        [Column("Id", TypeName = "int", Order = 0)]
        public int Id { get; set; }

        [Column("StudentNumber", TypeName = "nvarchar(256)", Order = 1)]
        public string? StudentNumber { get; set; }

        [Required]
        [Column("Name", TypeName = "nvarchar(256)", Order = 2)]
        public string? Name { get; set; }

        [Required]
        [Column("Email", TypeName = "nvarchar(256)", Order = 3)]
        public string? Email { get; set; }

        [Column("DateOfBirth", TypeName = "Datetime", Order = 4)]
        public DateTime? DateOfBirth { get; set; }

        // Navigation Properties
        public virtual ICollection<Course> Courses { get; set; }
        public virtual University? University { get; set; }
    }
}
