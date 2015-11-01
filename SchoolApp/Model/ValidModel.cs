using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class ValidModel
    {
        [DataMember]
        public bool IsValid { get; set; }
    }
}
