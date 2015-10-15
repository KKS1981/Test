using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Common;

namespace Domain.School {
    public class TeacherUpload : IEntity, ITrackable {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public virtual File File { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
