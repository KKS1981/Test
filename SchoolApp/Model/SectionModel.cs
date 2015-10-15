using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class CreateSectionModel
    {
        [DataMember(IsRequired = true)]
        public string Name { get; set; }
    }
    [DataContract]
    public class EditSectionModel
    {
        [DataMember(IsRequired = true)]
        public int Id { get; set; }
        [DataMember(IsRequired = true)]
        public String Name { get; set; }
    }
    [DataContract]
    public class SectionModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
}
