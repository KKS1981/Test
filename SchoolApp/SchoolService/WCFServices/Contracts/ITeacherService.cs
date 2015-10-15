using Model;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
namespace SchoolService.WCFServices.Services
{
    [ServiceContract]
    interface ITeacherService
    {
        [OperationContract]
        void CreateTeacher(Model.CreateTeacher model);

        [OperationContract]
        EditTeacher EditTeacher(EditTeacher model);

        [OperationContract]
        [WebGet]
        List<TeacherListModel> TeacherList();
        
    }
}
