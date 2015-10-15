using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Domain.Common;

namespace Domain.School {

    public class Attendance : IEntity, ITrackable {
        public int Id { get; set; }
        public int? Jan { get; set; }
        public int? Feb { get; set; }
        public int? Mar { get; set; }
        public int? Apr { get; set; }
        public int? May { get; set; }
        public int? Jun { get; set; }
        public int? Jul { get; set; }
        public int? Aug { get; set; }
        public int? Sep { get; set; }
        public int? Oct { get; set; }
        public int? Nov { get; set; }
        public int? Dec { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int? ClassId { get; set; }

        [NotMapped]
        public int Total {
            get {
                //var total = Jan + Feb + Mar + Apr + May + Jun + Jul + Aug + Sep + Oct + Nov + Dec;
                //return total.HasValue ? total.Value : 0;
                return Sum(Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep, Oct, Nov, Dec);
            }
        }

        public virtual AcademicYear AcademicYear { get; set; }
        public virtual Student Student { get; set; }
        public virtual Class Class { get; set; }

        private int Sum(params int?[] toAdd ) {
            return toAdd.Sum(i => i.HasValue ? i.Value : 0);
        }


    }
}
