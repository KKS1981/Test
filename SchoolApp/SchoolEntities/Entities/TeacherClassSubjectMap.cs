using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;

namespace Domain.School {
    using System;
    using System.Collections.Generic;

    public class TeacherClassSubjectMap : IEntity, ITrackable {

        [Key]
        public int Id { get; set; }

        public virtual Teacher Teacher { get; set; }
        [ForeignKey("Class")]
        public int Class_Id { get; set; }
        public virtual Class Class { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
        public virtual ICollection<Activity> Activities { get; set; }
        [ForeignKey("AcademicYear")]
        public int AcademicYear_Id { get; set; }
        public virtual AcademicYear AcademicYear { get; set; }

        public DateTime? DeletedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
