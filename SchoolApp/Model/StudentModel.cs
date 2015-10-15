using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class CreateStudentModel
    {
        [DataMember(IsRequired = true)]
        public string AdmissionNo { get; set; }
        [DataMember(IsRequired = true)]
        public string FirstName { get; set; }
        [DataMember(IsRequired = true)]
        public string LastName { get; set; }
        [DataMember(IsRequired = true)]
        public DateTime DOB { get; set; }
        [DataMember(IsRequired = true)]
        public string Gender { get; set; }
        [DataMember(IsRequired = true)]
        public string MotherName { get; set; }
        [DataMember(IsRequired = true)]
        public string FatherName { get; set; }
        [DataMember(IsRequired = true)]
        public string PhoneNo { get; set; }
        [DataMember]
        public string MobileNo { get; set; }
        [DataMember]
        public string BoardRegNo { get; set; }

        [DataMember]
        public string CbseRollNo { get; set; }

        public string RollNo { get; set; }
        [DataMember(IsRequired = true)]
        public int ClassID { get; set; }
        
        [DataMember]
        public string House { get; set; }
        [DataMember]
        public string EmailId { get; set; }
        [DataMember]
        public string Nationality { get; set; }
        [DataMember]
        public string StreetAddress { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string State { get; set; }
        [DataMember]
        public string Country { get; set; }
        [DataMember]
        public string PinCode { get; set; }
        [DataMember]
        public string BloodGroup { get; set; }
        [DataMember]
        public decimal? Height { get; set; }
        [DataMember]
        public decimal? Weight { get; set; }
        [DataMember]
        public decimal? VisionL { get; set; }
        [DataMember]
        public decimal? VisionR { get; set; }
        [DataMember]
        public int? Dental { get; set; }
        [DataMember]
        public int? Teeth { get; set; }
        [DataMember]
        public int CategoryId { get; set; }
        [DataMember]
        public int MinorityId { get; set; }
        [DataMember]
        public string ParentalIncome { get; set; }
        [DataMember]
        public string ModeofTransport { get; set; }




        [DataMember]
        public bool? EWS { get; set; }
        [DataMember]
        public decimal? FamilyIncome { get; set; }
    }

    [DataContract]
    public class EditStudentModel
    {
        [DataMember(IsRequired=true)]
        public int Id { get; set; }
        [DataMember(IsRequired = true)]
        public string AdmissionNo { get; set; }
        [DataMember(IsRequired = true)]
        public string FirstName { get; set; }
        [DataMember(IsRequired = true)]
        public string LastName { get; set; }
        [DataMember(IsRequired = true)]
        public DateTime DOB { get; set; }
        [DataMember(IsRequired = true)]
        public string Gender { get; set; }
        [DataMember(IsRequired = true)]
        public string MotherName { get; set; }
        [DataMember(IsRequired = true)]
        public string FatherName { get; set; }
        [DataMember(IsRequired = true)]
        public string PhoneNo { get; set; }
        [DataMember]
        public string MobileNo { get; set; }

        [DataMember]
        public string BoardRegNo { get; set; }

        [DataMember]
        public string CbseRollNo { get; set; }

        [DataMember(IsRequired = true)]
        public int ClassId { get; set; }

        [DataMember]
        public int? HouseId { get; set; }
        [DataMember]
        public string EmailId { get; set; }
        [DataMember]
        public string Nationality { get; set; }
        [DataMember]
        public string StreetAddress { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string State { get; set; }
        [DataMember]
        public string Country { get; set; }
        [DataMember]
        public string PinCode { get; set; }
        [DataMember]
        public string BloodGroup { get; set; }
        [DataMember]
        public decimal? Height { get; set; }
        [DataMember]
        public decimal? Weight { get; set; }
        [DataMember]
        public decimal? VisionL { get; set; }
        [DataMember]
        public decimal? VisionR { get; set; }
        [DataMember]
        public int? Dental { get; set; }
        [DataMember]
        public int? Teeth { get; set; }
        [DataMember]
        public int? CategoryId { get; set; }
        [DataMember]
        public int? MinorityId { get; set; }
        [DataMember]
        public string ParentalIncome { get; set; }
        [DataMember]
        public string ModeofTransport { get; set; }
        [DataMember]
        public bool? EWS { get; set; }
        [DataMember]
        public decimal? FamilyIncome { get; set; }
        [DataMember]
        public string RollNo { get; set; }
    }

    [DataContract]
    public class StudentListModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
    }

    [DataContract]
    public class StudentViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string RollNo { get; set; }
        [DataMember]
        public string AdmissionNumber { get; set; }
        [DataMember]
        public string Class { get; set; }
    }

}
