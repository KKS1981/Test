using Model;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
namespace SchoolService.WCFServices
{
    [ServiceContract]
    public interface IMasterService
    {
        [OperationContract]         
        Model.AcademicYearModel CreateAccedmiYear(int startYear);
        [OperationContract]
        [WebGet]
        System.Collections.Generic.List<Model.AcademicYearModel> GetAccedmicyears();
        [WebGet]
        [OperationContract]
        Model.AcademicYearModel GetCurrentAcademicYear();
        [OperationContract]
        void SetCurrentAcademicYear(int id);

        [OperationContract]
        void CreateSection(CreateSectionModel model);

        [OperationContract]
        void EditSection(EditSectionModel model);

        [OperationContract]
        [WebGet]
        List<SectionModel> GetSections();

        [OperationContract]
        void CreateClassLabel(CreateClassLabel model);

        [OperationContract]
        EditClassLable EditClassLabel(EditClassLable model);

        [OperationContract]
        [WebGet]
        List<ClassLabel> GetClassLabels();

        [OperationContract]
        void CreateClass(CreateClass model);

        [OperationContract]
        EditClass EditClass(EditClass model);

        [OperationContract]
        [WebGet]
        List<ClassListModel> GetClasses();


        
    }
}
