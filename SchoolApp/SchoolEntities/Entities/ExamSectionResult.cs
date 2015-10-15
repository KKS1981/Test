using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Domain.Common;



namespace Domain.School
{
    public class ExamSectionResult : IEntity, ITrackable
    {
        public int Id { get; set; }
        public int ExamSection_Id { get; set; }
        public virtual ExamSection ExamSection { get; set; }
        public decimal MarkObtained { get; set; }
        public int Student_Id { get; set; }
        public virtual Student Student { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool IsApprovedByClassTeacher { get; set; }
        public bool IsApprovedBySubjectTeacher { get; set; }
        public bool IsApprovedByPrincipal { get; set; }
    }
}
