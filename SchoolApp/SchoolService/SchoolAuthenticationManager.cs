using AccountService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IdentityModel.Policy;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace SchoolService
{
    public class SchoolAuthenticationManager : ServiceAuthenticationManager
    {
        public override ReadOnlyCollection<IAuthorizationPolicy> Authenticate(ReadOnlyCollection<IAuthorizationPolicy> authPolicy, Uri listenUri, ref Message message)
        {
            IncomingWebRequestContext request = WebOperationContext.Current.IncomingRequest;
            WebHeaderCollection headers = request.Headers;

            string token = null;
            if (headers["token"] != null)
            {
                token = headers["token"];
            }
            IPrincipal user = new SchoolPrincipal(token);

            message.Properties["Principal"] = user;

            message.Properties["hello"] = "world";
            return authPolicy;
        }
    }

    public class SchoolPrincipal : IPrincipal
    {
        private string _token;
        private IIdentity _identity;
        private SingletonContainer _container;

        public SchoolPrincipal(string token)
        {
            _token = token; 
            _container=SingletonContainer.Instance;
        }
        public IIdentity Identity
        {
            get
            {
                if (_identity == null)
                {                    
                    IAccountService service= _container.Get<IAccountService>();
                    _identity=service.GetIIdentityByAuthkey(_token);
                }
                return _identity;
            }
        }

        public bool IsInRole(string role)
        {
            var roles = role.Split(',');
            IAccountService service= _container.Get<IAccountService>();
            return service.IsInRole(roles, _identity);
        }
    }



    public class SchoolAuthorizationPolicy : IAuthorizationPolicy
    {
        public bool Evaluate(EvaluationContext evaluationContext, ref object state)
        {
            IPrincipal user = OperationContext.Current.IncomingMessageProperties
                ["Principal"] as IPrincipal;
            evaluationContext.Properties["Principal"] = user;
            evaluationContext.Properties["Identities"] = new List<IIdentity> { user.Identity };

            return false;
        }
        //... other methods ...


        public System.IdentityModel.Claims.ClaimSet Issuer
        {
            get { throw new NotImplementedException(); }
        }

        public string Id
        {
            get { throw new NotImplementedException(); }
        }
    }

}


