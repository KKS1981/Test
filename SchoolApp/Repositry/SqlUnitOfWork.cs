using Domain.School;
using Repository;
using Repository.SqlRepositories;
using Repositry;

namespace Repository
{
    public class SqlUnitOfWork : IUnitOfWork
    {

        public SqlUnitOfWork(IRepository<StudentMaster> studentMasters,
                             IAcademicYearRepository academicYears, IRepository<AcademicTerm> academicTerms,
                             IStudentRepository students, IRepository<ClassLabel> classLabels,
                             IRepository<Class> classes,
                             IRepository<Subject> subjects, IRepository<Activity> activities,
                             IRepository<DescriptiveIndicator> descriptiveIndicators, IRepository<Exam> exams,
                             IRepository<AssessmentSchema> assessmentSchemas, IRepository<ExamResult> examResults,
                             IRepository<ActivityGrade> activityGrades,
                             IRepository<ScholasticSection> scholasticSections, IRepository<House> houses,
                             IRepository<ExamGradingSchema> examGradingSchemas,
                             IRepository<ActivityGradingSchema> activityGradingSchemas,
                             IRepository<Attendance> attendances, 
                             IRepository<SelfAwareness> selfAwarenesses,
                             IRepository<HealthInformation> healthInformations,
                             IRepository<TeacherClassSubjectMap> teacherClassSubjectMaps, IRepository<Teacher> teachers,
                             IRepository<ClassTeacher> classTeachers, IRepository<ActivityResult> activityResults,
                             IRepository<Minority> minorities, IRepository<Category> categories,
                             IRepository<StudentScore> studentScores,
                             IRepository<StudentAssignment> studentAssignments, IRepository<SmsReport> smsReports,
                             IRepository<File> files, IRepository<TeacherUpload> teacherUploads,
                             IRepository<Settings> settings, IRepository<Menu> menus, IRepository<ExamSection> examSection,
                             IRepository<ExamSectionResult> examSectionResult, IRepository<StudentAttendances> studentAttendances)
        {
            StudentMasters = studentMasters;
            AcademicYears = academicYears;
            AcademicTerms = academicTerms;
            Students = students;
            ClassLabels = classLabels;
            
            Classes = classes;
            Subjects = subjects;
            Activities = activities;
            DescriptiveIndicators = descriptiveIndicators;
            Exams = exams;
            AssessmentSchemas = assessmentSchemas;
            ExamResults = examResults;
            ActivityGrades = activityGrades;
            ScholasticSections = scholasticSections;
            Houses = houses;
            ExamGradingSchemas = examGradingSchemas;
            ActivityGradingSchemas = activityGradingSchemas;
            Attendances = attendances;
            
            SelfAwarenesses = selfAwarenesses;
            HealthInformations = healthInformations;
            TeacherClassSubjectMaps = teacherClassSubjectMaps;
            Teachers = teachers;
            ClassTeachers = classTeachers;
            ActivityResults = activityResults;
            Minorities = minorities;
            Categories = categories;
            StudentScores = studentScores;
            StudentAssignments = studentAssignments;
            SmsReports = smsReports;            
            TeacherUploads = teacherUploads;            
            Settings = settings;
            Menus = menus;
            StudentAttendances = studentAttendances;
            ExamSections = examSection;
            ExamSectionResults = examSectionResult;
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
    }
}