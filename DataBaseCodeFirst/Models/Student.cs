using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

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
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }

        [Required]
        [Column("StudentNumber", TypeName = "nvarchar(256)")]
        public string? StudentNumber { get; set; }

        [Required]
        [Column("Name", TypeName = "nvarchar(256)")]
        public string? Name { get; set; }

        [Required]
        [Column("Email", TypeName = "nvarchar(256)")]
        [EmailAddress]
        public string? Email { get; set; }

        [Column("DateOfBirth", TypeName = "datetime")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        // Navigation Properties
        public virtual ICollection<Course> Courses { get; set; }
        public virtual University? University { get; set; }
    }
}