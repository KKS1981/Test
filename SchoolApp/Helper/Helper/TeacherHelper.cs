using AccountService;
using Domain.School;
using Model;
using Repository;
using SchoolService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
//using System.Net.Http;
//using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Helper.Helper
{
    public class TeacherHelper
    {
        private readonly IUnitOfWork _uow;
        private readonly IAccountService _aService;
        public TeacherHelper(IUnitOfWork uow, IAccountService aService)
        {
            _uow = uow;
            _aService = aService;
        }
        public int CreateTeacher(Model.CreateTeacher model, string Path = null)
        {
            var user = _aService.CreateUser(model.UserName, model.Email, model.Password, Roles.Teacher.ToString());
            var teacher = ObjectMapper.MapToTeacher(model);
            teacher.UserId = user.UserID;
            teacher.UserName = user.UserName;
            teacher.ImagePath = Path;
            _uow.Teachers.Add(teacher);
            _uow.Teachers.SaveChanges();
            return teacher.Id;
        }

        public Model.EditTeacher EditTeacher(Model.EditTeacher model)
        {
            var teacher = _uow.Teachers.FindById(model.Id);
            ObjectMapper.MapToTeacher(model, teacher);
            _uow.Teachers.SaveChanges();
            return model;

        }

        public List<Model.TeacherListModel> GetTeacherList()
        {
            var teachers = _uow.Teachers.Fetch().ToList();
            return teachers.Select(x => new TeacherListModel { ID = x.Id, Name = x.FullName }).ToList();
        }

        public List<TeacherViewModel> GetTeacherViewList()
        {
            var teachers = _uow.Teachers.Fetch().ToList();
            return teachers.Select(x => ObjectMapper.MapToTeacherViewModel(x)).ToList();

        }

        public void SaveTeacherImage(string fileName, string teacherID, System.IO.Stream stream)
        {
            var teacher = _uow.Teachers.FindById(Convert.ToInt32(teacherID));
            var path = FileHelper.SaveFile(fileName, stream);
            teacher.ImagePath = path;
            _uow.Teachers.SaveChanges();
        }
    }
}
