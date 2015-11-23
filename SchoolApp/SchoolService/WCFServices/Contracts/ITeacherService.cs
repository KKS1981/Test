using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Web;
namespace SchoolService.WCFServices.Services
{
    [ServiceContract]
    interface ITeacherService
    {
        [OperationContract]
        int CreateTeacher(Model.CreateTeacher model);

        [OperationContract]
        EditTeacher EditTeacher(EditTeacher model);

        [OperationContract]
        [WebGet]
        EditTeacher GetEditTeacher(int id);

        [OperationContract]
        [WebGet]
        List<TeacherListModel> TeacherList();

        [OperationContract]
        [WebGet]
        List<TeacherViewModel> TeacherViewList();

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/Uploadteacherimage/{fileName}/{teacherid}")]
        void UploadTeacherImage(string fileName,string teacherid, Stream stream);
        
    }
}
