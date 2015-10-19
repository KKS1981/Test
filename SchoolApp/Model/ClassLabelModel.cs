using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class CreateClassLabel
    {
        [DataMember(IsRequired = true)]
        public string Name { get; set; }

       

        [DataMember(IsRequired = true)]
        public int NumericCode { get; set; }
    }

    [DataContract]
    public class EditClassLable
    {
        [DataMember(IsRequired = true)]
        public int Id { get; set; }

        [DataMember(IsRequired = true)]
        public string Name { get; set; }        

        [DataMember(IsRequired = true)]
        public int NumericCode { get; set; }
    }

    [DataContract]
    public class ClassLabel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

    }
}
