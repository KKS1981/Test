using Domain.Common;
using Domain.School;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.School
{
    public class ExamSection : IEntity, ITrackable
    {
        public int Id { get; set; }
        public int Exam_Id { get; set; }
        public virtual Exam Exam { get; set; }
        [Required]
        public string ExamSectionName { get; set; }
        public decimal MaxMarks { get; set; }
        public virtual ICollection<ExamSectionResult> ExamSectionResults { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
