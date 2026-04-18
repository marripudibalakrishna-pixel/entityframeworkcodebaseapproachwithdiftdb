using entityframeworkcodebaseapproachwithdiftdb.DBcontext;
using entityframeworkcodebaseapproachwithdiftdb.Entity;
using entityframeworkcodebaseapproachwithdiftdb.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace entityframeworkcodebaseapproachwithdiftdb.Repositories
{
    public class Employeerepository : Iemployeerepository
    {
        private readonly EmployeeContext _employeeContext;
        public Employeerepository(EmployeeContext employeeContext) 
        {
            _employeeContext = employeeContext;
        }
        public async Task<int> Addemployee(Employee empdetails)
        {
             await _employeeContext.Employees.AddAsync(empdetails);
            _employeeContext.SaveChanges();
            return 1;

        }

        public async Task<bool> DeleteById(int id)
        {
            var resu = await _employeeContext.Employees.Where(e => e.empid == id).FirstOrDefaultAsync();
            if(resu != null)
            {
                _employeeContext.Employees.Remove(resu);
                _employeeContext.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<List<Employee>> GetAll()
        {
           var res= await _employeeContext.Employees.ToListAsync();
            if(res.Count==0)
                {
                return null;
            }
            return res;
        }

        public async Task<Employee> GetById(int id)
        {
            var resu = await  _employeeContext.Employees.Where(e => e.empid == id).FirstOrDefaultAsync();
            if(resu == null)
            {
                return null;
            }
            return resu;
        }

        public async Task<bool> Updateemployee(Employee empdetails)
        {
            _employeeContext.Employees.Update(empdetails);
            await _employeeContext.SaveChangesAsync();
            return true;

        }
    }
}
