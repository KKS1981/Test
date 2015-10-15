using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Domain.School;
using Repositry;
using Repository.SqlRepositories;

namespace Repository.SqlRepositories {
    public class AcademicYearRepository : SqlRepository<AcademicYear>, IAcademicYearRepository {
        public AcademicYearRepository(DbContext context)
            : base(context) {
        }

        public AcademicYear CurrentYear {
            get { return Single(x => x.IsCurrent); }
        }
    }
}
