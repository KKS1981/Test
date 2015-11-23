using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class CreateTeacher
    {
        [DataMember(IsRequired = true)]
        public string UserName { get; set; }

        [DataMember(IsRequired = true)]
        public string Email { get; set; }

        [DataMember(IsRequired = true)]
        public string Password { get; set; }

        [DataMember(IsRequired = true)]
        public string ConfirmPassword { get; set; }

        [DataMember(IsRequired = true)]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string MotherName { get; set; }

        [DataMember]
        public string FatherName { get; set; }

        [DataMember(IsRequired = true)]
        public DateTime Dob { get; set; }

        [DataMember]
        public DateTime? Doj { get; set; }

        [DataMember(IsRequired = true)]
        public string PhoneNumber { get; set; }

        [DataMember]
        public string MobileNumber { get; set; }

        [DataMember(IsRequired = true)]
        public string Gender { get; set; }

        [DataMember(IsRequired = true)]
        public string Nationality { get; set; }

        [DataMember]
        public string Qualification { get; set; }

        [DataMember]
        public string City { get; set; }

        [DataMember]
        public string State { get; set; }

        [DataMember]
        public string StreetAddress { get; set; }

        [DataMember]
        public string Country { get; set; }

        [DataMember]
        public string ZipCode { get; set; }
    }

    [DataContract]
    public class EditTeacher
    {
        [DataMember(IsRequired = true)]
        public int Id { get; set; }

        [DataMember(IsRequired = true)]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string MotherName { get; set; }

        [DataMember]
        public string FatherName { get; set; }

        [DataMember(IsRequired = true)]
        public DateTime Dob { get; set; }

        [DataMember]
        public DateTime? Doj { get; set; }

        [DataMember(IsRequired = true)]
        public string PhoneNumber { get; set; }

        [DataMember]
        public string MobileNumber { get; set; }

        [DataMember(IsRequired = true)]
        public string Gender { get; set; }

        [DataMember(IsRequired = true)]
        public string Nationality { get; set; }

        [DataMember]
        public string Qualification { get; set; }

        [DataMember]
        public string City { get; set; }

        [DataMember]
        public string State { get; set; }

        [DataMember]
        public string Country { get; set; }

        [DataMember]
        public string ZipCode { get; set; }

        [DataMember]
        public string StreetAddress { get; set; }

        [DataMember]
        public string Email { get; set; }
    }

    [DataContract]
    public class TeacherListModel
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
    }

    [DataContract]
    public class TeacherViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string FullName { get; set; }

        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public string PhoneNumber { get; set; }

        [DataMember]
        public string MobileNumber { get; set; }

        [DataMember]
        public string Gender { get; set; }

        [DataMember]
        public DateTime Dob { get; set; }
        [DataMember]
        public string ImagePath { get; set; }
    }
}
