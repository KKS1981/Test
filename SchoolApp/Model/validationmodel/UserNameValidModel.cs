using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model.validationmodel
{
    [DataContract]
    public class UserNameValidModel
    {
        [DataMember(IsRequired=true)]
        public string UserName { get; set; }
    }
}
