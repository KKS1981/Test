using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Common {
    public interface ITrackable {
        DateTime CreatedDate { get; set; }
        DateTime? ModifiedDate { get; set; }
        DateTime? DeletedDate { get; set; }
    }
}
