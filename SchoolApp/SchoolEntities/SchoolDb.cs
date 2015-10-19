using Domain.Common;
using Domain.School;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolEntities
{
    public class SchoolDb : DbContext
    {

        public SchoolDb() { }

        public SchoolDb(string connectionString)
            : base(connectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<IncludeMetadataConvention>();
            Database.SetInitializer<SchoolDb>(null);

            modelBuilder.Entity<Class>().HasOptional(x => x.ClassTeacher).WithRequired(x => x.Class).Map(m =>
            {
                m.MapKey("Class_Id");
            });

            modelBuilder.Entity<Student>().HasOptional(x => x.Attendance).WithOptionalPrincipal(x => x.Student).Map(m =>
            {
                m.MapKey("Student_Id");
            });

            modelBuilder.Entity<Student>().HasOptional(x => x.HealthInformations).WithRequired(x => x.Student).Map(m =>
            {
                m.MapKey("Student_Id");
            });

            modelBuilder.Entity<Student>().HasOptional(x => x.SelfAwarenesses).WithRequired(x => x.Student).Map(m =>
            {
                m.MapKey("Student_Id");
            });

            modelBuilder.Entity<AcademicTerm>().HasRequired(x => x.AcademicYear).WithMany(x => x.AcademicTerms).
                HasForeignKey(x => x.AcademicYear_Id);
            modelBuilder.Entity<ActivityResult>().HasRequired(x => x.Activity).WithMany(x => x.ActivityResults).
                HasForeignKey(x => x.Activity_Id).WillCascadeOnDelete(false);
            modelBuilder.Entity<ActivityResult>().HasRequired(x => x.DescriptiveIndicator).WithMany(x => x.ActivityResults).
                HasForeignKey(x => x.DescriptiveIndicator_Id).WillCascadeOnDelete(false);
            modelBuilder.Entity<ActivityResult>().HasRequired(x => x.Student).WithMany(x => x.ActivityResults).
                HasForeignKey(x => x.Student_Id).WillCascadeOnDelete(false);
            modelBuilder.Entity<AssessmentSchema>().HasRequired(x => x.AcademicTerm).WithMany(x => x.AssesmentSchemas).HasForeignKey(x => x.AcademicTerm_Id);
            modelBuilder.Entity<ClassLabel>().HasMany(x => x.AssessmentSchemas).WithMany(x => x.ClassLabels).Map(x =>
            {
                x.MapLeftKey("ClassLabels_Id");
                x.MapRightKey("AssessmentSchemas_Id");

            });
            modelBuilder.Entity<Class>().HasRequired(x => x.ClassLabel).WithMany(x => x.Classes).HasForeignKey(
                x => x.ClassLabel_Id);
           
            modelBuilder.Entity<ClassTeacher>().HasRequired(x => x.Teacher).WithMany(x => x.ClassTeachers).
                HasForeignKey(x => x.TeacherMaster_Id);
            modelBuilder.Entity<ExamResult>().HasRequired(x => x.Student).WithMany(x => x.ExamResults).HasForeignKey(
                x => x.Student_Id).WillCascadeOnDelete(false);
            modelBuilder.Entity<ExamResult>().HasRequired(x => x.Exam).WithMany(x => x.ExamResults).HasForeignKey(
                x => x.Exam_Id).WillCascadeOnDelete(false);
            modelBuilder.Entity<Exam>().HasRequired(x => x.Subject).WithMany(x => x.Exams).HasForeignKey(
                x => x.Subject_Id);
            modelBuilder.Entity<Exam>().HasRequired(x => x.AssesmentSchema).WithMany(x => x.Exams).HasForeignKey(
                x => x.AssesmentSchema_Id);
            modelBuilder.Entity<Student>().HasRequired(x => x.StudentMaster).WithMany(x => x.Students).HasForeignKey(
                x => x.StudentMaster_Id);
            modelBuilder.Entity<Student>().HasRequired(x => x.AcademicYear).WithMany(x => x.Students).HasForeignKey(
                x => x.AcademicYear_Id);
            modelBuilder.Entity<Student>().HasRequired(x => x.Class).WithMany(x => x.Students).HasForeignKey(
                x => x.Class_Id);
            modelBuilder.Entity<Student>().HasOptional(x => x.House).WithMany(x => x.Students);
            modelBuilder.Entity<TeacherClassSubjectMap>().HasRequired(x => x.Class).WithMany(
                x => x.TeacherClassSubjectMaps).HasForeignKey(x => x.Class_Id);
            modelBuilder.Entity<TeacherClassSubjectMap>().HasRequired(x => x.AcademicYear).WithMany(
                x => x.TeacherClassSubjectMaps).HasForeignKey(x => x.AcademicYear_Id);
            modelBuilder.Entity<ExamSection>().HasRequired(x => x.Exam).WithMany(x => x.ExamSections).HasForeignKey(
                x => x.Exam_Id);
            modelBuilder.Entity<ExamSectionResult>().HasRequired(x => x.ExamSection).WithMany(x => x.ExamSectionResults)
                .HasForeignKey(x => x.ExamSection_Id).WillCascadeOnDelete(false);
            modelBuilder.Entity<ExamSectionResult>().HasRequired(x => x.Student).WithMany(x => x.ExamSectionResults).
                HasForeignKey(x => x.Student_Id).WillCascadeOnDelete(false);
            modelBuilder.Entity<File>().HasOptional(x => x.StudentAssignment).WithOptionalPrincipal(x => x.File);
            modelBuilder.Entity<ExamSectionResult>().Ignore(x => x.IsApprovedByClassTeacher);
            modelBuilder.Entity<ExamSectionResult>().Ignore(x => x.IsApprovedByPrincipal);
            modelBuilder.Entity<ExamSectionResult>().Ignore(x => x.IsApprovedBySubjectTeacher);
           
            modelBuilder.Entity<Class>().HasMany(a => a.Exams).WithMany(b => b.Classes).Map(m =>
            {
                m.MapLeftKey("Classes_Id");
                m.MapRightKey("Exams_Id");
                m.ToTable("ExamClass");
            });
            modelBuilder.Entity<Activity>().HasMany(a => a.DescriptiveIndicators).WithMany(b => b.Activities).Map(m =>
            {
                m.MapLeftKey("Activities_Id");
                m.MapRightKey("DescriptiveIndicators_Id");
                m.ToTable("ActivityDescriptiveIndicator");
            });

            modelBuilder.Entity<Activity>().HasMany(a => a.TeacherClassSubjectMaps).WithMany(b => b.Activities).Map(m =>
            {
                m.MapLeftKey("Activities_Id");
                m.MapRightKey("TeacherClassSubjectMaps_Id");
                m.ToTable("ActivityTeacherClassSubjectMap");

            });
            modelBuilder.Entity<SmsReport>().HasOptional(a => a.Student).WithMany(b => b.SmsReports).Map(m => m.MapKey
                                                                                                                   ("Student_Id"));

            modelBuilder.Entity<SmsReport>().HasOptional(a => a.Teacher).WithMany(b => b.SmsReports).Map(m => m.MapKey("TeacherMaster_ID"));

            modelBuilder.Entity<Subject>().HasMany(a => a.TeacherClassSubjectMaps).WithMany(b => b.Subjects).Map(m =>
            {
                m.MapLeftKey("Subjects_Id");
                m.MapRightKey("TeacherClassSubjectMaps_Id");
                m.ToTable("SubjectTeacherClassSubjectMap");

            });

            modelBuilder.Entity<Student>().HasMany(a => a.Subjects).WithMany(b => b.Students).Map(m =>
            {
                m.MapLeftKey("Students_Id");
                m.MapRightKey("OptionalSubjects_Id");
                m.ToTable("StudentSubject");
            });

            modelBuilder.Entity<Student>().HasMany(a => a.IgnoreSubjects).WithMany(b => b.StudentsIgnoringSubject).Map(m =>
            {
                m.MapLeftKey("StudentId");
                m.MapRightKey("SubjectId");
                m.ToTable("Student_Ignored_Subjects");
            });

            modelBuilder.Entity<Class>().HasMany(a => a.Subjects).WithMany(b => b.Classes).Map(m =>
            {
                m.MapLeftKey("Classes_Id");
                m.MapRightKey("Subjects_Id");
                m.ToTable("ClassSubject");
            });

            modelBuilder.Entity<Class>().HasMany(a => a.Activities).WithMany(b => b.Classes).Map(m =>
            {
                m.MapLeftKey("Classes_Id");
                m.MapRightKey("Activities_Id");
                m.ToTable("ClassActivity");
            });

            modelBuilder.Entity<Student>().HasMany(a => a.Activities).WithMany(b => b.Students).Map(m =>
            {
                m.MapLeftKey("Students_Id");
                m.MapRightKey("OptionalActivities_Id");
                m.ToTable("StudentActivity");
            });

            modelBuilder.Entity<Student>().HasMany(a => a.IgnoreActivities).WithMany(b => b.StudentsIgnoringActivity).Map(m =>
            {
                m.MapLeftKey("StudentId");
                m.MapRightKey("ActivityId");
                m.ToTable("Student_Ignored_Activities");
            });

            modelBuilder.Entity<Teacher>().HasMany(a => a.Activities).WithMany(b => b.Teachers).Map(m =>
            {
                m.MapLeftKey("Teachers_Id");
                m.MapRightKey("Activities_Id");
                m.ToTable("TeacherActivity");
            });

            modelBuilder.Entity<Teacher>().HasMany(a => a.Subjects).WithMany(b => b.Teachers).Map(m =>
            {
                m.MapLeftKey("Teachers_Id");
                m.MapRightKey("Subjects_Id");
                m.ToTable("TeacherSubjects");
            }
        );

            //modelBuilder.Entity<Settings>().HasKey(a => new { a.Key, a.Id }).Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            
            base.OnModelCreating(modelBuilder);
        }

        
        public DbSet<StudentMaster> StudentMasters { get; set; }
        public DbSet<AcademicYear> AcademicYears { get; set; }
        public DbSet<AcademicTerm> AcademicTerms { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<ClassLabel> ClassLabels { get; set; }
        
        public DbSet<Class> Classes { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<DescriptiveIndicator> DescriptiveIndicators { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<AssessmentSchema> AssessmentSchemas { get; set; }
        public DbSet<ExamResult> ExamResults { get; set; }
        public DbSet<ActivityGrade> ActivityGrades { get; set; }
        public DbSet<ScholasticSection> ScholasticSections { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<ExamGradingSchema> ExamGradingSchemas { get; set; }
        public DbSet<ActivityGradingSchema> ActivityGradingSchemas { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        
        public DbSet<SelfAwareness> SelfAwarenesses { get; set; }
        public DbSet<HealthInformation> HealthInformations { get; set; }
        public DbSet<TeacherClassSubjectMap> TeacherClassSubjectMaps { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<ClassTeacher> ClassTeachers { get; set; }
        public DbSet<ActivityResult> ActivityResults { get; set; }
        public DbSet<Minority> Minorities { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<StudentScore> StudentScores { get; set; }
        public DbSet<StudentAssignment> StudentAssignments { get; set; }
        public DbSet<SmsReport> SmsReports { get; set; }
        public DbSet<File> Files { get; set; }
       
        public DbSet<TeacherUpload> TeacherUploads { get; set; }
       
       
        public DbSet<Settings> Settings { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<StudentAttendances> StudentAttendances { get; set; }
        public AcademicYear CurrentYear
        {
            get { return AcademicYears.Single(x => x.IsCurrent); }
        }

        public IQueryable<Subject> AllSubjects
        {
            get
            {
                return Subjects;
            }
        }
        public IQueryable<Student> FilteredStudents
        {
            get { return Students.Where(x => x.DeletedDate == (DateTime?)null); }
        }

        public override int SaveChanges()
        {
            foreach (var entity in ChangeTracker.Entries().Where(x => x.State == EntityState.Added || x.State == EntityState.Deleted || x.State == EntityState.Modified))
            {
                if (entity.State == EntityState.Added && entity.Entity is ITrackable)
                {
                    ((ITrackable)entity.Entity).CreatedDate = DateTime.UtcNow;
                }
                else if (entity.State == EntityState.Modified && entity.Entity is ITrackable)
                {
                    ((ITrackable)entity.Entity).ModifiedDate = DateTime.UtcNow;
                }
                else if (entity.State == EntityState.Deleted && entity.Entity is ITrackable)
                {
                    ((ITrackable)entity.Entity).DeletedDate = DateTime.UtcNow;
                }
            }
            return base.SaveChanges();
        }
    }
}
