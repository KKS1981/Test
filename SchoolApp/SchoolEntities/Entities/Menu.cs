using System;
using Domain.Common;

namespace Domain.School {
    public class Menu : IEntity, ITrackable {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Roles { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public Menu Parent { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
