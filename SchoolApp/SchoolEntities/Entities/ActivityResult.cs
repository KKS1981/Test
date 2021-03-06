//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;

namespace Domain.School {
    using System;
    using System.Collections.Generic;

    public partial class ActivityResult : IEntity, ITrackable {
        public int Id { get; set; }
        public decimal GradePoint { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public short? ApprovedBy { get; set; }
        [ForeignKey("Activity")]
        public int Activity_Id { get; set; }
        public virtual Activity Activity { get; set; }
        [ForeignKey("DescriptiveIndicator")]
        public int DescriptiveIndicator_Id { get; set; }
        public virtual DescriptiveIndicator DescriptiveIndicator { get; set; }

        [ForeignKey("Student")]
        public int Student_Id { get; set; }
        public virtual Student Student { get; set; }
        [ForeignKey("AcademicTerm")]
        public int AcademicTermId { get; set; }
        public virtual AcademicTerm AcademicTerm { get; set; }
    }
}
