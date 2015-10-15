using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Common;

namespace Domain.School {
    /// <summary>
    /// The class contains data for children who were absent on a given day
    /// </summary>
    /// 
    
    public class StudentAttendances : IEntity, ITrackable {
        public StudentAttendances() {
            Students = new List<Student>();
        }

        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }

        public DateTime Date { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}