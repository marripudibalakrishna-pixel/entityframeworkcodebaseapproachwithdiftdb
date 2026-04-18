using entityframeworkcodebaseapproachwithdiftdb.DBcontext;
using entityframeworkcodebaseapproachwithdiftdb.Entity;
using entityframeworkcodebaseapproachwithdiftdb.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace entityframeworkcodebaseapproachwithdiftdb.Repositories
{
    public class Departmentrepository : Idepartmentrepository
    {
        private readonly DepartmentContext _DepartmentContext;
      public Departmentrepository (DepartmentContext DepartmentContext)
        {
            _DepartmentContext = DepartmentContext;
        }
        public async Task<int> AddDepartment(Department dept)
        {
            var res = await _DepartmentContext.departments.AddAsync(dept);
            _DepartmentContext.SaveChanges();
            return 1;
        }

        public async Task<bool> Deletedepartmentbyid(int id)
        {
            var res = await _DepartmentContext.departments.Where(a => a.DepartmentId == id).FirstOrDefaultAsync();
            if (res != null)
            {
                _DepartmentContext.departments.Remove(res);
                _DepartmentContext.SaveChanges() ;
                return true;
                    }
            else return false;

        }

        public Task<Department> getdepartmentid(int id)
        {
            var res = _DepartmentContext.departments.Where(a=>a.DepartmentId == id).FirstOrDefaultAsync();
            if (res != null)
            {
                return res;
            }
            else return null;
        }

        public async Task<List<Department>> GetDepartments()
        {
            var res =await _DepartmentContext.departments.ToListAsync();
            if (res == null)
            {
                return null;
            }
            else
            {
                return res;
            }
        }

        public async Task<bool> Updatedepartment(Department dept)
        {
            var resu =  _DepartmentContext.departments.Update(dept);
            _DepartmentContext.SaveChanges();
            return true;
        }
    }
}
