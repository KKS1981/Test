using Model;
using Model.Account;
using Model.validationmodel;
using System;
using System.ServiceModel;
using System.ServiceModel.Web;
namespace SchoolService
{
    [ServiceContract]
    public interface ILoginService
    {

        [OperationContract]
        System.Threading.Tasks.Task<string> GetAuthKey(LoginModel model);

        [OperationContract]
        UserModel Register(RegisterModel model);

        [OperationContract]
        ValidModel IsUserNameAvailiable(UserNameValidModel model);

        [OperationContract]
        ValidModel IsEmailAvailiable(EmailValidModel model);
    }
}
