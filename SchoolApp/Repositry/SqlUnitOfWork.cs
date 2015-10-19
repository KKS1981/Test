using Domain.School;
using Repository;
using Repository.SqlRepositories;
using Repositry;
using System.Data.Entity;

namespace Repository
{
    public class SqlUnitOfWork : IUnitOfWork
    {
        private DbContext _dbcontext;

        public SqlUnitOfWork(DbContext context)
        {
            _dbcontext = context;
            StudentMasters = new SqlRepository<StudentMaster>(context);
            AcademicYears = new AcademicYearRepository(context);
            AcademicTerms = new SqlRepository<AcademicTerm>(context);
            Students = new StudentRepository(context);
            ClassLabels = new SqlRepository<ClassLabel>(context);

            Classes = new SqlRepository<Class>(context);
            Subjects = new SqlRepository<Subject>(context);
            Activities = new SqlRepository<Activity>(context);
            DescriptiveIndicators = new SqlRepository<DescriptiveIndicator>(context);
            Exams = new SqlRepository<Exam>(context);
            AssessmentSchemas = new SqlRepository<AssessmentSchema>(context);
            ExamResults = new SqlRepository<ExamResult>(context);
            ActivityGrades = new SqlRepository<ActivityGrade>(context);
            ScholasticSections = new SqlRepository<ScholasticSection>(context);
            Houses = new SqlRepository<House>(context);
            ExamGradingSchemas = new SqlRepository<ExamGradingSchema>(context);
            ActivityGradingSchemas = new SqlRepository<ActivityGradingSchema>(context);
            Attendances = new SqlRepository<Attendance>(context);

            SelfAwarenesses = new SqlRepository<SelfAwareness>(context);
            HealthInformations = new SqlRepository<HealthInformation>(context);
            TeacherClassSubjectMaps = new SqlRepository<TeacherClassSubjectMap>(context);
            Teachers = new SqlRepository<Teacher>(context);
            ClassTeachers = new SqlRepository<ClassTeacher>(context);
            ActivityResults = new SqlRepository<ActivityResult>(context);
            Minorities = new SqlRepository<Minority>(context);
            Categories = new SqlRepository<Category>(context);
            StudentScores = new SqlRepository<StudentScore>(context);
            StudentAssignments = new SqlRepository<StudentAssignment>(context);
            SmsReports = new SqlRepository<SmsReport>(context);
            TeacherUploads = new SqlRepository<TeacherUpload>(context);
            Settings = new SqlRepository<Settings>(context);
            Menus = new SqlRepository<Menu>(context);
            StudentAttendances = new SqlRepository<StudentAttendances>(context);
            ExamSections = new SqlRepository<ExamSection>(context);
            ExamSectionResults = new SqlRepository<ExamSectionResult>(context);

        }


        #region IUnitOfWork Members



        public IRepository<StudentMaster> StudentMasters { get; private set; }

        public IAcademicYearRepository AcademicYears { get; private set; }

        public IRepository<AcademicTerm> AcademicTerms { get; private set; }

        public IStudentRepository Students { get; private set; }

        public IRepository<ClassLabel> ClassLabels { get; private set; }

       

        public IRepository<Class> Classes { get; private set; }

        public IRepository<Subject> Subjects { get; private set; }

        public IRepository<Activity> Activities { get; private set; }

        public IRepository<DescriptiveIndicator> DescriptiveIndicators { get; private set; }

        public IRepository<Exam> Exams { get; private set; }

        public IRepository<AssessmentSchema> AssessmentSchemas { get; private set; }

        public IRepository<ExamResult> ExamResults { get; private set; }

        public IRepository<ActivityGrade> ActivityGrades { get; private set; }

        public IRepository<ScholasticSection> ScholasticSections { get; private set; }

        public IRepository<House> Houses { get; private set; }

        public IRepository<ExamGradingSchema> ExamGradingSchemas { get; private set; }

        public IRepository<ActivityGradingSchema> ActivityGradingSchemas { get; private set; }

        public IRepository<Attendance> Attendances { get; private set; }

       

        public IRepository<SelfAwareness> SelfAwarenesses { get; private set; }

        public IRepository<HealthInformation> HealthInformations { get; private set; }

        public IRepository<TeacherClassSubjectMap> TeacherClassSubjectMaps { get; private set; }

        public IRepository<Teacher> Teachers { get; private set; }

        public IRepository<ClassTeacher> ClassTeachers { get; private set; }

        public IRepository<ActivityResult> ActivityResults { get; private set; }

        public IRepository<Minority> Minorities { get; private set; }

        public IRepository<Category> Categories { get; private set; }

        public IRepository<StudentScore> StudentScores { get; private set; }

        public IRepository<StudentAssignment> StudentAssignments { get; private set; }

        public IRepository<SmsReport> SmsReports { get; private set; }

        public IRepository<File> Files { get; private set; }

        public IRepository<TeacherUpload> TeacherUploads { get; private set; }
             
        public IRepository<Settings> Settings { get; private set; }

        public IRepository<Menu> Menus { get; private set; }

        public IRepository<StudentAttendances> StudentAttendances { get; private set; }

        public IRepository<ExamSection> ExamSections { get; private set; }
        public IRepository<ExamSectionResult> ExamSectionResults { get; private set; }



        #endregion


        public void SaveChanges()
        {
            _dbcontext.SaveChanges();
        }
    }
}