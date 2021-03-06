using Helper.Helper;
using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace SchoolService.WCFServices.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class TeacherService : SchoolService.WCFServices.Services.ITeacherService
    {
        private readonly TeacherHelper _teacherHelper;
        public TeacherService(TeacherHelper teacherHelper)
        {
            _teacherHelper = teacherHelper;
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "Admin")]
        public int CreateTeacher(CreateTeacher model)
        {

           return  _teacherHelper.CreateTeacher(model);
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "Admin")]
        public EditTeacher EditTeacher(EditTeacher model)
        {
            return _teacherHelper.EditTeacher(model);
        }

        [PrincipalPermission(SecurityAction.Demand)]
        public List<TeacherListModel> TeacherList()
        {
            return _teacherHelper.GetTeacherList();
        }

        [PrincipalPermission(SecurityAction.Demand)]
        public List<TeacherViewModel> TeacherViewList()
        {
            return _teacherHelper.GetTeacherViewList();
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "Admin")]
        public void UploadTeacherImage(string fileName, string teacherid, System.IO.Stream stream)
        {            
            _teacherHelper.SaveTeacherImage(fileName,teacherid, stream);
            return ;
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "Admin")]
        public EditTeacher GetEditTeacher(int id)
        {
            return _teacherHelper.EditTeacher(id);
        }


        public ValidModel IsEmailValidForTeacher(TeacherEmailValid model)
        {
            return _teacherHelper.IsEmailValidForTeacher(model.ID,model.Email);
        }
    }
}
