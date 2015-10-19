using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.School;
using Repositry;
using Repository.SqlRepositories;


namespace Repository {
    public interface IUnitOfWork {

        IRepository<StudentMaster> StudentMasters { get; }
        IAcademicYearRepository AcademicYears { get; }
        IRepository<AcademicTerm> AcademicTerms { get; }
        IStudentRepository Students { get; }
        IRepository<ClassLabel> ClassLabels { get; }
        
        IRepository<Class> Classes { get; }
        IRepository<Subject> Subjects { get; }
        IRepository<Activity> Activities { get; }
        IRepository<DescriptiveIndicator> DescriptiveIndicators { get; }
        IRepository<Exam> Exams { get; }
        IRepository<AssessmentSchema> AssessmentSchemas { get; }
        IRepository<ExamResult> ExamResults { get; }
        IRepository<ActivityGrade> ActivityGrades { get; }
        IRepository<ScholasticSection> ScholasticSections { get; }
        IRepository<House> Houses { get; }
        IRepository<ExamGradingSchema> ExamGradingSchemas { get; }
        IRepository<ActivityGradingSchema> ActivityGradingSchemas { get; }
        IRepository<Attendance> Attendances { get; }
        
        IRepository<SelfAwareness> SelfAwarenesses { get; }
        IRepository<HealthInformation> HealthInformations { get; }
        IRepository<TeacherClassSubjectMap> TeacherClassSubjectMaps { get; }
        IRepository<Teacher> Teachers { get; }
        IRepository<ClassTeacher> ClassTeachers { get; }
        IRepository<ActivityResult> ActivityResults { get; }
        IRepository<Minority> Minorities { get; }
        IRepository<Category> Categories { get; }
        IRepository<StudentScore> StudentScores { get; }
        IRepository<StudentAssignment> StudentAssignments { get; }
        IRepository<SmsReport> SmsReports { get; }
        IRepository<File> Files { get; }       
        IRepository<TeacherUpload> TeacherUploads { get; }
        
        IRepository<Settings> Settings { get; }
        IRepository<Menu> Menus { get; }
        IRepository<StudentAttendances> StudentAttendances { get; }
        IRepository<ExamSection> ExamSections { get; }
        IRepository<ExamSectionResult> ExamSectionResults { get; }
    }
}
