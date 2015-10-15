using Domain.School;
using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper.Helper
{
    public class StudentHelper
    {
        private readonly IUnitOfWork _uow;
        public StudentHelper(IUnitOfWork iow)
        {
            _uow = iow;
        }

        public void CreateStudent(Model.CreateStudentModel model)
        {
            var student = ObjectMapper.MapToStudent(model);
            var @class = _uow.Classes.FindById(model.ClassID);
            var house = _uow.Houses.Single(x => x.Name == model.House);
            if (house != null)
            {
                student.House = house;
            }
            var category = _uow.Categories.Single(x => x.Id == model.CategoryId);
            if (category != null)
                student.StudentMaster.Category = category;
            var minority = _uow.Minorities.Single(x => x.Id == model.MinorityId);
            if (minority != null)
            {
                student.StudentMaster.Minority = minority;
            }
            student.AcademicYear_Id = _uow.AcademicYears.CurrentYear.Id;
            student.Class_Id = @class.Id;
            _uow.Students.Add(student);
            _uow.Students.SaveChanges();
        }

        public Model.EditStudentModel EditStudent(int studentId)
        {
            var student = _uow.Students.FindById(studentId, x => x.StudentMaster, x => x.HealthInformations);
            var editStudentModel = ObjectMapper.MapToEditStudentModel(student);
            return editStudentModel;
        }

        public Model.EditStudentModel EditStudent(Model.EditStudentModel model)
        {
            var student = _uow.Students.FindById(model.Id);
            ObjectMapper.MapToStudent(model, student);
            
            _uow.Students.SaveChanges();
            return model;
        }

        public List<Model.StudentListModel> GetClassStudentNameAndIds(int classId)
        {
            var students = _uow.Students.Find(x => x.Class_Id == classId, x => x.StudentMaster).ToList();
            return students.Select(x => new StudentListModel { Id = x.Id, Name = x.StudentMaster.FullName }).ToList();
        }

        public List<Model.StudentViewModel> GetClassStudents(int classID)
        {
            var students = _uow.Students.Find(x => x.Class_Id == classID, x => x.StudentMaster, x => x.Class).ToList();
            return students.Select(x => ObjectMapper.MapToStudentViewModel(x)).ToList();
        }
    }
}
