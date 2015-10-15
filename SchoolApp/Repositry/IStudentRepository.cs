using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Domain.School;
using Repositry;

namespace Repository
{
    public interface IStudentRepository : IRepository<Student>
    {

        IEnumerable<Student> FindStudentsByClass(int classId, int? yearId, params Expression<Func<Student, object>>[] includes);
        IEnumerable<Student> FindStudentByStudentMaster(int studentMasterId, int academicYearId = 0, params Expression<Func<Student, object>>[] includes);

    }
}
