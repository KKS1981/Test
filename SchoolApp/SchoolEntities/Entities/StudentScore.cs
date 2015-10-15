using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Common;

namespace Domain.School {

    public class StudentScore : IEntity, ITrackable {
        public int Id { get; set; }
        [MaxLength]
        public string XmlData { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int StudentId { get; set; }
        public short? ApprovedBy { get; set; }
        public int? ApprovedSchema { get; set; }

        public virtual Student Student { get; set; }
    }
}
