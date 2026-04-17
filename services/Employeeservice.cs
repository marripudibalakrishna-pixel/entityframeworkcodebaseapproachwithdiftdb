using entityframeworkcodebaseapproachwithdiftdb.Dtos;
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
        public async Task<int> Addemployee(Employeedto empdetails)
        {
            Employee emp = new Employee();
            emp.empid = empdetails.empid;
            emp.salary = empdetails.salary;
            emp.empname = empdetails.empname;

            var res = await _employeeRepository.Addemployee(emp);
            return res;
        }

        public async Task<bool> DeleteById(int id)
        {

           await _employeeRepository.DeleteById(id);
            return true;
        }

        public async Task<List<Employeedto>> GetAll()
        {
            List<Employeedto> lstempdto = new List<Employeedto>();
            var res = await _employeeRepository.GetAll();
            foreach (Employee emp in res)//To process the list data we are using forach
            {
                Employeedto empdto = new Employeedto();
                empdto.empid = emp.empid;
                empdto.salary = emp.salary;
                empdto.empname = emp.empname;
                lstempdto.Add(empdto);

            }
            return lstempdto;

        }

        public async Task<Employeedto> GetById(int id)
        {
            var res= await _employeeRepository.GetById(id);

            Employeedto empdto = new Employeedto();
           empdto.empid = res.empid;
           empdto.salary = res.salary;
           empdto.empname = res.empname;

            return empdto;
        }

        public Task<bool> Updateemployee(Employeedto empdetails)
        {
                Employee emp = new Employee();
            emp.empid = empdetails.empid;
            emp.salary = empdetails.salary;
            emp.empname = empdetails.empname;
            var res =  _employeeRepository.Updateemployee(emp);
            return res;
        }
    }
}
