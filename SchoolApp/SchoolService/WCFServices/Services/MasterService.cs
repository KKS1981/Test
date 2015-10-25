using Helper.Helper;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading.Tasks;

namespace SchoolService.WCFServices
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class MasterService : SchoolService.WCFServices.IMasterService
    {
        private readonly MasterHelper _masterHelper;
        public MasterService(MasterHelper masterHelper)
        {
            _masterHelper = masterHelper;
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "Admin")]
        public AcademicYearModel CreateAccedmiYear(int startYear)
        {
            var model = _masterHelper.CreateAccedmiYear(startYear);
            return model;
        }

        [PrincipalPermission(SecurityAction.Demand)]
        public List<AcademicYearModel> GetAccedmicyears()
        {
            var list = _masterHelper.GetAccedmicyears();
            return list;
        }

        [PrincipalPermission(SecurityAction.Demand)]
        public AcademicYearModel GetCurrentAcademicYear()
        {
            var model = _masterHelper.GetCurrentAcademicYear();
            return model;
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "Admin")]
        public void SetCurrentAcademicYear(int id)
        {
            _masterHelper.SetCurrentAcademicYear(id);
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "Admin")]
        public void CreateClassLabel(CreateClassLabel model)
        {
            _masterHelper.CreateClassLable(model);
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "Admin")]
        public EditClassLable EditClassLabel(EditClassLable model)
        {
            return _masterHelper.EditClassLabel(model);
        }

        [PrincipalPermission(SecurityAction.Demand)]
        public List<ClassLabel> GetClassLabels()
        {
            return _masterHelper.GetClassLabels();
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "Admin")]
        public void CreateClass(CreateClass model)
        {
            _masterHelper.CreateClass(model);
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "Admin")]
        public EditClass EditClass(EditClass model)
        {
            return _masterHelper.EditClass(model);
        }

        [PrincipalPermission(SecurityAction.Demand)]
        public List<ClassListModel> GetClasses()
        {
            return _masterHelper.GetClasses();
        }

        [PrincipalPermission(SecurityAction.Demand)]
        public List<ClassesViewModel> GetClassList()
        {
           return _masterHelper.GetClassList();
        }

        [PrincipalPermission(SecurityAction.Demand)]
        public EditClass GetClass(int id)
        {
             return _masterHelper.GetClass(id);
        }
    }
}
