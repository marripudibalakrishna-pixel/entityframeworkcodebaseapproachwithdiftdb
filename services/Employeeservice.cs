using entityframeworkcodebaseapproachwithdiftdb.Entity;

using entityframeworkcodebaseapproachwithdiftdb.Interfaces;

namespace entityframeworkcodebaseapproachwithdiftdb.services
{
    public class Employeeservice : Iemployeeseervice
    {
            private readonly Iemployeerepository _employeeRepository;
        public Employeeservice(Iemployeerepository employeeRepository)
            {
            _employeeRepository = employeeRepository;
        }
        public async Task<int> Addemployee(Employee empdetails)
        {
            Employee emp = new Employee();
            emp.empid = empdetails.empid;
            emp.salary = empdetails.salary;
            emp.empname = empdetails.empname;

            var res = await _employeeRepository.Addemployee(emp);
            return res;
        }

        public Task<bool> DeleteById(int id)
        {
           
        }

        public Task<List<Employee>> GetAll()
        {
           
        }

        public Task<Employee> GetById(int id)
        {
        }

        public Task<bool> Updateemployee(Employee empdetails)
        {
        }
    }
}
