using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model.validationmodel
{
    [DataContract]
    public class EmailValidModel
    {
        [DataMember(IsRequired = true)]
        public string Email { get; set; }
    }
}
