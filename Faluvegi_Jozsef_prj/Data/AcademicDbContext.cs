using System;
using Microsoft.EntityFrameworkCore;

public class AcademicDbContext : DbContext
{
    public AcademicDbContext(DbContextOptions<AcademicDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    
    public DbSet<Student> Students { get; set; }
    public DbSet<University> Universities { get; set; }
    public DbSet<Grade> Grades { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>()
            .HasData(GetStudents());
        modelBuilder.Entity<University>()
            .HasData(GetUniversities());
        modelBuilder.Entity<Grade>()
            .HasData(GetGrades());

        modelBuilder.Entity<Student>()
            .HasOne(s => s.University)
            .WithMany(u => u.Students);
        
        modelBuilder.Entity<Student>()
            .HasMany(s => s.Grades);

        base.OnModelCreating(modelBuilder);
    }

    private Grade[] GetGrades()
    {
        return new Grade[]
        {
            new Grade { GradeId= 1, StudentId = 1, CourseName = "course 1", FinalResult = 4.30, Passed= false},
            new Grade { GradeId= 2, StudentId = 2, CourseName = "course 1", FinalResult = 7.80, Passed= true},
            new Grade { GradeId= 3, StudentId = 3, CourseName = "course 1", FinalResult = 10.00, Passed= true},
            new Grade { GradeId= 4, StudentId = 4, CourseName = "course 1", FinalResult = 5.00, Passed= true},
        };
    }
    private Student[] GetStudents()
    {
        return new Student[]
        {
            new Student { StudentId = 1, FirstName = "Alpha", LastName = "Aa", UniversityId = 1},
            new Student { StudentId = 2, FirstName = "Bravo", LastName = "Bb", UniversityId = 1},
            new Student { StudentId = 3, FirstName = "Charlie", LastName = "Cc", UniversityId = 2},
            new Student { StudentId = 4, FirstName = "Delta", LastName = "Dd", UniversityId = 2},
        };
    }
    private University[] GetUniversities()
    {
        return new University[]
        {
            new University {UniversityId = 1, Name= "univ1 name", Specialization= "Info", Location = "Cluj" },
            new University {UniversityId = 2, Name= "univ2 name", Specialization= "Something else", Location = "Mures" }
        };
    }
}