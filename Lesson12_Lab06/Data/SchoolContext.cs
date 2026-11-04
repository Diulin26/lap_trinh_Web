using Microsoft.EntityFrameworkCore;
using MyWebApp.Models;

namespace MyWebApp.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options) { }

        public DbSet<Major> Majors { get; set; }
        public DbSet<Learner> Learners { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Major>().HasData(
                new Major { MajorID = 1, MajorName = "IT" },
                new Major { MajorID = 2, MajorName = "Economics" },
                new Major { MajorID = 3, MajorName = "Mathematics" });

            modelBuilder.Entity<Learner>().HasData(
                new Learner { LearnerID = 1, FirstMidName = "Carson", LastName = "Alexander", MajorID = 1, EnrollmentDate = new DateTime(2005, 9, 1) },
                new Learner { LearnerID = 2, FirstMidName = "Meredith", LastName = "Alonso", MajorID = 2, EnrollmentDate = new DateTime(2002, 9, 1) },
                new Learner { LearnerID = 3, FirstMidName = "Arturo", LastName = "Anand", MajorID = 3, EnrollmentDate = new DateTime(2003, 9, 1) },
                new Learner { LearnerID = 4, FirstMidName = "Gytis", LastName = "Barzdukas", MajorID = 1, EnrollmentDate = new DateTime(2002, 9, 1) },
                new Learner { LearnerID = 5, FirstMidName = "Nam", LastName = "Lê", MajorID = 3, EnrollmentDate = new DateTime(2023, 10, 4, 1, 59, 0) },
                new Learner { LearnerID = 6, FirstMidName = "Yan", LastName = "Li", MajorID = 2, EnrollmentDate = new DateTime(2002, 9, 1) },
                new Learner { LearnerID = 7, FirstMidName = "Minh", LastName = "Trần", MajorID = 2, EnrollmentDate = new DateTime(2023, 10, 4, 14, 47, 0) },
                new Learner { LearnerID = 8, FirstMidName = "Peggy", LastName = "Justice", MajorID = 1, EnrollmentDate = new DateTime(2001, 9, 1) },
                new Learner { LearnerID = 9, FirstMidName = "Tuấn Nam", LastName = "Trần", MajorID = 1, EnrollmentDate = new DateTime(2023, 10, 5, 14, 46, 0) },
                new Learner { LearnerID = 10, FirstMidName = "Laura", LastName = "Norman", MajorID = 3, EnrollmentDate = new DateTime(2003, 9, 1) },
                new Learner { LearnerID = 11, FirstMidName = "Hùng", LastName = "Phạm", MajorID = 1, EnrollmentDate = new DateTime(2023, 10, 10, 8, 30, 0) },
                new Learner { LearnerID = 12, FirstMidName = "Lan", LastName = "Nguyễn", MajorID = 3, EnrollmentDate = new DateTime(2023, 10, 12, 9, 15, 0) },
                new Learner { LearnerID = 13, FirstMidName = "Bích", LastName = "Vũ", MajorID = 2, EnrollmentDate = new DateTime(2023, 10, 23, 17, 9, 0) });
        }
    }
}
