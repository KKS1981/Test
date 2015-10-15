using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Domain.Common;

namespace Domain.School {
    public class Settings : IEntity, ITrackable {

        public int Id { get; set; }
        [MaxLength]
        public string Key { get; set; }
        [MaxLength]
        public string Value { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
    }


}
