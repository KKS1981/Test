using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;

namespace Domain.School {

    public class Subject : IEntity, ITrackable {

        public int Id { get; set; }
        [MaxLength]
        public string Name { get; set; }
        [MaxLength]
        public string ShortName { get; set; }
        public decimal? Weightage { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int? DisplayOrder { get; set; }
        
        [MaxLength]
        public string CBSECode { get; set; }
        [MaxLength]
        public string CBSEName { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
        public virtual ScholasticSection ScholasticSection { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
        public virtual ICollection<Exam> Exams { get; set; }
        public virtual ICollection<TeacherClassSubjectMap> TeacherClassSubjectMaps { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Student> StudentsIgnoringSubject { get; set; }
        public virtual ICollection<Subject> ChildSubjects { get; set; }
        public virtual Subject Parent { get; set; }
        public virtual ICollection<StudentAssignment> StudentAssignments { get; set; }

        [NotMapped]
        public bool HasChildSubjects {
            get { return this.ChildSubjects.Count > 0; }
        }
    }
}
