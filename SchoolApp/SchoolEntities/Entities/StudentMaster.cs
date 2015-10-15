using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;


namespace Domain.School {

    public class StudentMaster : IUser, IEntity, ITrackable {

        public int Id { get; set; }
        [MaxLength]
        public string FirstName { get; set; }
        [MaxLength]
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public bool Gender { get; set; }
        public string MotherName { get; set; }
        [MaxLength]
        public string FatherName { get; set; }
        [MaxLength]
        public string PhoneNo { get; set; }
        [MaxLength]
        public string MobileNo { get; set; }
        [MaxLength]
        public string EmailId { get; set; }
        [MaxLength]
        public string Nationality { get; set; }
        [MaxLength]
        public string AdmissionNo { get; set; }
        [MaxLength]
        public string StreetAddress { get; set; }
        [MaxLength]
        public string City { get; set; }
        [MaxLength]
        public string State { get; set; }
        [MaxLength]
        public string Country { get; set; }
        public string PinCode { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        [MaxLength]
        public string BloodGroup { get; set; }
        [MaxLength]
        public string ImagePath { get; set; }
        public decimal? FamilyIncome { get; set; }
        [MaxLength]
        public string Transport { get; set; }
        public bool? EWS { get; set; }

        [ForeignKey("Category")]
        public int? Category_Id { get; set; }

        [ForeignKey("Minority")]
        public int? Minority_Id { get; set; }

        public string UserId { get; set; }
        [MaxLength]
        public string UserName { get; set; }

        [NotMapped]
        public string FullName {
            get { return string.Format("{0} {1}", FirstName, LastName); }
        }

        public virtual ICollection<Student> Students { get; set; }
        public virtual Category Category { get; set; }
        public virtual Minority Minority { get; set; }
    }
}
