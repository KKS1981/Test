using AutoMapper;
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
    public class MasterHelper
    {
        private readonly IUnitOfWork _uow;
        public MasterHelper(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public AcademicYearModel CreateAccedmiYear(int startYear)
        {
            var year = new AcademicYear();
            year.StartMon = 4;
            year.StartYear = startYear;
            year.EndMon = 3;
            year.EndYear = startYear + 1;
            year.Label = string.Format("{0}-{1}", year.StartYear, year.EndYear);
            _uow.AcademicYears.Add(year);
            _uow.AcademicYears.SaveChanges();
            var model = ObjectMapper.MapToAcademicYearModel(year);
            return model;
        }

        public List<AcademicYearModel> GetAccedmicyears()
        {
            var years = _uow.AcademicYears.Fetch().ToList();
            var yearModels = years.Select(x => ObjectMapper.MapToAcademicYearModel(x)).ToList();
            return yearModels;
        }

        public AcademicYearModel GetCurrentAcademicYear()
        {
            var year = _uow.AcademicYears.Single(x => x.IsCurrent);
            if (year == null)
                throw new Exception("Current Academic Year Is Not Set");
            var model = ObjectMapper.MapToAcademicYearModel(year);
            return model;
        }

        public void SetCurrentAcademicYear(int id)
        {
            var years = _uow.AcademicYears.Find(x => x.IsCurrent).ToList();
            foreach (var item in years)
            {
                item.IsCurrent = false;
            }
            var year = _uow.AcademicYears.FindById(id);
            year.IsCurrent = true;

            _uow.AcademicYears.SaveChanges();

        }






        public void CreateClassLable(CreateClassLabel model)
        {
            _uow.ClassLabels.Add(new Domain.School.ClassLabel { RomanName = model.Name, NumericCode = model.NumericCode });
            _uow.ClassLabels.SaveChanges();
        }

        public EditClassLable EditClassLabel(EditClassLable model)
        {
            var classLabel = _uow.ClassLabels.Single(x => x.Id == model.Id);
            if (classLabel == null)
            {
                throw new Exception("Class Label Not Exist");
            }
            classLabel.NumericCode = model.NumericCode;
            classLabel.RomanName = model.Name;
            _uow.ClassLabels.SaveChanges();
            return model;
        }

        public List<Model.ClassLabel> GetClassLabels()
        {
            return _uow.ClassLabels.Fetch().ToList().Select(x => new Model.ClassLabel { Id = x.Id, Name = x.RomanName }).ToList();
        }

        public void CreateClass(CreateClass model)
        {
            var classLable = _uow.ClassLabels.FindById(model.ClassLabelId);

            var label = string.Format("{0}-{1}", classLable.RomanName, model.Section);
            var @class = new Class { ClassLabel_Id = model.ClassLabelId, Label = label, Section = model.Section };
            _uow.Classes.Add(@class);
            _uow.Classes.SaveChanges();
            var teacher = _uow.ClassTeachers.Single(x => x.TeacherMaster_Id == model.TeacherId);
            if (teacher != null)
            {
                //assign teacher to class

                teacher.Class = @class;
            }
            else
            {
                teacher = new ClassTeacher { Class = @class, TeacherMaster_Id = model.TeacherId };
                _uow.ClassTeachers.Add(teacher);
            }
            _uow.SaveChanges();
        }

        public EditClass EditClass(EditClass model)
        {
            var @class = _uow.Classes.FindById(model.ClassId);
            if (@class == null)
            {
                throw new Exception("Class Not Exist");
            }
            var classLable = _uow.ClassLabels.FindById(model.ClassLabelId);

            var label = string.Format("{0}-{1}", classLable.RomanName, model.Section);
            @class.Label = label;
            @class.ClassLabel_Id = model.ClassLabelId;
            @class.Section = model.Section;
            @class.ClassTeacher.TeacherMaster_Id = model.TeacherId;
            _uow.Classes.SaveChanges();
            return model;
        }

        public List<ClassListModel> GetClasses()
        {
            var classes = _uow.Classes.Fetch().ToList();
            return classes.Select(x => new ClassListModel { Id = x.Id, Name = x.Label }).ToList();
        }

        public List<ClassesViewModel> GetClassList()
        {
            var classes = _uow.Classes.Fetch(x=>x.ClassTeacher.Teacher).ToList();
            return classes.Select(x => ObjectMapper.MapToClassesViewModel(x)).ToList();
        }
    }
}
