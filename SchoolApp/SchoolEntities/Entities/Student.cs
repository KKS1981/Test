using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;

namespace Domain.School {

    public class Student : IEntity, ITrackable {
        public Student() {
            ExamResults = new HashSet<ExamResult>();
            ActivityGrades = new HashSet<ActivityGrade>();
            Subjects = new HashSet<Subject>();
            Activities = new HashSet<Activity>();
            ActivityResults = new HashSet<ActivityResult>();
            StudentScores = new HashSet<StudentScore>();
            StudentAssignments = new HashSet<StudentAssignment>();
            SmsReports = new HashSet<SmsReport>();
            IgnoreSubjects = new HashSet<Subject>();
            IgnoreActivities = new HashSet<Activity>();

        }

        public int Id { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        [MaxLength]
        public string BoardRegistrationNo { get; set; }

        public string RollNo { get; set; }
        [MaxLength]
        public string CBSERollNo { get; set; }


        public bool IsPromoted { get; set; }

        [ForeignKey("StudentMaster")]
        public int StudentMaster_Id { get; set; }
        public virtual StudentMaster StudentMaster { get; set; }

        [ForeignKey("AcademicYear")]
        public int AcademicYear_Id { get; set; }
        public virtual AcademicYear AcademicYear { get; set; }
        [ForeignKey("Class")]
        public int Class_Id { get; set; }

        [ForeignKey("House")]
        public int? House_Id { get; set; }
        public virtual Class Class { get; set; }
        public virtual ICollection<ExamResult> ExamResults { get; set; }
        public virtual House House { get; set; }
        public virtual Attendance Attendance { get; set; }
        public virtual ICollection<ActivityGrade> ActivityGrades { get; set; }
        public virtual SelfAwareness SelfAwarenesses { get; set; }
        public virtual HealthInformation HealthInformations { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
        public virtual ICollection<Activity> Activities { get; set; }
        public virtual ICollection<ActivityResult> ActivityResults { get; set; }
        public virtual ICollection<StudentScore> StudentScores { get; set; }
        public virtual ICollection<StudentAssignment> StudentAssignments { get; set; }
        public virtual ICollection<SmsReport> SmsReports { get; set; }
        public virtual ICollection<Subject> IgnoreSubjects { get; set; }
        public virtual ICollection<Activity> IgnoreActivities { get; set; }
        public virtual ICollection<StudentAttendances> StudentAttendances { get; set; }
        public virtual ICollection<ExamSectionResult> ExamSectionResults { get; set; }  
    }
}
