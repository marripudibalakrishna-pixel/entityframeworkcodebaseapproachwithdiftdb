using entityframeworkcodebaseapproachwithdiftdb.Dtos;
using entityframeworkcodebaseapproachwithdiftdb.Entity;

namespace entityframeworkcodebaseapproachwithdiftdb.Interfaces
{
    public interface Idepartmentservice
    {
        Task<List<departmentdto>> GetDepartments();
        Task<int> AddDepartment(departmentdto dept);
        Task<departmentdto> getdepartmentid(int id);
        Task<bool> Deletedepartmentbyid(int id);
        Task<bool> Updatedepartment(departmentdto dept);

    }
}
