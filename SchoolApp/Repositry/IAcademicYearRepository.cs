using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.School;
using Repositry;

namespace Repository.SqlRepositories {
    public interface IAcademicYearRepository : IRepository<AcademicYear> {
        AcademicYear CurrentYear { get; }
    }
}
