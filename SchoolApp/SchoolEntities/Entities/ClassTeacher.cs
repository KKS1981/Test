using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;

namespace Domain.School
{
    using System;
    using System.Collections.Generic;

    public class ClassTeacher : IEntity, ITrackable
    {
        public int Id { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }
       
        public virtual Class Class { get; set; }
        [ForeignKey("Teacher")]
        public int TeacherMaster_Id { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
