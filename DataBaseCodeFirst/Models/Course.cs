using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DataBaseCodeFirst.Models
{
    [Table("Course")]
    public class Course
    {
        [Key]
        [Column("CourseId", TypeName = "int")]
        public int Id { get; set; }

        [Required]
        [Column("CourseName", TypeName = "nvarchar(256)")]
        [StringLength(256)]
        public string? CourseName { get; set; }

        [ForeignKey("UserId")]
        [NotNull]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual Student? User { get; set; }
    }
}