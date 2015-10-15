using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;

namespace Domain.School {
    public class Teacher : IEntity, ITrackable, IUser
    {

        public int Id { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }
        public virtual ICollection<Activity> Activities { get; set; }
        public virtual ICollection<TeacherClassSubjectMap> TeacherClassSubjectMaps { get; set; }
        
        

        public string UserId { get; set; }

        [MaxLength]
        public string UserName { get; set; }

        
        [MaxLength]
        public string FirstName { get; set; }
        [MaxLength]
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public bool? Gender { get; set; }
        [MaxLength]
        public string MotherName { get; set; }
        [MaxLength]
        public string FatherName { get; set; }
        [MaxLength]
        public string PhoneNo { get; set; }
        [MaxLength]
        public string MobileNo { get; set; }
        [MaxLength]
        public string EmailId { get; set; }
        [MaxLength]
        public string Nationality { get; set; }
        [MaxLength]
        public string StreetAddress { get; set; }
        [MaxLength]
        public string City { get; set; }
        [MaxLength]
        public string State { get; set; }
        [MaxLength]
        public string Country { get; set; }
        public string PinCode { get; set; }
        [MaxLength]
        public string Qualification { get; set; }
        
        [MaxLength]
        public string ImagePath { get; set; }
        public DateTime? JoiningDate { get; set; }       

        [MaxLength]
        public string EmployeeId { get; set; }

        [NotMapped]
        public string FullName
        {
            get { return string.Format("{0} {1}", FirstName, LastName); }
        }

        public virtual ICollection<ClassTeacher> ClassTeachers { get; set; }

        public virtual ICollection<SmsReport> SmsReports { get; set; }
    }
}
