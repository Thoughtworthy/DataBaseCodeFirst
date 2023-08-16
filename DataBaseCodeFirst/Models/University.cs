using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace DataBaseCodeFirst.Models
{
    [Table("University")]
    public class University
    {
        [Key]
        [Column("UniversityId", TypeName = "int", Order = 0)]
        public int Id { get; set; }

        [Required]
        [Column("Name", TypeName = "nvarchar(256)", Order = 1)]
        public string? Name { get; set; }

        [Column("Fee", TypeName = "decimal", Order = 2)]
        public decimal Fee { get; set; }


        [Required]
        [NotNull]
        public virtual int StudentId { get; set; }

        [Required]
        [ForeignKey("StudentId")]
        [NotNull]
        public virtual Student? Student { get; set; }

    }
}
