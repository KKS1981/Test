using AccountService;
using Domain.School;
using Repository;
using Repository.SqlRepositories;
using Repositry;
using SchoolEntities;
using SchoolService.WCFServices;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolService.Dependencies
{
    public static class DependencyLoader
    {
        public static void LoadDependency(Container container)
        {
            container.Register<IAccountService, AspIdentityAccountService>();

            container.Register<IUnitOfWork, SqlUnitOfWork>();
            container.Register<DbContext>(() => new SchoolDb("Schooldb"));

            container.Register<IRepository<StudentMaster>, SqlRepository<StudentMaster>>();
            container.Register<IRepository<AcademicTerm>, SqlRepository<AcademicTerm>>();
            container.Register<IRepository<ClassLabel>, SqlRepository<ClassLabel>>();
            
            container.Register<IRepository<Class>, SqlRepository<Class>>();
            container.Register<IRepository<Subject>, SqlRepository<Subject>>();
            container.Register<IRepository<Activity>, SqlRepository<Activity>>();
            container.Register<IRepository<DescriptiveIndicator>, SqlRepository<DescriptiveIndicator>>();
            container.Register<IRepository<Exam>, SqlRepository<Exam>>();
            container.Register<IRepository<AssessmentSchema>, SqlRepository<AssessmentSchema>>();
            container.Register<IRepository<ExamResult>, SqlRepository<ExamResult>>();
            container.Register<IRepository<ActivityGrade>, SqlRepository<ActivityGrade>>();
            container.Register<IRepository<ScholasticSection>, SqlRepository<ScholasticSection>>();
            container.Register<IRepository<House>, SqlRepository<House>>();
            container.Register<IRepository<ExamGradingSchema>, SqlRepository<ExamGradingSchema>>();
            container.Register<IRepository<ActivityGradingSchema>, SqlRepository<ActivityGradingSchema>>();
            container.Register<IRepository<Attendance>, SqlRepository<Attendance>>();
            
            container.Register<IRepository<SelfAwareness>, SqlRepository<SelfAwareness>>();
            container.Register<IRepository<HealthInformation>, SqlRepository<HealthInformation>>();
            container.Register<IRepository<TeacherClassSubjectMap>, SqlRepository<TeacherClassSubjectMap>>();
            container.Register<IRepository<Teacher>, SqlRepository<Teacher>>();
            container.Register<IRepository<ClassTeacher>, SqlRepository<ClassTeacher>>();
            container.Register<IRepository<ActivityResult>, SqlRepository<ActivityResult>>();
            container.Register<IRepository<Minority>, SqlRepository<Minority>>();
            container.Register<IRepository<Category>, SqlRepository<Category>>();
            container.Register<IRepository<StudentScore>, SqlRepository<StudentScore>>();
            container.Register<IRepository<StudentAssignment>, SqlRepository<StudentAssignment>>();
            container.Register<IRepository<SmsReport>, SqlRepository<SmsReport>>();
            container.Register<IRepository<File>, SqlRepository<File>>();
            
            container.Register<IRepository<TeacherUpload>, SqlRepository<TeacherUpload>>();
           
            container.Register<IRepository<Settings>, SqlRepository<Settings>>();
            container.Register<IRepository<Menu>, SqlRepository<Menu>>();
            container.Register<IRepository<StudentAttendances>, SqlRepository<StudentAttendances>>();
            container.Register<IAcademicYearRepository, AcademicYearRepository>();
            container.Register<IRepository<ExamSection>, SqlRepository<ExamSection>>();
            container.Register<IRepository<ExamSectionResult>, SqlRepository<ExamSectionResult>>();
           
            container.Register<IStudentRepository, StudentRepository>();
        }
    }
}
