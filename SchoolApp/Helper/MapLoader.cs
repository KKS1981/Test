using AutoMapper;
using Domain.School;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    public class MapLoader
    {
        public static void LoadMappings()
        {
            Mapper.CreateMap<AcademicYear, AcademicYearModel>();
        }
    }

    public class ObjectMapper
    {
        internal static Teacher MapToTeacher(CreateTeacher model)
        {
            var master = new Teacher();
            master.City = model.City;
            master.Country = model.Country;
            master.DOB = model.Dob;
            master.EmailId = model.Email;
            master.FatherName = model.FatherName;
            master.FirstName = model.FirstName;
            master.Gender = ConvertGendertobool(model.Gender);
            master.FirstName = model.FirstName;
            master.JoiningDate = model.Doj;
            master.LastName = model.LastName;
            master.MobileNo = model.MobileNumber;
            master.MotherName = model.MotherName;
            master.Nationality = model.Nationality;
            master.PhoneNo = model.PhoneNumber;
            master.PinCode = model.ZipCode;
            master.Qualification = model.Qualification;
            master.State = model.State;
            master.StreetAddress = model.StreetAddress;
            return master;
        }

        internal static bool? ConvertGendertobool(string gender)
        {
            if (gender == Gender.Male.ToString()) { return true; }
            if (gender == Gender.Female.ToString()) { return false; }
            return null;
        }

        internal static Teacher MapToTeacher(EditTeacher model)
        {
            var master = new Teacher();
            master.Id = model.Id;
            master.City = model.City;
            master.Country = model.Country;
            master.DOB = model.Dob;
            master.FatherName = model.FatherName;
            master.FirstName = model.FirstName;
            master.Gender = ConvertGendertobool(model.Gender);
            master.FirstName = model.FirstName;
            master.JoiningDate = model.Doj;
            master.LastName = model.LastName;
            master.MobileNo = model.MobileNumber;
            master.MotherName = model.MotherName;
            master.Nationality = model.Nationality;
            master.PhoneNo = model.PhoneNumber;
            master.PinCode = model.ZipCode;
            master.Qualification = model.Qualification;
            master.State = model.State;
            master.StreetAddress = model.StreetAddress;
            return master;
        }

        internal static void MapToTeacher(EditTeacher source, Teacher destination)
        {
            destination.Id = source.Id;
            destination.City = source.City;
            destination.Country = source.Country;
            destination.DOB = source.Dob;
            destination.FatherName = source.FatherName;
            destination.FirstName = source.FirstName;
            destination.Gender = ConvertGendertobool(source.Gender);
            destination.FirstName = source.FirstName;
            destination.JoiningDate = source.Doj;
            destination.LastName = source.LastName;
            destination.MobileNo = source.MobileNumber;
            destination.MotherName = source.MotherName;
            destination.Nationality = source.Nationality;
            destination.PhoneNo = source.PhoneNumber;
            destination.PinCode = source.ZipCode;
            destination.Qualification = source.Qualification;
            destination.State = source.State;
            destination.StreetAddress = source.StreetAddress;
        }

        internal static Student MapToStudent(CreateStudentModel model)
        {
            var student = new Student();
            student.BoardRegistrationNo = model.BoardRegNo;
            student.CBSERollNo = model.CbseRollNo;
            student.RollNo = model.RollNo;

            student.HealthInformations = new HealthInformation();
            student.HealthInformations.Dental = model.Dental;
            student.HealthInformations.Height = model.Height;
            student.HealthInformations.Teeth = model.Teeth;
            student.HealthInformations.VisionL = model.VisionL;
            student.HealthInformations.VisionR = model.VisionR;
            student.HealthInformations.Weight = model.Weight;

            student.StudentMaster = new StudentMaster();
            student.StudentMaster.AdmissionNo = model.AdmissionNo;
            student.StudentMaster.BloodGroup = model.BloodGroup;
            student.StudentMaster.City = model.City;
            student.StudentMaster.Country = model.Country;
            student.StudentMaster.DOB = model.DOB;
            student.StudentMaster.EmailId = model.EmailId;
            student.StudentMaster.EWS = model.EWS;
            student.StudentMaster.FamilyIncome = model.FamilyIncome;
            student.StudentMaster.FatherName = model.FatherName;
            student.StudentMaster.FirstName = model.FirstName;
            student.StudentMaster.LastName = model.LastName;
            student.StudentMaster.MobileNo = model.MobileNo;
            student.StudentMaster.MotherName = model.MotherName;
            student.StudentMaster.Nationality = model.Nationality;
            student.StudentMaster.PhoneNo = model.PhoneNo;
            student.StudentMaster.PinCode = model.PinCode;
            student.StudentMaster.State = model.State;
            student.StudentMaster.StreetAddress = model.StreetAddress;
            student.StudentMaster.Transport = model.ModeofTransport;
            return student;
        }

        internal static EditStudentModel MapToEditStudentModel(Student student)
        {
            var model = new EditStudentModel();
            model.CbseRollNo = student.CBSERollNo;
            model.RollNo = student.RollNo;


            model.Dental = student.HealthInformations.Dental;
            model.Height = student.HealthInformations.Height;
            model.Teeth = student.HealthInformations.Teeth;
            model.VisionL = student.HealthInformations.VisionL;
            model.VisionR = student.HealthInformations.VisionR;
            model.Weight = student.HealthInformations.Weight;
            model.ClassId = student.Class_Id;
            model.HouseId = student.House_Id;
            model.CategoryId = student.StudentMaster.Category_Id;
            model.MinorityId = student.StudentMaster.Minority_Id;

            model.AdmissionNo = student.StudentMaster.AdmissionNo;
            model.BloodGroup = student.StudentMaster.BloodGroup;
            model.City = student.StudentMaster.City;
            model.Country = student.StudentMaster.Country;
            model.DOB = student.StudentMaster.DOB;
            model.EmailId = student.StudentMaster.EmailId;
            model.EWS = student.StudentMaster.EWS;
            model.FamilyIncome = student.StudentMaster.FamilyIncome;
            model.FatherName = student.StudentMaster.FatherName;
            model.FirstName = student.StudentMaster.FirstName;
            model.LastName = student.StudentMaster.LastName;
            model.MobileNo = student.StudentMaster.MobileNo;
            model.MotherName = student.StudentMaster.MotherName;
            model.Nationality = student.StudentMaster.Nationality;
            model.PhoneNo = student.StudentMaster.PhoneNo;
            model.PinCode = student.StudentMaster.PinCode;
            model.State = student.StudentMaster.State;
            model.StreetAddress = student.StudentMaster.StreetAddress;
            model.ModeofTransport = student.StudentMaster.Transport;
            return model;
        }

        internal static void MapToStudent(EditStudentModel model, Student student)
        {
            student.BoardRegistrationNo = model.BoardRegNo;
            student.CBSERollNo = model.CbseRollNo;
            student.RollNo = model.RollNo;
            student.Class_Id = model.ClassId;
            student.House_Id = model.HouseId;

            student.HealthInformations.Dental = model.Dental;
            student.HealthInformations.Height = model.Height;
            student.HealthInformations.Teeth = model.Teeth;
            student.HealthInformations.VisionL = model.VisionL;
            student.HealthInformations.VisionR = model.VisionR;
            student.HealthInformations.Weight = model.Weight;

            student.StudentMaster.AdmissionNo = model.AdmissionNo;
            student.StudentMaster.BloodGroup = model.BloodGroup;
            student.StudentMaster.City = model.City;
            student.StudentMaster.Country = model.Country;
            student.StudentMaster.DOB = model.DOB;
            student.StudentMaster.EmailId = model.EmailId;
            student.StudentMaster.EWS = model.EWS;
            student.StudentMaster.FamilyIncome = model.FamilyIncome;
            student.StudentMaster.FatherName = model.FatherName;
            student.StudentMaster.FirstName = model.FirstName;
            student.StudentMaster.LastName = model.LastName;
            student.StudentMaster.MobileNo = model.MobileNo;
            student.StudentMaster.MotherName = model.MotherName;
            student.StudentMaster.Nationality = model.Nationality;
            student.StudentMaster.PhoneNo = model.PhoneNo;
            student.StudentMaster.PinCode = model.PinCode;
            student.StudentMaster.State = model.State;
            student.StudentMaster.StreetAddress = model.StreetAddress;
            student.StudentMaster.Transport = model.ModeofTransport;
            student.StudentMaster.Category_Id = model.CategoryId;
            student.StudentMaster.Minority_Id = model.MinorityId;

        }

        internal static StudentViewModel MapToStudentViewModel(Student student)
        {
            var model = new StudentViewModel();
            model.AdmissionNumber = student.StudentMaster.AdmissionNo;
            model.Class = student.Class.Label;
            model.Id = student.Id;
            model.Name = student.StudentMaster.FullName;
            model.RollNo = student.RollNo;
            return model;
        }

        internal static AcademicYearModel MapToAcademicYearModel(AcademicYear year)
        {
            var model = new AcademicYearModel();
            model.Id = year.Id;
            model.EndMon = year.EndMon;
            model.EndYear = year.EndYear;
            model.IsCurrent = year.IsCurrent;
            model.Label = year.Label;
            model.StartMon = year.StartMon;
            model.StartYear = year.StartYear;
            return model;
        }

        internal static ClassesViewModel MapToClassesViewModel(Class @class)
        {
            ClassesViewModel model = new ClassesViewModel();
            model.ClassLablel = @class.ClassLabel.RomanName;
            model.Label = @class.Label;
            if (@class.ClassTeacher != null)
                model.ClassTeacher = @class.ClassTeacher.Teacher.FullName;
            model.ID = @class.Id;
            model.NumericCode = @class.ClassLabel.NumericCode;
            return model;
        }
    }

}
