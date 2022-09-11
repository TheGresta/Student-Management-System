using Core.DataAccess.EntityFramework;
using StudentManagementSystem.DataAccess.Abstract;
using StudentManagementSystem.DataAccess.Context;
using StudentManagementSystem.Entity.Concrete;

namespace StudentManagementSystem.DataAccess.Concrete.EntityFramework
{
    public class EfExpertiseDal : EfRepositoryBase<Expertise, StudentManagementSystemDbContext>, IExpertiseDal
    {
        private readonly StudentManagementSystemDbContext _context;
        public EfExpertiseDal(StudentManagementSystemDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
