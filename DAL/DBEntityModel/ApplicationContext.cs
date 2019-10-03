using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DBEntityModel
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Student>()
               .HasData
               (
                new Student
                {
                    Id = 1,
                    FirstName = "jarar",
                    LastName = "tahir",
                    Email = "jarar@gmail.com",
                    EnrollmentNo = "01"

                },
                new Student
                {
                    Id = 2,
                    FirstName = "abc",
                    LastName = "def",
                    Email = "abc@gmail.com",
                    EnrollmentNo = "021"

                }
               );

            base.OnModelCreating(modelBuilder);
            new StudentMap(modelBuilder.Entity<Student>());
        }
    }
}
