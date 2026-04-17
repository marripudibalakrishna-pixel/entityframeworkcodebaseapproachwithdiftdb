using entityframeworkcodebaseapproachwithdiftdb.Entity;

namespace entityframeworkcodebaseapproachwithdiftdb.Interfaces
{
    public interface Iemployeerepository
    {
        Task<List<Employee>> GetAll();
        Task<Employee> GetById(int id);
        Task<bool> DeleteById(int id);
        Task<int> Addemployee(Employee empdetails);

        Task<bool> Updateemployee(Employee empdetails);
    }
}
