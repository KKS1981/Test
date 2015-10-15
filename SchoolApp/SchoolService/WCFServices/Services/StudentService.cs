using Helper.Helper;
using SchoolService.WCFServices.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading.Tasks;

namespace SchoolService.WCFServices.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class StudentService : IStudentService
    {
        private readonly StudentHelper _sHelper;
        public StudentService(StudentHelper helper)
        {
            _sHelper = helper;
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "Admin")]
        public void CreateStudent(Model.CreateStudentModel model)
        {
            _sHelper.CreateStudent(model);
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "Admin,Teacher")]
        public Model.EditStudentModel GetStudent(int id)
        {
            return _sHelper.EditStudent(id);
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "Admin")]
        public Model.EditStudentModel EditStudent(Model.EditStudentModel model)
        {
            return _sHelper.EditStudent(model);
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "Admin,Teacher")]
        public List<Model.StudentListModel> GetClassStudentNameAndIds(int classId)
        {
            return _sHelper.GetClassStudentNameAndIds(classId);
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "Admin,Teacher")]
        public List<Model.StudentViewModel> GetClassStudents(int classID)
        {
            return _sHelper.GetClassStudents(classID);
        }
    }
}
