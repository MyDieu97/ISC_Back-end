using ISC_System_API.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISC_System_API
{
    public class Context: DbContext
    {
        public Context(DbContextOptions<Context> options): base(options)
        {

        }
        public virtual DbSet<Academic> Academics { get; set; }
        public virtual DbSet<Class> Class { get; set; }
        public virtual DbSet<ClassRoom> ClassRooms { get; set; }
        public virtual DbSet<Company> Companys { get; set; }
        public virtual DbSet<Cours> Cours { get; set; }
        public virtual DbSet<Degree> Degrees { get; set; }
        public virtual DbSet<DetailTimetable> DetailTimetables { get; set; }
        public virtual DbSet<EntranceTest> EntranceTest { get; set; }
        public virtual DbSet<ExaminationSubject> ExaminationSubjects { get; set; }
        public virtual DbSet<LearningResult> LearningResults { get; set; }
        public virtual DbSet<Lecturer> Lectures { get; set; }
        public virtual DbSet<LecturerClasses> LecturerClasses { get; set; }
        public virtual DbSet<Major> Majors { get; set; }
        public virtual DbSet<SpecializedTraining> SpecializedTrainings { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<SubjectEntranceTest> SubjectEntranceTests { get; set; }
        public virtual DbSet<TestResult> TestResults { get; set; }
        public virtual DbSet<Timetable> Timetables { get; set; }
        public virtual DbSet<University> Universitys { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Worktrack> Worktracks { get; set; }
    }
}
