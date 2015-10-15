using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Domain.School;
using Repositry;

namespace Repository.SqlRepositories
{
    public class StudentRepository : SqlRepository<Student>, IStudentRepository
    {

        public StudentRepository(DbContext context)
            : base(context)
        {
        }

        public new IQueryable<Student> Fetch(params Expression<Func<Student, object>>[] includes)
        {
            return
                base.Fetch(includes);
            
        }

        public new List<Student> Find(Func<Student, bool> predicate,
                                            params Expression<Func<Student, object>>[] includes)
        {
            return base.Find(predicate, includes);
        }

        public new Student FindById(int id, params Expression<Func<Student, object>>[] includes)
        {
            return base.FindById(id,includes);
        }

        public new Student Single(Func<Student, bool> predicate, params Expression<Func<Student, object>>[] includes)
        {
            return base.Single(predicate, includes);
        }      

        public IEnumerable<Student> FindStudentsByClass(int classId, int? yearId, params Expression<Func<Student, object>>[] includes)
        {
            if (!yearId.HasValue)
                return _dbSet.IncludeMultiple(includes).Where(x => x.Class_Id == classId);
            return
                _dbSet.IncludeMultiple(includes).Where(
                    x => x.Class_Id == classId && x.AcademicYear_Id == yearId);
        }

        public IEnumerable<Student> FindStudentByStudentMaster(int studentMasterId, int academicYearId = 0, params Expression<Func<Student, object>>[] includes)
        {
            if (academicYearId == 0)
            {
                return _dbSet.IncludeMultiple(includes).Where(x => x.StudentMaster_Id == studentMasterId);
            }
            return _dbSet.IncludeMultiple(includes).Where(x => x.StudentMaster_Id == studentMasterId && x.AcademicYear_Id == academicYearId);
        }

        public new IEnumerable<Student> FindByIds(IEnumerable<int> ids, params Expression<Func<Student, object>>[]
                                                    includes)
        {
            return base.FindByIds(ids, includes);
        }
    }
}
