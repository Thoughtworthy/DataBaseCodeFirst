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
        [Required]
        [Column("CourseId", TypeName = "int", Order = 0)]
        public int Id { get; set; }

        [Required]
        [Column("CourseName", TypeName = "nvarchar(256)", Order = 1)]
        [StringLength(256)]
        public string? CourseName { get; set; }

        [Required]
        [NotNull]
        public int UserId { get; set; }

        [Required]
        [ForeignKey("UserId")]
        [NotNull] 
        public virtual Student? User { get; set; }
    }
}