using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model.Account
{
    [DataContract]
    public class RegisterModel
    {
        [DataMember(IsRequired=true)]
        public string UserName { get; set; }
        [DataMember(IsRequired=true)]
        public string Password { get; set; }
    }
}
