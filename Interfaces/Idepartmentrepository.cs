using entityframeworkcodebaseapproachwithdiftdb.Entity;

namespace entityframeworkcodebaseapproachwithdiftdb.Interfaces
{
    public interface Idepartmentrepository
    {
       Task<List<Department>> GetDepartments();
        Task<int> AddDepartment(Department dept);
        Task<Department> getdepartmentid(int id);
        Task<bool> Deletedepartmentbyid(int id);
        Task<bool> Updatedepartment(Department dept);
        
    }
}

