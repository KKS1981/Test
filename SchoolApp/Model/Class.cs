using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class CreateClass
    {
        [DataMember(IsRequired = true)]
        public int SectionLabelId { get; set; }

        [DataMember(IsRequired = true)]
        public int ClassLabelId { get; set; }

        [DataMember(IsRequired = true)]
        public int TeacherId { get; set; }
    }

    [DataContract]
    public class EditClass
    {
        [DataMember(IsRequired = true)]
        public int ClassId { get; set; }

        [DataMember(IsRequired = true)]
        public int SectionLabelId { get; set; }

        [DataMember(IsRequired = true)]
        public int ClassLabelId { get; set; }

        [DataMember(IsRequired = true)]
        public int TeacherId { get; set; }
    }

    [DataContract]
    public class ClassListModel
    {
        [DataMember(IsRequired = true)]
        public int Id { get; set; }

        [DataMember(IsRequired = true)]
        public string Name { get; set; }
    }
}
