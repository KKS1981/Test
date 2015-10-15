using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace SchoolService.WCFServices.Contracts
{
    [ServiceContract]
    public interface IStudentService
    {
        [OperationContract]
        void CreateStudent(CreateStudentModel model);

        [OperationContract]
        [WebGet]
        EditStudentModel GetStudent(int id);

        [OperationContract]
        EditStudentModel EditStudent(EditStudentModel model);

        [OperationContract]
        [WebGet]
        List<StudentListModel> GetClassStudentNameAndIds(int classId);


        [OperationContract]
        [WebGet]
        List<StudentViewModel> GetClassStudents(int classID);
    }
}
