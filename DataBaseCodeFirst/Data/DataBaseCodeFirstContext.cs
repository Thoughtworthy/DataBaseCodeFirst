using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataBaseCodeFirst.Models;

namespace DataBaseCodeFirst.Data
{
    public class DataBaseCodeFirstContext : DbContext
    {
        public DataBaseCodeFirstContext(DbContextOptions<DataBaseCodeFirstContext> options)
            : base(options)
        {
        }

        public DbSet<DataBaseCodeFirst.Models.Student> Student { get; set; } = default!;
        public DbSet<DataBaseCodeFirst.Models.Course> Course { get; set; } = default!;
        public DbSet<DataBaseCodeFirst.Models.University> University { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasIndex(s => s.Email)
                .IsUnique();
        }
    }
}
