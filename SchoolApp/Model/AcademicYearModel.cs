using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class AcademicYearModel
    {
        public int Id { get; set; }
        public int StartMon { get; set; }
        public int EndMon { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public string Label { get; set; }
        public bool IsCurrent { get; set; }
    }
}
