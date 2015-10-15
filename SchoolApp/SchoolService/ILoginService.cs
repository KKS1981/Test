using Model;
using Model.Account;
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
    }
}
