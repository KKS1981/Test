using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Common;

namespace Domain.School {
    public class StudentAssignment : IEntity, ITrackable {
        public int Id { get; set; }
        [MaxLength]
        public string FilePath { get; set; }
        [MaxLength]
        public string Title { get; set; }
        [MaxLength]
        public string Description { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }

        public virtual Student Student { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual File File { get; set; }
    }
}
